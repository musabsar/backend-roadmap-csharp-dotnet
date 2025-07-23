using System.Text.Json; // for JSON serialization/deserialization
using System.IO;        // for reading and writing files

using System;
using System.Linq;
using System.Collections.Generic;

namespace VHSRentalShop
{
    class Program
    {
        static string tapesFile = "tapes.json";
        static string customersFile = "customers.json";
        static string rentalsFile = "rentals.json";

        static List<Tape> tapes = new List<Tape>();
        static List<Customer> customers = new List<Customer>();
        static Dictionary<int, Rental> activeRentals = new Dictionary<int, Rental>();
        static HashSet<int> rentedTapeIds = new HashSet<int>();

        static void SortTapesByLoc()
        {
            tapes = tapes
                    .OrderBy(t => t.Location.ShelfUnit)
                    .ThenBy(t => t.Location.Shelf)
                    .ThenBy(t => t.Location.PositionFromRight)
                    .ToList();
        }

        static void Main()
        {
            // SeedData(); i will use LoadData(); insted.
            LoadData(); // load data from .json

            while (true)
            {
                Console.WriteLine("\n=== VHS Rental Shop ===");
                Console.WriteLine("1. Show Available Tapes");
                Console.WriteLine("2. Rent a Tape");
                Console.WriteLine("3. Return a Tape");
                Console.WriteLine("4. Show Active Rentals");
                Console.WriteLine("5. Sort Tapes by Location");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");

                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1": ShowAvailableTapes(); break;
                    case "2": RentTape(); break;
                    case "3": ReturnTape(); break;
                    case "4": ShowActiveRentals(); break;
                    case "5": 
                              SortTapesByLoc();
                              Console.WriteLine("Tapes sorted by location.");
                              SaveData(); break;
                              
                    case "6": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }

            }
        }

        #region JSON_SaveLoad_functions
        // insted of static void SeedData() so i can savr data for real.
        static void LoadData()
        {
            if (File.Exists(tapesFile))
                tapes = JsonSerializer.Deserialize<List<Tape>>(File.ReadAllText(tapesFile)) ?? new List<Tape>();
            else
                tapes = new List<Tape>
            {
                new Tape
                {
                    Id = 1,
                    Title = "The Fuck",
                    Genre = "Sci-Fi",
                    Location = new TapeLocation { ShelfUnit = 1, Shelf = 1, PositionFromRight = 1 }
                },
                new Tape
                {
                    Id = 2,
                    Title = "JordanIQ",
                    Genre = "Drama",
                    Location = new TapeLocation { ShelfUnit = 1, Shelf = 1, PositionFromRight = 3 }
                },
                new Tape
                {
                    Id = 3,
                    Title = "The Thing",
                    Genre = "Horror",
                    Location = new TapeLocation { ShelfUnit = 8, Shelf = 1, PositionFromRight = 2 }
                },
                new Tape
                {
                    Id = 4,
                    Title = "Al-Owda Ela Al-Mustaqbal",
                    Genre = "Sci-Fi",
                    Location = new TapeLocation { ShelfUnit = 15, Shelf = 2, PositionFromRight = 13 }
                },
                new Tape
                {
                    Id = 5,
                    Title = "Tuyoor Al-Janna",
                    Genre = "Drama",
                    Location = new TapeLocation { ShelfUnit = 1, Shelf = 2, PositionFromRight = 15 }
                },
                new Tape
                {
                    Id = 6,
                    Title = "Al-Amal Al-Akheer",
                    Genre = "Horror",
                    Location = new TapeLocation { ShelfUnit = 1, Shelf = 5, PositionFromRight = 3 }
                },
                new Tape
                {
                    Id = 7,
                    Title = "Layla Fi Al-Sahra",
                    Genre = "Adventure",
                    Location = new TapeLocation { ShelfUnit = 1, Shelf = 3, PositionFromRight = 11 }
                },
                new Tape
                {
                    Id = 8,
                    Title = "Asrar Al-Madina",
                    Genre = "Mystery",
                    Location = new TapeLocation { ShelfUnit = 1, Shelf = 3, PositionFromRight = 2 }
                },
                new Tape
                {
                    Id = 9,
                    Title = "Rehla Abra Al-Zaman",
                    Genre = "Sci-Fi",
                    Location = new TapeLocation { ShelfUnit = 1, Shelf = 3, PositionFromRight = 3 }
                },
                new Tape
                {
                    Id = 10,
                    Title = "Al-Fursan Al-Arba'a",
                    Genre = "Historical",
                    Location = new TapeLocation { ShelfUnit = 1, Shelf = 4, PositionFromRight = 1 }
                },
                new Tape
                {
                    Id = 11,
                    Title = "Madina Al-Zilal",
                    Genre = "Horror",
                    Location = new TapeLocation { ShelfUnit = 1, Shelf = 4, PositionFromRight = 2 }
                }

                /*
                    Tape NewTape(int id, string title, string genre, int unit, int shelf, int pos) =>
                    new Tape
                    {
                        Id = id,
                        Title = title,
                        Genre = genre,
                        Location = new TapeLocation
                        {
                            ShelfUnit = unit,
                            Shelf = shelf,
                            PositionFromRight = pos
                        }
                    };

                tapes = new List<Tape>
                {
                    NewTape(1, "The Fuck",               "Sci-Fi",     1, 1, 1),
                    NewTape(2, "JordanIQ",               "Drama",      1, 1, 2),
                    NewTape(3, "The Thing",              "Horror",     1, 1, 3),
                    NewTape(4, "Al-Owda Ela Al-Mustaqbal", "Sci-Fi",   1, 2, 1),
                    NewTape(5, "Tuyoor Al-Janna",        "Drama",      1, 2, 2),
                    NewTape(6, "Al-Amal Al-Akheer",      "Horror",     1, 2, 3),
                    NewTape(7, "Layla Fi Al-Sahra",      "Adventure",  1, 3, 1),
                    NewTape(8, "Asrar Al-Madina",        "Mystery",    1, 3, 2),
                    NewTape(9, "Rehla Abra Al-Zaman",    "Sci-Fi",     1, 3, 3),
                    NewTape(10,"Al-Fursan Al-Arba'a",    "Historical", 1, 4, 1),
                    NewTape(11,"Madina Al-Zilal",        "Horror",     1, 4, 2),
                };
                */
            };



            if (File.Exists(customersFile))
                // dont use ...!; ! (null-forgiving operator) C# 8.0 and later ok.
                customers = JsonSerializer.Deserialize<List<Customer>>(File.ReadAllText(customersFile)) ?? new List<Customer>();
            else
                customers = new List<Customer>
                {
                    new Customer { Id = 1, Name = "mustafa" },
                    new Customer { Id = 2, Name = "musab_sar" },
                    new Customer { Id = 3, Name = "ahmad" },
                    new Customer { Id = 4, Name = "harat" },
                };

            if (File.Exists(rentalsFile))
            {
                var rentals = JsonSerializer.Deserialize<List<Rental>>(File.ReadAllText(rentalsFile)) ?? new List<Rental>();
                activeRentals = rentals.ToDictionary(r => r.TapeId, r => r);
                rentedTapeIds = new HashSet<int>(rentals.Select(r => r.TapeId));
            }
            else
            {
                activeRentals = new Dictionary<int, Rental>();
                rentedTapeIds = new HashSet<int>();
            }
        }

        static void SaveData() // helper mathed for JSON Save & Load
        {
            File.WriteAllText(tapesFile, JsonSerializer.Serialize(tapes));
            File.WriteAllText(customersFile, JsonSerializer.Serialize(customers));
            File.WriteAllText(rentalsFile, JsonSerializer.Serialize(activeRentals.Values.ToList()));
        }
        #endregion


        #region Old_SeedData_function
        /*
        static void SeedData()
        {
            tapes.Add(new Tape { Id = 1, Title = "Tia-Book", Genre = "Math" });
            tapes.Add(new Tape { Id = 2, Title = "His-Book", Genre = "Horror" });
            tapes.Add(new Tape { Id = 3, Title = "How-With", Genre = "3D" });

            customers.Add(new Customer { Id = 1, Name = "Ali" });
            customers.Add(new Customer { Id = 2, Name = "Mark" });
        }
        */
        #endregion
        /*
        static void ShowAvailableTapes()
        {
            var available = tapes.Where(t => !rentedTapeIds.Contains(t.Id)).ToList();

            if (available.Count == 0)
            {
                Console.WriteLine("No Available Tapes");
                return;
            }
            Console.WriteLine("Avalilable Tapes List");
            foreach (var t in available)
            {
                Console.WriteLine($"Id, Title: {t.Title}, Genre: {t.Genre}");
            }
        }
        */

        static void ShowAvailableTapes()
        {
            var available = tapes.Where(t => !rentedTapeIds.Contains(t.Id)).ToList();
            if (available.Count == 0)
            {
                Console.WriteLine("No Tapes available.");
                return;
            }
            Console.WriteLine("Available Tapes: ");
            foreach (var t in available)
            {
                Console.WriteLine($"Id: {t.Id} Title: {t.Title} Genre: {t.Genre} | Location: {t.Location.GetBackString()}");
            }
        }

        static void RentTape()
        {
            Console.WriteLine("Enter Customer Id: ");
            if (!int.TryParse(Console.ReadLine(), result: out int customerId))
            {
                Console.WriteLine("Invalid input. Please enter a numeric customer Id.");
                return;
            }

            var customer = customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            Console.WriteLine("Enter Tape Id: ");
            if (!int.TryParse(Console.ReadLine(), out int tapeId))
            {
                Console.WriteLine("Invalid input. Please enter a numeric tape ID.");
                return;
            }

            var tape = tapes.FirstOrDefault(t => t.Id == tapeId);
            if (tape == null)
            {
                Console.WriteLine("Tape Not Found.");
                return;
            }

            if (rentedTapeIds.Contains(tapeId))
            {
                Console.WriteLine($"Tape '{tape.Title}' is already rented.");
                return;
            }

            var rental = new Rental
            {
                TapeId = tapeId,
                CustomerId = customerId,
                RentedAt = DateTime.Now
            };

            activeRentals[tapeId] = rental;
            rentedTapeIds.Add(tapeId);
            SaveData(); // <<< ADD THIS

            Console.WriteLine($"'{tape.Title}' rented to {customer.Name}.");

        }

        static void ReturnTape()
        {
            Console.Write("Enter Tape ID to return: ");
            if (!int.TryParse(Console.ReadLine(), out int tapeId) || !rentedTapeIds.Contains(tapeId))
            {
                Console.WriteLine("Invalid or not rented.");
                return;
            }

            rentedTapeIds.Remove(tapeId);
            activeRentals.Remove(tapeId);
            SaveData();

            Console.WriteLine("Tape returned successfully.");
        }

        static void ShowActiveRentals()
        {
            if (activeRentals.Count == 0)
            {
                Console.WriteLine("No active rentals.");
                return;
            }

            Console.WriteLine("Active Rentals:");
            foreach (var rental in activeRentals.Values)
            {
                var customer = customers.First(c => c.Id == rental.CustomerId);
                var tape = tapes.First(t => t.Id == rental.TapeId);

                Console.WriteLine($"{customer.Name} rented '{tape.Title}' on {rental.RentedAt}");
            }
        }
    }

    class Tape
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Genre { get; set; } = "";
        public TapeLocation Location { get; set; } = new TapeLocation();

    }

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    class Rental
    {
        public int TapeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentedAt { get; set; }
    }

    class TapeLocation
    { 
        public int ShelfUnit { get; set; }
        public int Shelf { get; set; }
        public int PositionFromRight { get; set; }

        public string GetBackString()
        {
            return
                $" Cabinet {ShelfUnit}," +
                $" Shelf {Shelf}," +
                $" Position {PositionFromRight}" +
                $" from right";
        }
    }
}
