namespace ConsoleApp.Threads.GracefulShutdown;

public class GracefulShotDownExample
{
    public static void Run(string count, GracefulSHotDownState state)
    {
        Enumerable.Range(0, int.Parse(count)).ToList().ForEach(i =>
        {
            if (state.IsProcess)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Processing image:  {i}");
            }
            else
            {
                Console.WriteLine($"Graceful shutdown requested. Stopping processing at image: {i}");
                return;
            }
        });
    }

    public static void RunExample()
    {
        var state = new GracefulSHotDownState { IsProcess = true };

        var thread = new Thread(() => Run("50", state));
        thread.IsBackground = true;
        thread.Start();

        Thread.Sleep(3000);
        state.IsProcess = false;
        thread.Join();
    }
}
