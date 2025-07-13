using System;
using System.Collections.Generic;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, int quantity, double price)
    {
        ProductId = id;
        ProductName = name;
        Quantity = quantity;
        Price = price;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Quantity: {Quantity}, Price: ₹{Price}";
    }
}

public class Inventory
{
    private Dictionary<int, Product> products = new Dictionary<int, Product>();

    public void AddProduct(Product product)
    {
        products[product.ProductId] = product;
        Console.WriteLine($"Product {product.ProductName} added.");
    }

    public void UpdateProduct(int id, int newQuantity, double newPrice)
    {
        if (products.ContainsKey(id))
        {
            products[id].Quantity = newQuantity;
            products[id].Price = newPrice;
            Console.WriteLine($"Product {id} updated.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void DeleteProduct(int id)
    {
        if (products.Remove(id))
        {
            Console.WriteLine($"Product {id} deleted.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void ShowInventory()
    {
        Console.WriteLine("Inventory:");
        foreach (var product in products.Values)
        {
            Console.WriteLine(product);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Inventory inventory = new Inventory();

        inventory.AddProduct(new Product(101, "Laptop", 10, 60000));
        inventory.AddProduct(new Product(102, "Mouse", 50, 500));

        inventory.ShowInventory();

        inventory.UpdateProduct(101, 8, 58000);

        inventory.DeleteProduct(102);

        inventory.ShowInventory();
    }
}
