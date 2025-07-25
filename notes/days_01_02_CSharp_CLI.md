# Backend Learning Journey – Days 1–2: C# Basics + CLI Programming

While my core background is in 3D graphics and creative development, I’ve taken on full-stack development as a strategic side learning path to open up career opportunities in web and software engineering.

With 4 years of experience in C++, I quickly picked up C# in just 3 days, thanks to the shared object-oriented concepts and strong technical foundations.

I’m currently learning ASP.NET Core, SQL Server, working through real-world full-stack patterns. Due to my full schedule and personal responsibilities, I’m progressing at a relatively slow pace — but with full focus on depth and practical understanding.

---

## Notes

- **Note 1**: I Have Strong background in C++, JavaScript, TS, and GLSL. C# OOP revision planned for 5 days.
- **Note 2**: I use PascalCase naming convention, but sometimes I forget. I’m working on improving it.
- **Note 3**: Comments here are used to document learning — not just code logic but reasoning, patterns, and progress.

---

## What I Learned – Summary

### Main Concepts
- `Main()` method and program structure
- `using` statements and namespaces

---

## 1. Variables & Data Types

Variables are containers for data (name + type + value).

| Type      | Example                      | Description                                  |
|-----------|------------------------------|----------------------------------------------|
| `int`     | `int age = 25;`              | Whole numbers                                |
| `float`   | `float temp = 36.5f;`        | Decimal (less precision, add `f`)            |
| `double`  | `double pi = 3.14159;`       | Higher precision decimals                    |
| `decimal` | `decimal price = 9.99m;`     | Very precise (money, add `m`)                |
| `string`  | `string name = "Ali";`       | Text/words                                   |
| `char`    | `char letter = 'A';`         | Single character                             |
| `bool`    | `bool isOn = true;`          | True/False                                   |
| `long`    | `long big = 2500000000L;`    | Very large integers (add `L`)                |
| `short`   | `short small = 12345;`       | Smaller integer range                        |
| `byte`    | `byte level = 255;`          | 0–255 (used for color, raw data)             |
| `sbyte`   | `sbyte diff = -100;`         | Like `byte` but supports negatives           |
| `uint`    | `uint score = 100u;`         | Unsigned int                                 |
| `ulong`   | `ulong stars = 1234567890;`  | Unsigned long                                |
| `ushort`  | `ushort port = 8080;`        | Unsigned short                               |

---

## 2. Control Flow

### `if`, `else if`, `else`
```csharp
if (age >= 18)
    Console.WriteLine("Adult");
else if (age > 12)
    Console.WriteLine("Teen");
else
    Console.WriteLine("Child");
```

### `switch` Statement
```csharp
int day = 3;
switch(day)
{
    case 1: Console.WriteLine("Monday"); break;
    case 2: Console.WriteLine("Tuesday"); break;
    case 3: Console.WriteLine("Wednesday"); break;
    default: Console.WriteLine("Unknown"); break;
}
```

---

## 3. Loops

### `for` loop
```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Hello " + i);
}
```

### `while` loop
```csharp
int i = 0;
while (i < 3)
{
    Console.WriteLine(i);
    i++;
}
```

### `do-while` loop
```csharp
int i = 0;
do
{
    Console.WriteLine(i);
    i++;
} while (i < 3);
```

### `foreach` loop
```csharp
string[] fruits = { "Apple", "Banana", "Mango" };
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
```

---

## 4. Methods

### Define and Call a Method
```csharp
void SayHello(string name)
{
    Console.WriteLine("Hello " + name);
}

SayHello("Musab");
```

### With Return Value
```csharp
int Add(int a, int b)
{
    return a + b;
}
int result = Add(5, 3); // result = 8
```

---

## 5. Error Handling

### try-catch-finally
```csharp
try
{
    int num = int.Parse("abc");
}
catch (FormatException e)
{
    Console.WriteLine("Invalid number format!");
}
finally
{
    Console.WriteLine("Always runs.");
}
```

### throw (Manual Error)
```csharp
int age = -1;
if (age < 0)
{
    throw new Exception("Age cannot be negative");
}
```

### Common Exception Types

| Type                   | When it occurs                          |
|------------------------|------------------------------------------|
| `Exception`            | General base error                      |
| `FormatException`      | Bad format conversion (e.g. string → int)|
| `NullReferenceException` | Accessing a null object              |
| `IndexOutOfRangeException` | Invalid array index access        |
| `DivideByZeroException` | Division by 0                          |

---

## 6. Console Input/Output

### Output
```csharp
Console.WriteLine("Welcome!");
```

### Input
```csharp
Console.Write("Enter name: ");
string name = Console.ReadLine();
Console.WriteLine("Hi " + name);
```

### Input + Conversion
```csharp
Console.Write("Enter age: ");
int age = int.Parse(Console.ReadLine());
```

---

## Tips
Always catch specific exceptions first.
Use finally to clean up (close files, etc.).
throw is used to raise manual errors.
Prefer readable method names (PascalCase).
Comments are useful for clarifying logic and planning.
Up Next
OOP: Classes, Objects, Inheritance, Encapsulation, Abstraction, Polymorphism
File I/O
Enum and Struct
Static vs Instance members
Arrays and Lists

---

## Up Next – Real Backend Essentials
OOP in C#
Master core principles with a real-world mini project: ATM_Simulator_Console_App.cs

File I/O
Read/write logs, config files, and data exports.

Enum & Struct
Model states (e.g., AccountStatus) and value types (e.g., Money).

Static vs Instance
Build reusable utilities vs per-object logic.

Arrays & Lists
Handle collections like transactions, users, and logs.

---

*This is part of my long-term backend roadmap using C#/.NET. All content is written with deep focus on clarity, real use cases, and long-term career prep.*
