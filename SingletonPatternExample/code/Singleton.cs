using System;

public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();

    private Logger()
    {
        Console.WriteLine("Logger initialized.");
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Logger();
            }
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG]: {message}");
    }
}

public class Program
{
    public static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("This is the first log message.");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("This is the second log message.");

        Console.WriteLine($"Are logger1 and logger2 the same instance? " +
            $"{Object.ReferenceEquals(logger1, logger2)}");
    }
}
