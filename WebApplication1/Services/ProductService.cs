using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Models;

namespace WebApplication1.Services;






public class ProductService(IMemoryCache memoryCache)
{

    public async Task<bool> MakeRequest()
    {
        
        var response= await new HttpClient().GetAsync("https://jsonplaceholder.typicode.com/todos/1");
        return response.IsSuccessStatusCode;
    }
    
    public  Task<int> GetNumber()
    {
        int i = 10;
        return Task.FromResult(i);
    }
    
    public   Task  DoSomething()
    {
        var i = 10;

        return Task.CompletedTask;
    }
    public  ValueTask<int> GetNumber2()
    {
        
        return ValueTask.FromResult(1);
    }
    
    public ValueTask<Product> GetProduct(int productId)
    {
        
        if(memoryCache.TryGetValue(productId, out Product product))
        {
            return ValueTask.FromResult(product!);
        }
        else
        {
            product= new Product("Product", 10); // dbContext.Produt.get
            memoryCache.Set(productId, product, TimeSpan.FromMinutes(5));
            return ValueTask.FromResult(product!);
        }
        
        
   
        
        
    }
}