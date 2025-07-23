using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

static public class Program
{
    enum LoginStatus
    {
        Success,
        Failed,
        LockedOut
    }

    enum UserRole
    {
        Scientist,
        Engineer,
        Security
    }

    class User
    {
        public string Username { get; }
        public string Password { get; }
        public UserRole Role { get; }

        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }

    static List<User> Users = new List<User>
    {
        new User("musabsar", "1234", UserRole.Scientist),
        new User("engineer1", "ice@eng", UserRole.Engineer),
        new User("sec01", "secure", UserRole.Security)
    };

    static int attemptCount = 0;
    const int MaxAttempts = 3;
    static User loggedInUser = null;

    static void Main()
    {
        Console.WriteLine("== Research Base Login ==\n");

        while (attemptCount < MaxAttempts)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine()?.Trim();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (!ValidateInput(username, password))
            {
                Console.WriteLine("Username must be ≥ 3 chars, password ≥ 4 chars.\n");
                continue;
            }

            LoginStatus result = CheckCredentials(username, password);
            LogAudit(username, result);

            if (result == LoginStatus.Success)
            {
                Console.WriteLine($"Access Granted. Role: {loggedInUser.Role}\n");
                break;
            }
            else if (result == LoginStatus.LockedOut)
            {
                Console.WriteLine("System locked. Too many failed attempts.\n");
                break;
            }
            else if (result == LoginStatus.Failed)
            {
                Console.WriteLine($"Access Denied. Attempts left: {MaxAttempts - attemptCount}\n");
            }
        }
    }

    static bool ValidateInput(string user, string pass)
    {
        return !string.IsNullOrEmpty(user) && user.Length >= 3 &&
               !string.IsNullOrEmpty(pass) && pass.Length >= 4;
    }

    static LoginStatus CheckCredentials(string username, string password)
    {
        attemptCount++;

        var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            loggedInUser = user;
            return LoginStatus.Success;
        }

        if (attemptCount >= MaxAttempts)
            return LoginStatus.LockedOut;

        return LoginStatus.Failed;
    }

    static void LogAudit(string username, LoginStatus status)
    {
        string folderPath = @"C:\ResearchBaseLogs";
        string filePath = Path.Combine(folderPath, "audit_log.txt");

        try
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | User: {username} | Status: {status}";
                writer.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Logging error: {ex.Message}");
        }
    }
}
