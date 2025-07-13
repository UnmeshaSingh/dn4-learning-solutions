using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory.Lab6to7
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            var filtered = await context.Products
                .Where(p => p.Price > 1000)
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            Console.WriteLine("Filtered & Sorted Products:");
            foreach (var product in filtered)
            {
                Console.WriteLine($"{product.Name} - Rs.{product.Price}");
            }

            Console.WriteLine("\nProjected DTOs:");

            var productDTOs = await context.Products
                .Select(p => new
                {
                    p.Name,
                    p.Price
                })
                .ToListAsync();

            foreach (var dto in productDTOs)
            {
                Console.WriteLine($"{dto.Name} - Rs.{dto.Price}");
            }
        }
    }
}
