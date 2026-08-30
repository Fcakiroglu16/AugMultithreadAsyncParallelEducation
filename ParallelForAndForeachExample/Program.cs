Console.WriteLine("for");

int count = 0;
Parallel.For(0, 10, i =>
{
    
    Interlocked.Increment(ref count);
    Console.WriteLine(i);
});

var list = Enumerable.Range(1, 10).ToList();



Parallel.ForEach(list, i =>
   {
       Interlocked.Increment(ref count);
       Console.WriteLine(i);
   });