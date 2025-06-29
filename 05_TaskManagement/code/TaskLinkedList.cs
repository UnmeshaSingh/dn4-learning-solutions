using System;

public class Task
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public string Status { get; set; }
    public Task Next { get; set; }

    public Task(int id, string name, string status)
    {
        TaskId = id;
        TaskName = name;
        Status = status;
        Next = null;
    }

    public override string ToString()
    {
        return $"Task ID: {TaskId}, Name: {TaskName}, Status: {Status}";
    }
}

public class TaskLinkedList
{
    private Task head;

    public void AddTask(int id, string name, string status)
    {
        Task newTask = new Task(id, name, status);
        if (head == null)
        {
            head = newTask;
        }
        else
        {
            Task current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newTask;
        }
        Console.WriteLine("Task added.");
    }

    public void DeleteTask(int id)
    {
        if (head == null)
        {
            Console.WriteLine("Task list is empty.");
            return;
        }

        if (head.TaskId == id)
        {
            head = head.Next;
            Console.WriteLine("Task deleted.");
            return;
        }

        Task current = head;
        while (current.Next != null && current.Next.TaskId != id)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    public void SearchTask(int id)
    {
        Task current = head;
        while (current != null)
        {
            if (current.TaskId == id)
            {
                Console.WriteLine("Found: " + current);
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("Task not found.");
    }

    public void TraverseTasks()
    {
        Console.WriteLine("All Tasks:");
        Task current = head;
        while (current != null)
        {
            Console.WriteLine(current);
            current = current.Next;
        }
    }
}

public class Program
{
    public static void Main()
    {
        TaskLinkedList taskList = new TaskLinkedList();

        taskList.AddTask(1, "Design UI", "Pending");
        taskList.AddTask(2, "Implement Backend", "In Progress");
        taskList.AddTask(3, "Write Tests", "Pending");

        taskList.TraverseTasks();

        taskList.SearchTask(2);

        taskList.DeleteTask(2);

        taskList.TraverseTasks();
    }
}
