using System.Collections.Concurrent;

namespace ThreadSafeCollections;

public sealed record Order(int UserId, int ProductId);

public class ConcurrencyDictionaryExample
{
    public async Task Run()
    {
        var concurrentDictionary = new ConcurrentDictionary<int, Order>();

        
      
        
        var threads = new List<Thread>();


        foreach (var i in Enumerable.Range(1, 10).ToList())
        {
            var thread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                   var result= concurrentDictionary.TryAdd(i, new Order(i, i));
                   
                   if(result)
                    Console.WriteLine($"Added item from thread {Thread.CurrentThread.ManagedThreadId},i ={i}");
                }
            });
            threads.Add(thread);
        }


        foreach (var thread in threads) thread.Start();
        foreach (var thread in threads) thread.Join();


        List<Task> consumer = new();


        var task = Task.Run(() =>
        {
            for (var i = 0; i < 10; i++)
                if (concurrentDictionary.TryRemove(i, out var item))
                    Console.WriteLine($"Took item: {item},thread :{Thread.CurrentThread.ManagedThreadId}");
        });

        var task2 = Task.Run(() =>
        {
            for (var i = 0; i < 10; i++)
                if (concurrentDictionary.TryRemove(i, out var item))
                    Console.WriteLine($"Took item: {item},thread :{Thread.CurrentThread.ManagedThreadId}");
        });
        consumer.Add(task);
        consumer.Add(task2);


        await Task.WhenAll(consumer);
    }
}