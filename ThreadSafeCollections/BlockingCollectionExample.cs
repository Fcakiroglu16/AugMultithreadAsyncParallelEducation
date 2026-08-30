using System.Collections.Concurrent;

namespace ThreadSafeCollections;

public class BlockingCollectionExample
{
    private readonly BlockingCollection<Product> _blockingCollection = new BlockingCollection<Product>(100);

    public async Task Run()
    {
     

        List<Task> consumer = new();

        var producerThread1 = new Thread(() =>
        {
            foreach (var product in _blockingCollection.GetConsumingEnumerable())
            {
                Console.WriteLine($"Took item: {product},thread :{Thread.CurrentThread.ManagedThreadId}");
            }


        });
        var producerThread2 = new Thread(() =>
        {
            foreach (var product in _blockingCollection.GetConsumingEnumerable())
            {
                Console.WriteLine($"Took item: {product},thread :{Thread.CurrentThread.ManagedThreadId}");
            }


        });
     

        producerThread1.Start();
        producerThread2.Start();
    
        
        var threads = new List<Thread>();

        foreach (var i in Enumerable.Range(1, 20).ToList())
        {
            var thread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    var product = new Product(i, $"Product {i}", i * 10);
                    
                    _blockingCollection.Add(product);
                    Console.WriteLine($"Added item from thread {Thread.CurrentThread.ManagedThreadId},i ={i}");
                    
                }
            });
            threads.Add(thread);
        }

        foreach (var thread in threads) thread.Start();
        foreach (var thread in threads) thread.Join();

        Console.ReadLine();

    }
}