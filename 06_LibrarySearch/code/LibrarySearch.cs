using System;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(int id, string title, string author)
    {
        BookId = id;
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return $"Book ID: {BookId}, Title: {Title}, Author: {Author}";
    }
}

public class LibrarySystem
{
    public static Book LinearSearch(Book[] books, string title)
    {
        foreach (var book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                return book;
        }
        return null;
    }

    public static Book BinarySearch(Book[] books, string title)
    {
        int low = 0, high = books.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparison = string.Compare(books[mid].Title, title, StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
                return books[mid];
            else if (comparison < 0)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return null;
    }

    public static void PrintBooks(Book[] books)
    {
        Console.WriteLine("Book List:");
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        Book[] books = {
            new Book(1, "Algorithms", "CLRS"),
            new Book(2, "Design Patterns", "Gamma"),
            new Book(3, "Operating Systems", "Tanenbaum"),
            new Book(4, "Software Engineering", "Pressman")
        };

        Array.Sort(books, (a, b) => a.Title.CompareTo(b.Title));
        LibrarySystem.PrintBooks(books);

        var foundLinear = LibrarySystem.LinearSearch(books, "Operating Systems");
        Console.WriteLine("Linear Search Result: " + (foundLinear != null ? foundLinear.ToString() : "Not Found"));

        var foundBinary = LibrarySystem.BinarySearch(books, "Operating Systems");
        Console.WriteLine("Binary Search Result: " + (foundBinary != null ? foundBinary.ToString() : "Not Found"));
    }
}
