Console.WriteLine("for");

// int count = 0;
// Parallel.For(0, 10, i =>
// {
//     
//     Interlocked.Increment(ref count);
//     Console.WriteLine(i);
// });
//
// var list = Enumerable.Range(1, 10).ToList();
//
//
//
// Parallel.ForEach(list, i =>
//    {
//        Interlocked.Increment(ref count);
//        Console.WriteLine(i);
//    });
//    
//    
// Parallel.ForEach(list,new ParallelOptions(){ MaxDegreeOfParallelism = 3} ,i =>
// {
//     Interlocked.Increment(ref count);
//     Console.WriteLine(i);
// });


// long sum = 0;
// int totalPortition = 0;
//
//
// Parallel.For(0, 1000, () => 0L, (i, loopState, localSum) =>
// {
//     
//     localSum += i;
//     return localSum;
// }, localSum =>
// {
//     Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
//     Interlocked.Add(ref sum, localSum);
//     Interlocked.Increment(ref totalPortition);
// });
//
// Console.WriteLine($"Sum: {sum}, Total Partitions: {totalPortition}");
//
//
//
// try
// {
//     Parallel.For(0, 10, i =>
//     {
//     
//    
//         Console.WriteLine(i);
//     });
//
// }
// catch (AggregateException e)
// {
//     
//     foreach (var exception in e.InnerExceptions)
//     {
//         Console.WriteLine(exception.Message);
//     }
// }
//
//
// ConcurrentBag<Exception> exceptions = new ConcurrentBag<Exception>();
// Parallel.For(0, 10, i =>
// {
//     try
//     {
//         Console.WriteLine(i);
//     }
//     catch (Exception e)
//     {
//        
//         exceptions.Add(e);
//     }
//     
// });
//
//
// foreach (var exception in exceptions)
// {
//     Console.WriteLine(exception.Message);
// }
//
//
// List<int>  numbers=Enumerable.Range(1,100).ToList();
//
//
// numbers.AsParallel().Where(n => n % 2 == 0).ForAll(n =>
// {
//     Console.WriteLine(n);
// });


foreach (var product in GetProducts().Where(p => p.Price > 10))
    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");


foreach (var product in (await GetProductsAsync()).Where(p => p.Price > 10))
    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");

await foreach (var product in GetProductsAsYieldAsync().Where(p => p.Price > 10))
    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");


Console.WriteLine("---------------------------------");
GetProducts().AsParallel().Where(p => p.Price > 10).ForAll(p =>
{
    // httpclient.get
    Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}");
});


List<Product> GetProducts()
{
    var products = new List<Product>
    {
        new(1, "Product 1", 10.99m),
        new(2, "Product 2", 20.49m),
        new(3, "Product 3", 15.75m),
        new(4, "Product 4", 5.99m),
        new(5, "Product 5", 12.50m)
    };

    return products;
}

Task<List<Product>> GetProductsAsync()
{
    var products = new List<Product>
    {
        new(1, "Product 1", 10.99m),
        new(2, "Product 2", 20.49m),
        new(3, "Product 3", 15.75m),
        new(4, "Product 4", 5.99m),
        new(5, "Product 5", 12.50m)
    };

    return Task.FromResult(products);
}

async IAsyncEnumerable<Product> GetProductsAsYieldAsync()
{
    for (var i = 0; i < 10; i++)
    {
        var product = new Product(1, "Product 1", 10.99m);

        yield return product;
    }
}


internal record Product(int Id, string Name, decimal Price);