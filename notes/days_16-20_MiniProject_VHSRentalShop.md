Days: 16-20
Mini Project
Create a CLI-based System. Use classes, lists, file storage, validation, and exception handling. Add README with instructions and diagrams using Mermaid.js.
GitHub repo w/ Mermaid.js diagrams + VHSRentalShop.cs

# Days: 16-20  
## Mini Project: VHS Rental Shop CLI System

### Project Goals:
- Build a CLI system using **classes** and **lists**  
- Implement **file storage** to save/load data  
- Apply **validation** and **exception handling**  
- Create a **README** with usage instructions and diagrams using Mermaid.js  

---

## Project Overview:

A simple VHS Rental Shop CLI system where users can:  
- View available VHS tapes  
- Rent and return tapes  
- Track rental status  

---

## Core Features:

- Use `class` to model VHS tapes and rentals  
- Store VHS data in a list and persist it to file  
- Validate user inputs (e.g., tape ID, customer name)  
- Handle errors gracefully with try/catch  
- Log rental activity to a file  

---

## Example Classes
public class VHSTape
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsRented { get; set; }
}

public class RentalShop
{
    private List<VHSTape> tapes = new List<VHSTape>();

    public void LoadTapes(string filePath) { /* Load from file */ }
    public void SaveTapes(string filePath) { /* Save to file */ }
    public void RentTape(int tapeId) { /* Mark as rented */ }
    public void ReturnTape(int tapeId) { /* Mark as returned */ }
    public void DisplayAvailable() { /* List all not rented tapes */ }
}
Basic Input Validation and Exception Handling
try
{
    Console.Write("Enter Tape ID to rent: ");
    int id = int.Parse(Console.ReadLine());
    rentalShop.RentTape(id);
}
catch (FormatException)
{
    Console.WriteLine("Invalid input! Please enter a valid number.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}


File I/O Example
Use StreamReader and StreamWriter or File.ReadAllLines / File.WriteAllLines to persist VHS tape data and rental logs.
README Content Example
VHS Rental Shop CLI
Features:

Rent and return VHS tapes
View available tapes
Input validation and error handling

Mermaid.js Diagram for Rental Flow
flowchart TD
    A[Start] --> B[Display Available Tapes]
    B --> C{User Action}
    C -- Rent --> D[Enter Tape ID]
    D --> E{Tape Available?}
    E -- Yes --> F[Mark Tape as Rented]
    F --> G[Update File Storage]
    G --> B
    E -- No --> H[Show Error Message]
    H --> B
    C -- Return --> I[Enter Tape ID]
    I --> J[Mark Tape as Returned]
    J --> G
    C -- Exit --> K[End Program]
