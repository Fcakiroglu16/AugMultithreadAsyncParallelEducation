namespace ConsoleApp.RaceCondition;

public class RaceConditionExample
{
    public void Run()
    {
        var product = new Product();

        var Thread1 = new Thread(() => IncrementCounter(product));

        var Thread2 = new Thread(() => IncrementCounter(product));


        Thread1.Start();
        Thread2.Start();

        Thread1.Join();
        Thread2.Join();

        Console.WriteLine($"Final Count: {product.Count}");
    }

    private static void IncrementCounter(Product product)
    {
        foreach (var i in Enumerable.Range(1, 1000).ToList())
        {
            Console.WriteLine($"Thread Id :{Thread.CurrentThread.ManagedThreadId}");
            product.Count = product.Count + 1;
        }
    }

    public class Product
    {
        public int Count { get; set; }
    }
}