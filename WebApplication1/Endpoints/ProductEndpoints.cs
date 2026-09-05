using System.Collections.Concurrent;
using System.Threading.Channels;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/products/batch-insert",
            async (List<Product> products) =>
            {
                if (products.Count > 1000)
                    return Results.BadRequest("Batch insert limit exceeded. Maximum allowed is 1000 products.");

                var productQueue = new BlockingCollection<Product>(1000);


                var process = new List<Task>();

                for (var i = 0;
                     i < 5;
                     i++)
                {
                    var task = Task.Run(() =>
                    {
                        foreach (var product in productQueue.GetConsumingEnumerable())
                        {
                            // Simulate processing time
                            Thread.Sleep(100);
                            Console.WriteLine($"Processed Product: {product.Name}");
                        }
                    });
                    process.Add(task);
                }


                foreach (var product in products) productQueue.Add(product);

                productQueue.CompleteAdding();


                await Task.WhenAll(process);

                return Results.Ok();
            });

        app.MapPost("/api/products/batch-insert-with-channel",
            async ([FromBody] List<Product> products, [FromServices] Channel<Product> productQueue) =>
            {
                
                
                
                if (products.Count > 1000)
                    return Results.BadRequest("Batch insert limit exceeded. Maximum allowed is 1000 products.");


                var process = new List<Task>();

                for (var i = 0;
                     i < 5;
                     i++)
                {
                    var task = Task.Run(async () =>
                    {
                        await foreach (var product in productQueue.Reader.ReadAllAsync())
                        {
                            // Simulate processing time
                            await Task.Delay(100);
                            Console.WriteLine($"Processed Product: {product.Name}");
                        }
                    });
                    process.Add(task);
                }


                foreach (var product in products) await productQueue.Writer.WriteAsync(product);

                productQueue.Writer.Complete();


                await Task.WhenAll(process);

                return Results.Ok();
            });
        app.MapPost("/api/products",
            async (IFormFile file, IWebHostEnvironment environment, CancellationToken cancellationToken) =>
            {
                if (file is null || file.Length == 0) return Results.BadRequest("Please provide a non-empty file.");

                var uploadsFolder = Path.Combine(environment.ContentRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var safeFileName = Path.GetFileName(file.FileName);
                var storedFileName = $"{Guid.NewGuid():N}_{safeFileName}";
                var fullPath = Path.Combine(uploadsFolder, storedFileName);

                await using var stream = File.Create(fullPath);
                await file.CopyToAsync(stream, cancellationToken);

                return Results.Ok(new
                {
                    originalFileName = safeFileName,
                    storedFileName,
                    size = file.Length,
                    contentType = file.ContentType
                });
            });
    }
}