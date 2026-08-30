namespace ConsoleApp.MutexExample;

public class MutexExample
{
    private int count;
    private readonly Mutex mutex = new();

    public void Run()
    {
        List<Thread> threads = new();
        for (var i = 0; i < 5; i++)
        {
            var thread = new Thread(Increase);
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads) thread.Join();

        Console.WriteLine(count);
    }

    public void Increase()
    {
        mutex.WaitOne();
        try
        {
            for (var i = 0; i < 100000; i++) count++;
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
}