namespace ConsoleApp.Threads.ImageProcessing;

public class ImageProcessingExample
{
    public static void Run()
    {
        Enumerable.Range(1, 5).ToList().ForEach(i =>
        {
            Thread thread = new Thread(() => ImageProcessor.ProcessImage($"thread {i}", "dimension"));
            thread.IsBackground = true;
            thread.Start();
            thread.Join();
        });
    }
}
