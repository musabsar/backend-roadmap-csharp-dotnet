/*
mini Project #01:
Mini Supermarket Billing System
Scenario: Simulate a small grocery cashier system.

Features:
Predefined product list (e.g., apples, milk, rice)

Add items to cart by entering item ID and quantity
Calculate subtotal, tax, and total
Show receipt at the end
Option to clear cart or checkout

What You Learn:
Arrays/lists, loops, switch, input parsing, simple math

--------------------------------------------------------------
sol mini  Project #01
> Products, Cart, Billing, User Input, Receipt.
---
Step 2: UML Class Diagram
    prodect             cartItem                cart   
    --------------      -------------------     --------------
    - id: int            - product:   product     - AddItem();
    - name: string       - quantity:  int         - RemoveItem();
    - price: float       - GetTotal();            - CalTotal();

note: I have to put a space like this:
(- text) but not like this (-text) why discover it yourself reader ok. :)

Step 3: ER Diagram (Entity-Relationship)

Step 4: System Modules (Component View)
Step 5: code it                
*/

using System;
using System.Collections.Generic; // for using List<T> aka Generic data types.

class Program
{
    static void Main()
    {	
        // Create a product
        Product apple = new Product { Id = 1, Name = "Apple", Price = 0.5m };
    
        // Create cart and add product with quantity
        Cart cart = new Cart();
        cart.AddItem(new CartItem { Product = apple, Quantity = 3 });
    
        // Calculate total
        decimal total = cart.CalTotal();
        Console.WriteLine($"Total price: {total:C}");
    }
  
        class Product 
        {
            private int id;
            private decimal price; // later, i realized that using decimals is better thin float.
            private string name;
            
            /*
            get => id;          â†’ return the value of the private field.
            set => id = value;  â†’ assign a new value to id.
            value               â†’ a keyword that represents it is use.
            */
            public int Id { get => id; set => id = value; }
            public decimal Price { get => price; set => price = value; }
            public string Name { get => name; set => name = value; }
            
        }
        
        class SubProduct : Product
        {
            private float powerInWatt; // camelCase private 
            public float PowerInWatt   // PascalCase public & different variable.
            {
                get => powerInWatt;
                set => powerInWatt = value;
            }            
            SubProduct()
            {
                ...
            }
        }
        
        class CartItem
        {   
            // use lowercase naming > only used inside the class (private).
            private Product product;
            private int quantity; 
            
            // use PascalCase naming > accessed out of class.
            public Product Product { get => product; set => product = value; }
            public int Quantity { get => quantity; set => quantity = value; }
            
            public decimal GetTotal()
            {
                return Product.Price * Quantity;
            }
        }
        
        class Cart 
        {
            private List<CartItem> items = new List<CartItem>();
            
            // dont use
            //public List<CartItem> items; allows full access.
            // Items Allows other classes to see the items, but not replace so use: them
            // 'items' camelCase for private same name:
            public List<CartItem> Items => items;
            public void AddItem( CartItem item)
            {
                items.Add(item);
            }
            
            public void RemoveItem(int productId)
            {
                items.RemoveAll(item => item.Product.Id == productId);
            }
            
            public decimal CalTotal ()
            {
                decimal Total = 0;
                foreach (var item in items)
                {
                    Total += item.GetTotal();
                }
                return Total;
            }
        }
}
