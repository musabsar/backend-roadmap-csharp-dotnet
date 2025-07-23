# Days: 21-25  
## Logic + Validation

### Goals:
- Apply enums to handle app states  
- Validate user input (length, format, required)  
- Use try/catch/finally for robust error handling  
- Read/write files using StreamReader/StreamWriter  
- Build a basic login system storing audit logs to file  

---

## 1. Using Enums for App States  

enum AppState
{
    LoggedOut,
    LoggedIn,
    Locked
}
Use enums to manage and control the flow of the application states clearly.


2. User Input Validation
Check if input is not empty

Validate length and format (e.g., email, password rules)

Example:

string input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input) || input.Length < 5)
{
    Console.WriteLine("Invalid input, try again.");
}


3. Exception Handling with try/catch/finally
try
{
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine($"You entered {number}");
}
catch (FormatException ex)
{
    Console.WriteLine("Input was not a valid number.");
}
finally
{
    Console.WriteLine("Execution completed.");
}
Use finally to execute code regardless of success or error.



4. File I/O Using StreamReader and StreamWriter
Writing to a file:
csharp
Copy code
using (StreamWriter writer = new StreamWriter("audit.log", append: true))
{
    writer.WriteLine($"{DateTime.Now}: User logged in");
}
Reading from a file:
csharp
Copy code
using (StreamReader reader = new StreamReader("audit.log"))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}


5. Basic Login System with Audit Logs
Validate username and password input

Store successful and failed login attempts in a log file

Lock the user out after 3 failed attempts

Example snippet:
int attempts = 0;
bool loggedIn = false;

while(attempts < 3 && !loggedIn)
{
    Console.Write("Enter username: ");
    string username = Console.ReadLine();

    Console.Write("Enter password: ");
    string password = Console.ReadLine();

    if (IsValidUser(username, password))
    {
        loggedIn = true;
        LogAudit($"{username} logged in successfully.");
        Console.WriteLine("Welcome!");
    }
    else
    {
        attempts++;
        LogAudit($"{username} failed login attempt {attempts}.");
        Console.WriteLine("Invalid credentials.");
    }
}

if (!loggedIn)
{
    Console.WriteLine("Account locked due to too many failed attempts.");
}

void LogAudit(string message)
{
    using (StreamWriter writer = new StreamWriter("audit.log", true))
    {
        writer.WriteLine($"{DateTime.Now}: {message}");
    }
}

bool IsValidUser(string username, string password)
{
    // Replace with real validation
    return username == "admin" && password == "1234";
}
Login System + Audit Logs Flowchart
(You can create this in Mermaid or any diagram tool)


mermaid flowchart TD: 
    A[Start Login] --> B{Enter Username & Password}
    B --> C{Valid Credentials?}
    C -- Yes --> D[Log Success to Audit File]
    D --> E[Show Welcome Message]
    C -- No --> F[Increment Failed Attempts]
    F --> G{Attempts >= 3?}
    G -- Yes --> H[Lock Account]
    G -- No --> I[Prompt Retry]
    I --> B
