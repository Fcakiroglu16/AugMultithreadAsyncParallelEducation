namespace ConsoleApp.LockExample;

public class LockExample
{
    private readonly Lock _lockObject = new();

    private int Count { get; set; }

    public async Task Run()
    {
        List<Task> tasks = new();
        for (var i = 0; i < 5; i++) tasks.Add(Task.Run(Increase));

        await Task.WhenAll(tasks.ToArray());
        Console.WriteLine($"Final Count: {Count}");
    }

    public void Increase()
    {
        using (_lockObject.EnterScope())
        {
            for (var i = 0; i < 100; i++) Count++;
            Console.WriteLine($"Current Count: {Count}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }

        /*
        _lockObject.Enter();
        try
        {
            for (var i = 0; i < 100; i++) Count++;
            Console.WriteLine($"Current Count: {Count}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }
        finally
        {
            LockObject.Exit();
        }
        */
    }
}