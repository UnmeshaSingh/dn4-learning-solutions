using System;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}

public class SearchUtility
{
    public static int LinearSearch(Product[] products, string name)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }
        return -1;
    }

    public static int BinarySearch(Product[] products, string name)
    {
        int low = 0, high = products.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int result = string.Compare(products[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);
            if (result == 0)
                return mid;
            else if (result < 0)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }

    public static void PrintSearchResult(int index, Product[] products)
    {
        if (index != -1)
            Console.WriteLine("Found: " + products[index]);
        else
            Console.WriteLine("Product not found.");
    }
}

public class Program
{
    public static void Main()
    {
        Product[] products = {
            new Product(1, "Laptop", "Electronics"),
            new Product(2, "Mobile", "Electronics"),
            new Product(3, "Shoes", "Footwear"),
            new Product(4, "Book", "Education")
        };

        Console.WriteLine("Linear Search:");
        int index = SearchUtility.LinearSearch(products, "Shoes");
        SearchUtility.PrintSearchResult(index, products);

        Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));

        Console.WriteLine("\nBinary Search:");
        index = SearchUtility.BinarySearch(products, "Shoes");
        SearchUtility.PrintSearchResult(index, products);
    }
}
