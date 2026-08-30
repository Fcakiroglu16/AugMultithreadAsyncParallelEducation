using System.Collections.Concurrent;

namespace ThreadSafeCollections;




public class ConcurrencyStack
{
    private readonly ConcurrentStack<Product> _stack = new ConcurrentStack<Product>();

    public async Task Run()
    {
        
        
        var threads = new List<Thread>();


        foreach (var i in Enumerable.Range(1, 2).ToList())
        {
            var thread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    var product = new Product(i, $"Product {i}", i * 10);
                    
                    _stack.Push(product);
                }
            });
            threads.Add(thread);
        }


        foreach (var thread in threads) thread.Start();
        foreach (var thread in threads) thread.Join();


        
        
        List<Task> consumer = new();


        var task = Task.Run(() =>
        {
            
            while (true)
            {
                
                if (_stack.TryPop(out var item))
                    Console.WriteLine($"Took item: {item},thread :{Thread.CurrentThread.ManagedThreadId}");
            }
             
        });

        var task2 = Task.Run(() =>
        {
            while (true)
            {
                if (_stack.TryPop(out var item))
                    Console.WriteLine($"Took item: {item},thread :{Thread.CurrentThread.ManagedThreadId}");
            }
         
        });
        consumer.Add(task);
        consumer.Add(task2);


        await Task.WhenAll(consumer);
        
        
        
        
        
        
    }
    
}