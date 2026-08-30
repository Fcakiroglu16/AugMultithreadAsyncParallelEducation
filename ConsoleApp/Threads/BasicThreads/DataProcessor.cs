namespace ConsoleApp.Threads.BasicThreads;

public class DataProcessor
{
    public static void RunHeavyTask(string threadName)
    {
        // Simulate a heavy task
        Console.WriteLine($"Running heavy task on {threadName}...");
        Thread.Sleep(1000); // Simulate work
        // File I/O operation
        // Database operation
        // Network operation
        new HttpClient().GetAsync("https://www.google.com");
        Console.WriteLine($"Heavy task on {threadName} completed.");
    }
}
