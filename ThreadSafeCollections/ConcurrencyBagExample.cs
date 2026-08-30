using System.Collections.Concurrent;

namespace ThreadSafeCollections;

public class ConcurrencyBagExample
{
    public async Task Run()
    {
        var bag = new ConcurrentBag<string>();

        var threads = new List<Thread>();


        foreach (var i in Enumerable.Range(1, 10).ToList())
        {
            var thread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    bag.Add($"Item from thread {Thread.CurrentThread.ManagedThreadId},i ={i}");
                    Console.WriteLine($"Added item from thread {Thread.CurrentThread.ManagedThreadId},i ={i}");
                }
            });
            threads.Add(thread);
        }


        foreach (var thread in threads) thread.Start();
        foreach (var thread in threads) thread.Join();


        List<Task> consumer = new();
        for (var i = 0; i < 3; i++)
        {
            var task = Task.Run(() =>
            {
                while (!bag.IsEmpty)
                    if (bag.TryTake(out var item))
                        Console.WriteLine($"Took item: {item},thread :{Thread.CurrentThread.ManagedThreadId}");
            });
            consumer.Add(task);
        }

        await Task.WhenAll(consumer);

        // Take items from the bag
    }
}