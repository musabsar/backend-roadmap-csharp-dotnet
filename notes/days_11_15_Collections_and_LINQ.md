# Days_11_15_Collections_and_LINQ.md

## Collections & LINQ – Backend Developer Focus  
**Days: 11–15**

---

### #1. Categories of Collections in C#

#### A. Generic Collections (System.Collections.Generic)
| Type                     | Description                                              |
|--------------------------|----------------------------------------------------------|
| `List<T>`               | Dynamic array. Maintains insertion order.                |
| `Dictionary<TKey, TValue>` | Hash table, key-value pairs. Keys must be unique.       |
| `HashSet<T>`            | Stores only unique elements. Fast lookup.                |
| `Queue<T>`              | FIFO (First-In-First-Out) logic.                         |
| `Stack<T>`              | LIFO (Last-In-First-Out) logic.                          |

#### B. Non-Generic (Legacy)
- Avoid unless maintaining old code: `ArrayList`, `Hashtable`, `SortedList`.

#### C. Concurrent Collections (System.Collections.Concurrent)
| Type                          | Use Case                          |
|-------------------------------|-----------------------------------|
| `ConcurrentDictionary<,>`     | Thread-safe key-value store       |
| `BlockingCollection<T>`       | Producer-consumer queues          |
| `ConcurrentQueue<T>`          | Thread-safe FIFO queue            |

#### D. Specialized
- `SortedList<TKey, TValue>`, `SortedDictionary<TKey, TValue>`, `ObservableCollection<T>`, `LinkedList<T>`

---

### Backend Dev Priority
| Priority  | Collections                                                |
|-----------|------------------------------------------------------------|
| High      | `List<T>`, `Dictionary<,>`, `HashSet<T>`                   |
| Medium    | `Queue<T>`, `Stack<T>`, `ConcurrentDictionary<,>`          |
| Low       | `LinkedList<T>`, `SortedDictionary<,>`                     |
| Ignore    | Legacy non-generic unless maintaining old projects         |

---

### #2. LINQ – Language-Integrated Query  
LINQ enables SQL-like queries on collections. Namespace: `System.Linq`

#### Common LINQ Methods

| Category     | Method(s)                                 | Description                          |
|--------------|-------------------------------------------|--------------------------------------|
| Filtering    | `Where()`                                 | Filter elements                      |
| Projection   | `Select()`                                | Transform elements                   |
| Sorting      | `OrderBy()`, `ThenBy()`                   | Sort items                           |
| Aggregation  | `Count()`, `Sum()`, `Max()`, `Average()`  | Summary calculations                 |
| Element      | `First()`, `FirstOrDefault()`, `Single()` | Retrieve one or specific items       |
| Quantifiers  | `Any()`, `All()`                          | Test conditions                      |
| Set Ops      | `Distinct()`, `Union()`, `Intersect()`    | Perform set operations               |
| Grouping     | `GroupBy()`                               | Group elements by a key              |
| Joining      | `Join()`, `GroupJoin()`                   | Combine data from 2 collections      |
| Conversion   | `ToList()`, `ToArray()`, `ToDictionary()` | Materialize query                    |

---

### LINQ Best Practices
- Prefer `.FirstOrDefault()` over `.First()` to avoid exceptions.
- Use `.Any()` instead of `.Count() > 0` for better performance.
- Avoid LINQ in performance-critical loops.
- Call `.ToList()` only when needed (e.g., for caching results).

---

### Core Collection Methods

#### List<T>, HashSet<T>
| Method        | Purpose                       | Example                            |
|---------------|-------------------------------|-------------------------------------|
| `.Add()`      | Add item                      | `users.Add(newUser);`              |
| `.Remove()`   | Remove item                   | `activeIds.Remove(id);`            |
| `.Contains()` | Check existence               | `list.Contains(id);`               |
| `.Clear()`    | Clear all items               | `users.Clear();`                   |

#### Dictionary<TKey, TValue>
| Method            | Description                      | Example                            |
|-------------------|----------------------------------|-------------------------------------|
| `.Add(key, val)`  | Add entry                        | `userDict.Add(user.Id, user);`     |
| `.Remove(key)`    | Remove entry                     | `userDict.Remove(userId);`         |
| `.TryGetValue()`  | Safe lookup                      | `if(dict.TryGetValue(k, out var v))` |
| `.ContainsKey()`  | Check key existence              | `dict.ContainsKey(k);`             |
| `.Keys`           | Get all keys                     | `var ids = dict.Keys;`             |
| `.Values`         | Get all values                   | `var values = dict.Values;`        |

---

### Essential LINQ Examples (Method Syntax)

| Use Case          | Method                          | Example                                               |
|-------------------|----------------------------------|-------------------------------------------------------|
| Filter            | `.Where()`                       | `users.Where(u => u.IsActive)`                       |
| Find first        | `.FirstOrDefault()`              | `orders.FirstOrDefault(o => o.Id == id)`             |
| Existence check   | `.Any()`                         | `users.Any(u => u.Email == "x@x.com")`               |
| Transform         | `.Select()`                      | `users.Select(u => u.Email)`                         |
| Sort              | `.OrderBy()`, `.ThenBy()`        | `orders.OrderBy(o => o.Date).ThenBy(o => o.Total)`   |
| Grouping          | `.GroupBy()`                     | `sales.GroupBy(s => s.Category)`                     |
| Convert           | `.ToList()`, `.ToDictionary()`   | `users.ToDictionary(u => u.Id)`                      |
| Count             | `.Count()`, `.Sum()`             | `orders.Count()`, `orders.Sum(o => o.Amount)`        |

---

### HashSet<T> Specific
| Method            | Purpose                     | Example                              |
|-------------------|-----------------------------|---------------------------------------|
| `.Add(item)`      | Add if not exists           | `set.Add(id)`                         |
| `.Contains()`     | Fast lookup                 | `set.Contains(id)`                    |
| `.Remove()`       | Remove item                 | `set.Remove(id)`                      |
| `.UnionWith()`    | Merge two sets              | `set1.UnionWith(set2)`                |
| `.IntersectWith()`| Keep common items only      | `set1.IntersectWith(set2)`            |

---

### TL;DR (Must-Master LINQ)

| Scenario               | Method                       | Example                             |
|------------------------|------------------------------|--------------------------------------|
| Group by category      | `.GroupBy()`                 | `sales.GroupBy(s => s.Category)`     |
| Sort results           | `.OrderBy()`                 | `products.OrderBy(p => p.Name)`      |
| Convert list to map    | `.ToDictionary()`            | `users.ToDictionary(u => u.Id)`      |
| Merge two lists        | `.Join()`                    | `orders.Join(...)`                   |

---

### Final Tips
- LINQ query syntax is optional. Backend devs prefer **method syntax** for clarity.
- Learn to **compose** LINQ queries step-by-step for better maintainability.

