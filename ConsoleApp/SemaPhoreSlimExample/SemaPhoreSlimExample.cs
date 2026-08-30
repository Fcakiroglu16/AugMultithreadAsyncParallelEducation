namespace ConsoleApp.SemaPhoreSlimExample;

public class SemaPhoreSlimExample
{
    private readonly SemaphoreSlim limitSemiPhore = new(5);


    public void Run()
    {
        var tasks = new List<Task>();


        for (var i = 0; i < 20; i++)
        {
            var work = $"Work-{i + 1}";
            tasks.Add(Task.Run(() => Calculate(work)));
        }

        Task.WaitAll(tasks.ToArray());
    }


    public void Calculate(string work)
    {
        limitSemiPhore.Wait();
        try
        {
            Console.WriteLine($"Processing work: {work}");
            Thread.Sleep(500);
            Console.WriteLine($"Finished processing work: {work}");
        }
        finally
        {
            limitSemiPhore.Release();
        }
    }
}