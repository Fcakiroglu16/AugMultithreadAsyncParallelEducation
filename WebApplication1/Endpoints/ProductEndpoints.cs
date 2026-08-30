namespace WebApplication1.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/products", async (IFormFile file, IWebHostEnvironment environment, CancellationToken cancellationToken) =>
        {
            if (file is null || file.Length == 0)
            {
                return Results.BadRequest("Please provide a non-empty file.");
            }

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
