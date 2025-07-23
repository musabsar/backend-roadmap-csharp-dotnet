using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RealTimeSensorSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Real-Time Sensor Monitor System Started...\n");

            SensorMonitor monitor = new SensorMonitor();
            AlertSystem alert = new AlertSystem();

            monitor.SensorAlert += alert.OnSensorAlert;

            // Add sensors
            monitor.AddSensor(new Sensor("TEMP-01", 0, 100));
            monitor.AddSensor(new Sensor("PRES-77", 20, 200));

            // Simulate async polling loop
            await monitor.StartMonitoringAsync(pollIntervalMs: 2000);
        }
    }

    // sensor core  class    
    class Sensor
    {
        public string Id { get; }
        public string Name { get; }
        public float Min { get; }
        public float Max { get; }
        private Random rnd = new Random();

        public float CurrentValue { get; private set; }

        public Sensor(string name, float min, float max)
        {
            Id = Guid.NewGuid().ToString()[..5]; // Short ID
            Name = name;
            Min = min;
            Max = max;
        }

        // Func to simulate reading from hardware
        public Func<float> ReadValue => () =>
        {
            CurrentValue = (float)(Min + rnd.NextDouble() * (Max - Min + 30)); // may exceed
            return CurrentValue;
        };
    }

    // monitor checks for alert conditions
    class SensorMonitor
    {
        public List<Sensor> Sensors { get; private set; } = new();
        public event EventHandler<SensorEventArgs> SensorAlert;

        private Func<Sensor, bool> isCritical = sensor => sensor.CurrentValue > sensor.Max;

        public void AddSensor(Sensor sensor) => Sensors.Add(sensor);

        public async Task StartMonitoringAsync(int pollIntervalMs)
        {
            while (true)
            {
                foreach (var sensor in Sensors)
                {
                    float value = sensor.ReadValue.Invoke();
                    Console.WriteLine($"{sensor.Name} [{sensor.Id}]: {value}");

                    if (isCritical(sensor))
                    {
                        OnSensorAlert(sensor);
                    }
                }

                await Task.Delay(pollIntervalMs);
            }
        }

        // Raise Event
        protected virtual void OnSensorAlert(Sensor sensor)
        {
            SensorAlert?.Invoke(this, new SensorEventArgs(sensor));
        }
    }

    // Alert System listens to events 
    class AlertSystem  
    {
        public void OnSensorAlert(object sender, SensorEventArgs e)
        {  
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ALERT! Sensor [{e.Sensor.Name}] exceeded safe value: {e.Sensor.CurrentValue}");
            Console.ResetColor();
        }
    }

    // Custom EventArgs
    class SensorEventArgs : EventArgs
    {
        public Sensor Sensor { get; }

        public SensorEventArgs(Sensor sensor)
        {
            Sensor = sensor;
        }
    }
}
