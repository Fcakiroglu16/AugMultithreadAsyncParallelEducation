namespace ConsoleApp;

public class MonitorExample
{
    private readonly object lockObject = new();
    private int count;
    private string? message;

    public void Run()
    {
        var t1 = new Thread(Increment);
        var t2 = new Thread(Increment);
        var t3 = new Thread(Increment);
        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine("Final Count: " + count);
    }


    public void Increment()
    {
        Monitor.Enter(lockObject);
        try
        {
            for (var i = 0; i < 100000; i++) count++;

            Console.WriteLine($"Current Count: {count}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }
        finally
        {
            Monitor.Exit(lockObject);
        }
    }

    public void IncrementNoThreadSafe()
    {
        for (var i = 0; i < 100000; i++) count++;

        Console.WriteLine($"Current Count: {count}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
    }


    public void WaitPulse()
    {
        message = null;

        var consumer = new Thread(() =>
        {
            lock (lockObject)
            {
                Console.WriteLine("1. işlem lock'ı  aldı");
                while (message == null) Monitor.Wait(lockObject);

                Console.WriteLine("uyandım");
            }
        });
        consumer.Start();

        Thread.Sleep(3000);
        lock (lockObject)
        {
            Console.WriteLine("2. işlem lock'ı aldım.");
            message = "Hello";
            Monitor.Pulse(lockObject);
        }

        consumer.Join();

        Console.ReadLine();
    }
}