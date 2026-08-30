namespace ConsoleApp.Tasks;

public class TaskMethods
{
    public IEnumerable<int> GetNumbers()
    {
        var numbers = Enumerable.Range(1, 100);

        return numbers;
    }

    public IEnumerable<int> GetYieldNumbers()
    {
        for (var i = 0; i < 10; i++) yield return i;
    }


    public void RunYield()
    {
        foreach (var number in GetYieldNumbers()) Console.WriteLine(number);
    }

    public async Task Run()
    {
        var httpClient = new HttpClient();
        var httpMesasge1 = httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

        var httpMessage2 = httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");


        var whenAllResult = await Task.WhenAll(httpMesasge1, httpMessage2);


        var firstTask = await Task.WhenAny(httpMesasge1, httpMessage2);


        await foreach (var responseMessageAsTask in Task.WhenEach(httpMesasge1, httpMessage2))
            if (responseMessageAsTask.IsCompletedSuccessfully)
            {
                var response = responseMessageAsTask.Result;
            }
            else
            {
                Console.WriteLine(responseMessageAsTask.Exception);
            }

        Task.WaitAll(httpMesasge1, httpMessage2);
    }
}