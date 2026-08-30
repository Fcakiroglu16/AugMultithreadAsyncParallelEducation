namespace ConsoleApp.Threads.ImageProcessing;

public class ImageProcessor
{
    public static void ProcessImage(string imagePath, string dimension)
    {
        // Simulate image processing
        Console.WriteLine($"Processing image: {imagePath} with dimension {dimension}");
        Thread.Sleep(500); // Simulate work
        Console.WriteLine($"Image processed: {imagePath}");
    }
}
