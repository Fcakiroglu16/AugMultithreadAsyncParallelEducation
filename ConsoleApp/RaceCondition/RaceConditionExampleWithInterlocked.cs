namespace ConsoleApp.RaceCondition;

public class RaceConditionExampleWithInterlocked
{
    private int count;
    private string name = "thread";

    public void Run()
    {
        var Thread1 = new Thread(() => IncrementCounter());

        var Thread2 = new Thread(() => IncrementCounter());


        Thread1.Start();
        Thread2.Start();

        Thread1.Join();
        Thread2.Join();

        Console.WriteLine($"Final Count: {count}");
        Console.WriteLine($"Final Name: {name}");
    }

    private void IncrementCounter()
    {
        foreach (var i in Enumerable.Range(1, 100).ToList())
        {
            Console.WriteLine($"Thread Id :{Thread.CurrentThread.ManagedThreadId}");


            // count++;
            Interlocked.Increment(ref count);
            Interlocked.Exchange(ref name, "thread" + i);
        }
    }
}