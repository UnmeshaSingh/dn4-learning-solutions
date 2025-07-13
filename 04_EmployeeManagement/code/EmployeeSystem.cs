using System;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string name, string position, double salary)
    {
        EmployeeId = id;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: ₹{Salary}";
    }
}

public class EmployeeSystem
{
    private Employee[] employees = new Employee[100];
    private int count = 0;

    public void AddEmployee(Employee employee)
    {
        if (count < employees.Length)
        {
            employees[count++] = employee;
            Console.WriteLine("Employee added.");
        }
        else
        {
            Console.WriteLine("Employee list is full.");
        }
    }

    public void SearchEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                Console.WriteLine("Found: " + employees[i]);
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }

    public void TraverseEmployees()
    {
        Console.WriteLine("All Employees:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(employees[i]);
        }
    }

    public void DeleteEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                for (int j = i; j < count - 1; j++)
                {
                    employees[j] = employees[j + 1];
                }
                count--;
                Console.WriteLine("Employee deleted.");
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }
}

public class Program
{
    public static void Main()
    {
        EmployeeSystem system = new EmployeeSystem();

        system.AddEmployee(new Employee(1, "Alice", "Manager", 70000));
        system.AddEmployee(new Employee(2, "Bob", "Engineer", 50000));
        system.AddEmployee(new Employee(3, "Charlie", "Analyst", 45000));

        system.TraverseEmployees();

        system.SearchEmployee(2);

        system.DeleteEmployee(2);

        system.TraverseEmployees();
    }
}
