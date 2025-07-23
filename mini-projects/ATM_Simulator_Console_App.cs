/*
This is my first C# console project.
I used OOP, input validation, and clean structure.
I followed a UML class and activity diagram to plan it out.
I learned about switch, loops, and method design 
— and made sure the user experience was clear.
*/

/*
roject: ATM Simulator Console App
Features to include:

- Show menu repeatedly with options:
- Check Balance
- Deposit Money
- Withdraw Money

Exit
* Use if/else to handle menu choices
* Use loops (while or do-while) to keep the app running until exit
* Store balance as a float or decimal variable
* Create separate methods for deposit, withdrawal, and balance display
* Handle exceptions for invalid input (non-numbers, negative amounts, over-withdrawal)
* Use console input/output to interact with the user

UML Class Diagram
+-------------------+
|     ATMApp        |
+-------------------+
| - balance: decimal|
+-------------------+
| + Run(): void      |
| + ShowMenu(): void |
| + Deposit(): void  |
| + Withdraw(): void |
| + CheckBalance(): void |
| + GetUserInput(): decimal |
+-------------------+
Explanation:
ATMApp is the main class.
balance stores current money.
Run() contains the main loop showing the menu and handling choices.
ShowMenu() displays options.
Deposit(), Withdraw(), CheckBalance() implement respective features.
GetUserInput() is a helper method to read and validate user input safely (handling exceptions).
UML Activity Diagram (simplified)

Start
  |
Show Menu
  |
Get User Choice
  |
+------------------------+
| if choice == 1          |--> CheckBalance --> Show Menu
| else if choice == 2     |--> Deposit --> Show Menu
| else if choice == 3     |--> Withdraw --> Show Menu
| else if choice == 4     |--> Exit --> End
| else                   |--> Invalid input --> Show Menu
+------------------------+
*/

using System;
class Program
{
    static void Main(string[] args)
    {
        ATMApp app = new ATMApp();
        app.Run();
    }
    class ATMApp
    {
        private decimal balance = 0;
        private bool isFirstTime = true;
        //or public decimal Balance {get => balance; set => balance = value;}
        
        public ATMApp()
        {
            balance = 0;
        }
        
public void Run()
{
    Console.Clear();
    while (true)
    {
        Deposit();
        if (balance > 0)
        {
            isFirstTime = false;
            break;
        }
        Console.WriteLine("You must deposit a positive amount to continue.");
        Console.WriteLine("Press any key to try again...");
        Console.ReadKey();
        Console.Clear();
    }

    bool IsInApp = true;
    while (IsInApp)
    {
        Console.Clear();
        ShowMenu();
        Console.WriteLine("Choose one of the options [1 to 4]: ");

        string input = Console.ReadLine();
        int choice;

        if (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            continue;
        }

        Console.Clear(); // Clear before each action

        switch (choice)
        {
            case 1:
                CheckBalance();
                break;
            case 2:
                Deposit();
                break;
            case 3:
                Withdraw();
                break;
            case 4:
                IsInApp = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Enter 1 to 4.");
                break;
        }

        if (IsInApp)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    Console.Clear();
    Console.WriteLine("Thank you for using the ATM. Goodbye!");
    Console.WriteLine("Press any key to exit...");
    // Console.ReadKey(); soooo bad o_o
}

        
        private void ShowMenu()
        {
            Console.WriteLine("CheckBalance #1");
            Console.WriteLine("Deposit      #2");
            Console.WriteLine("Withdraw     #3");
            Console.WriteLine("Exit         #4");
        }
        
        private void Deposit()
        {
            if (isFirstTime)
            {
                Console.WriteLine("Enter your First Time deposit amount : ");
            }
            else
            {
                Console.WriteLine("Enter amount to deposit: ");
            }
            
            decimal amount = GetUserInput(); 
             
            if (amount <= 0)  
            {
                Console.WriteLine("Amount must be greater than zero.");
                return;
            }
            
            balance += amount;
            Console.WriteLine($"{amount:C} has been added. Your balance is now {balance:C}");
            // chatgpt said: 
            // :C formats the number as currency $100.00 or JD100.00 depending on system locale
            
        }
        

        
        private void Withdraw()
        {
            Console.WriteLine("Enter withdraw amount: ");
            decimal amount = GetUserInput();

            if (amount <= 0)
            {
                Console.WriteLine("Enter valid withdraw amount: ");
                return;
            }
            
            if (amount > balance)
            {
                Console.WriteLine("The withdraw amount is larger then balance");
                return;
            }
            
            balance -= amount;
            Console.WriteLine($"{amount:C} has been withdrawn. Your balance is now {balance:C}");
        }
        
        private void CheckBalance()
        {
            Console.WriteLine($"Your balance is: {balance:C}");
        }
        
        private decimal GetUserInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal amount))
                {
                    return amount;
                }
                Console.WriteLine("Invalid input. Please enter a decimal number.");
            }
        }

    }
}
