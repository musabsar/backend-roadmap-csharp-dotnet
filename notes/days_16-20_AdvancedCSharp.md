Days: 16-20
Advanced C#

Learn the Concepts
Concept	            Summary (1-line)
delegate	        A type that holds a reference to a method (like a function pointer).
event	            A way to notify other parts of the app when something happens.
lambda	            A short inline function: (x) => x * 2
Func<> / Action<>	Generic built-in delegates: return vs. void
async/await	        Run tasks without blocking the main thread (great for sensors/timers).


            ----    ----    ----    ----
#1. Lambda Expression
Shortcut to write methods inline.
exm:    (x, y) => x + y // Same as: int Add(int x, int y) { return x + y; }
Used with delegates or built-in types like Func<>

            ----    ----    ----    ----
#2. Delegate: Func<>, Action<>, Predicate<>, Custom Delegate
Why useful?     You can pass behavior (not just data) into methods or events.
Type	            Takes Params	Returns
--------------      ------------    -------
1. Custom Delegate 
Think of it like a "method variable" — you can store a function inside a variable.
exm:    using System;
        class myCode {
            delegate int Math(int I, int O);
    
          static void Main() 
          {
            // int add =...; will not work.
            Math add = (I, O) => (I + (O *2));
            Console.WriteLine(Use(5,6));
          }
        }
| Part                               | What it is                                                                                   |
| ---------------------------------- | -------------------------------------------------------------------------------------------- |
| `delegate int Test(int I, int O);` | Declares a delegate type (a method signature)                                                |
| `Math`                             | The delegate type (like a class for functions)                                               |
| `add`                              | A variable of type `Math`, which can hold any method matching the signature `int (int, int)` |
i will use it when i want descriptive names or custom behavior.

2. Func<A,B,C>
Func<int, int, int> add = (x, y) => x + y; // last type is return type
Console.WriteLine(add(2, 3)); // 5

3. Action<T>
Action<string> greet = name => Console.WriteLine("Hello " + name);
greet("Musab"); // Hello Musab

exm2:
// i will use it to replace Console.WriteLine();
using System;
public static class c
{
    public static Action<object> show = data => Console.WriteLine(data);
    public static Func<string>   read = () => Console.ReadLine();
}

class myCode
{
    static void Main()
    {
        int i = 5;
        bool b = true;
        string s = "m";

        c.show("Enter Time:");
        int Time = int.Parse(c.read());
        c.show($"Time: {Time}");

        c.show(i);
        c.show(b);
        c.show(s);
    }
}


4. Predicate<T>
Returns bool, used for conditions.
exm:    
Predicate<int> isEven = n => n % 2 == 0;
Console.WriteLine(isEven(4)); // true // Shortcut for Func<T, bool>

These are ready-made delegates so you don’t write delegate yourself.

            ----    ----    ----    ----
#3. Events
An event is a signal — something happened.
Think like this:
A sensor detects high temperature
It raises an event
Another part of your code is listening and takes action

exm:    // Declare delegate
        public delegate void ThresholdExceededHandler(string sensorId, double value);
        // Declare event    
        public event ThresholdExceededHandler OnThresholdExceeded;

            ----    ----    ----    ----
#4. Event-Driven Programming
Your app waits for events (instead of checking conditions constantly).

Like: “if this happens → do that”

Examples:
- Button clicked
- Sensor passed threshold
- Data received

            ----    ----    ----    ----
#5. async/await
Used for non-blocking, background work (like polling sensor data every few seconds).
exm:    async Task Poll()
        {
        while (true)
        {
            await Task.Delay(2000);
            Console.WriteLine("Sensor check...");
        }
    }

Summary Table

Concept	        What it is	                        Why it's useful
-----------     ------------------------------      ---------------------------------
delegate	    Function variable	                Pass logic like data
lambda	        Inline function	                    Shorter syntax for simple methods
Func<>	        Function that returns value	        Built-in reusable delegate
Action<>	    Function that returns nothing	    For things like Log(string msg)
event	        Signal that something happened	    Let other code "react" to changes
async/await	    Run in background	                Poll sensors or APIs efficiently
*/
/*
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public static class c
{
    public static Action<object> show = data => Console.WriteLine(data);
    public static Func<string> read = () => Console.ReadLine();
}

class myCode
{
    static List<DeliveryLog> deliveryLogs = new List<DeliveryLog>();
    static async Task Main()
    {
        c.show("start");
        string trackingNumber = "ABC123";
        string status = await SimulateCourierCheckAsync(trackingNumber);

        var log = new DeliveryLog
        {
            TrackingNumber = trackingNumber,
            Status = status,
            CheckedAt = DateTime.Now
        };
        deliveryLogs.Add(log);

        foreach (var entry in deliveryLogs)
        {
            c.show($"[{entry.CheckedAt}] {entry.TrackingNumber}: {entry.Status}");
        }
        c.show("end");
    }

    static async Task<string> SimulateCourierCheckAsync(string tracking)
    {
        await Task.Delay(1500);
        return "In Transit";
    }
    public class DeliveryLog
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public DateTime CheckedAt { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<DeliveryLog> DeliveryLogs => Set<DeliveryLog>();
    }
}

