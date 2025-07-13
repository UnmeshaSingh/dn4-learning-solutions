using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // 1️⃣ Retrieve All Products
        var products = await context.Products.ToListAsync();
        Console.WriteLine("All Products:");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - Rs{p.Price}");
        }

        // 2️⃣ Find by ID
        var product = await context.Products.FindAsync(1);
        Console.WriteLine($"\nFound by ID: {product?.Name}");

        // 3️⃣ FirstOrDefault with Condition
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"\nExpensive Product: {expensive?.Name}");
    }
}
