using System;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double TotalPrice { get; set; }

    public Order(int id, string name, double price)
    {
        OrderId = id;
        CustomerName = name;
        TotalPrice = price;
    }

    public override string ToString()
    {
        return $"Order ID: {OrderId}, Customer: {CustomerName}, Total: ₹{TotalPrice}";
    }
}

public class SortingAlgorithms
{
    public static void BubbleSort(Order[] orders)
    {
        int n = orders.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                    var temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                }
            }
        }
    }

    public static void QuickSort(Order[] orders, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(orders, low, high);
            QuickSort(orders, low, pivotIndex - 1);
            QuickSort(orders, pivotIndex + 1, high);
        }
    }

    private static int Partition(Order[] orders, int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice < pivot)
            {
                i++;
                var temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
        }
        var t = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = t;
        return i + 1;
    }

    public static void PrintOrders(Order[] orders, string message)
    {
        Console.WriteLine(message);
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        Order[] orders1 = {
            new Order(1, "Alice", 5500),
            new Order(2, "Bob", 2300),
            new Order(3, "Charlie", 8800),
            new Order(4, "David", 1200)
        };

        Order[] orders2 = (Order[])orders1.Clone();

        SortingAlgorithms.BubbleSort(orders1);
        SortingAlgorithms.PrintOrders(orders1, "Orders sorted by Bubble Sort:");

        SortingAlgorithms.QuickSort(orders2, 0, orders2.Length - 1);
        SortingAlgorithms.PrintOrders(orders2, "Orders sorted by Quick Sort:");
    }
}
