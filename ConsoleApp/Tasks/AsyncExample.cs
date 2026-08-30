namespace ConsoleApp.Tasks;

public class AsyncExample
{
    public AsyncExample()
    {
        var response = MakeHttpRequest().Result;
    }


    public async Task<int> Run5()
    {
        MakeHttpRequest().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Console.WriteLine("Error occurred: " + task.Exception?.Message);
            }
            else
            {
                var response = task.Result;
                Console.WriteLine("HTTP request completed successfully: " + response);
            }
        });

        var i = 10;

        return i;
    }

    public async Task RunExample()
    {
        var response = await MakeHttpRequest();
    }


    public async Task Run()
    {
        //main
        // textbox.text
        var response = MakeHttpRequest();


        var i = 10;

        var ii = 20;

        var iii = i / ii;
    }


    public async Task<bool> MakeHttpRequest()
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

        return response.IsSuccessStatusCode;
    }

    public async Task MakeHttpRequest2()
    {
        var httpClient = new HttpClient();


        var response = httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1"); //2sn

        var response2 = httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/2"); //2sn
        var response3 = httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/3"); //2sn


        var result = await Task.WhenAll(response, response2, response3); //1sn
    }
}