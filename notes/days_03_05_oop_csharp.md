# OOP in C# – Core Concepts for Backend Development

Understanding and applying OOP principles is essential for writing scalable, maintainable backend systems in C#. Below are key concepts with real-world backend relevance and concise code examples.

---

## 1. Encapsulation

Encapsulation is the principle of restricting direct access to internal data, and exposing it only through controlled interfaces.

```csharp
public class Device
{
    private float powerInWatt; // camelCase for private field

    public float PowerInWatt // PascalCase for public property
    {
        get => powerInWatt;
        set => powerInWatt = value;
    }

    // OR in a single line:
    // public float PowerInWatt{ get => powerInWatt; set => powerInWatt = value; }
}
```

- Replace public fields with private + properties.
- Private field: `powerInWatt` (camelCase)
- Public property: `PowerInWatt` (PascalCase)

| Scope     | Style      | Example        | Why?                    |
|-----------|------------|----------------|--------------------------|
| private   | camelCase  | powerInWatt    | For internal fields      |
| public    | PascalCase | PowerInWatt    | For properties/methods   |

**Why it matters in backend**: Prevents invalid state in domain models, enforces clean API contracts.

---

## 2. Inheritance

Inheritance allows a class to inherit properties and behaviors from a base class.

```csharp
public class Vehicle
{
    public string Brand { get; set; }
    public void Start() => Console.WriteLine("Starting vehicle...");
}

public class Car : Vehicle
{
    public int Wheels { get; set; } = 4;
}
```

 **Backend use case**: Base classes like `BaseEntity`, `BaseService`, or `BaseController` share logic.

---

## 3. Polymorphism

Polymorphism enables different classes to respond to the same method call in different ways.

```csharp
public class Logger
{
    public virtual void Log(string message)
    {
        Console.WriteLine($"Default log: {message}");
    }
}

public class FileLogger : Logger
{
    public override void Log(string message)
    {
        File.AppendAllText("log.txt", message + Environment.NewLine);
    }
}
```

**Backend use case**: Use interfaces like `ILogger` for flexible logging (file, DB, console).

---

## 4. Abstraction

Abstraction hides internal implementation and exposes only what's necessary.

```csharp
public interface INotificationService
{
    void Send(string to, string message);
}

public abstract class ReportGenerator
{
    public abstract void Generate();
}
```

**Backend use case**: Interfaces define service contracts (e.g. `IEmailService`, `IRepository`).

---

## Real-World Practice Project: Vehicle Management System (Console App)

Use OOP to model backend logic:

### Requirements:
- `Vehicle` (base class): `Brand`, `Model`, `Start()`
- `Car`, `Truck`, `Motorcycle` inherit from `Vehicle`
- Override `DisplayInfo()` using polymorphism
- Add `IServiceable` interface with `Service()` method
- Use encapsulation for `Mileage` with validation

This simulates domain-driven design: Entity, AggregateRoot, Service.

---

## OOP Fundamentals

1. A class is a **blueprint**.
2. An object is a **real instance** created from the class.
3. Constructor: special method to initialize objects.

---

## C# Type Keywords

| Keyword   | Meaning                                                  |
|-----------|----------------------------------------------------------|
| `class`   | Reference type with methods, properties, inheritance     |
| `struct`  | Value type, lightweight, stack-allocated                 |
| `interface` | Contract without implementation                       |
| `record`  | Immutable reference type, best for DTOs                  |
| `enum`    | Set of named constant values                             |
| `delegate`| Type-safe function pointer (for events/callbacks)        |

---

## Access Modifiers

| Modifier             | Meaning                                             |
|----------------------|-----------------------------------------------------|
| `public`             | Accessible from anywhere                           |
| `private`            | Only within the same class                         |
| `protected`          | Class + derived classes                            |
| `internal`           | Same project/assembly only                         |
| `protected internal` | Derived or same project                            |
| `private protected`  | Derived + same class + same project                |

---

## Method Parameter Modifiers

| Modifier   | Meaning                                                                 |
|------------|-------------------------------------------------------------------------|
| `params`   | Accepts variable number of arguments (as array), must be last param     |
| `ref`      | Passes by reference; can be modified inside method                      |
| `out`      | Like `ref`, but must be assigned in method                              |
| `in`       | Passes by reference, but read-only                                      |
| `optional` | Can be skipped (must have default value)                                |
| `this`     | Used in extension methods to bind to type being extended                |

---

## next: 6–10: Collections & LINQ

- **Master C# Collections**: 
Learn key types like `List<T>`, `Dictionary<TKey, TValue>`, `Stack<T>`, and `Queue<T>`.

- **LINQ Fundamentals**: 
Use `Where`, `Select`, `OrderBy`, `GroupBy`, `ToList`, etc. for querying in-memory data.

