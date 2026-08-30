namespace ConsoleApp.Tasks;

public class TaskCancelExample
{
    public async Task Run()
    {
        var httpClient = new HttpClient();

        var cts = new CancellationTokenSource();

        cts.CancelAfter(10000);

        cts.Cancel();
        try
        {
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1", cts.Token);
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}