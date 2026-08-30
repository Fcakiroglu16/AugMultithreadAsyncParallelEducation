namespace ConsoleApp.Threads.BasicThreads;

public class BasicThreadExample
{
    public static void Run()
    {
        Thread processorThread = new Thread(() => DataProcessor.RunHeavyTask("thread 1"));
        processorThread.IsBackground = true;

        Thread processorThread2 = new Thread(() => DataProcessor.RunHeavyTask("thread 2"));
        processorThread2.IsBackground = true;

        processorThread.Start();
        processorThread2.Start();

        processorThread.Join(); // await
        processorThread2.Join(); // await
    }
}
