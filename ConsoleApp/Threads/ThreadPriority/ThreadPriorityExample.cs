namespace ConsoleApp.Threads.ThreadPriority;

public class ThreadPriorityExample
{
    public static void Run()
    {
        var threadPriority = new Thread(Process.Run)
        {
            Priority = System.Threading.ThreadPriority.Highest,
        };

        var threadLamdaMethod = new Thread(() =>
        {
        });

        threadPriority.Start();
        threadPriority.Join();
    }
}
