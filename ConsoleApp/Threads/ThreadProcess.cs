using ConsoleApp.Threads.BasicThreads;
using ConsoleApp.Threads.GracefulShutdown;
using ConsoleApp.Threads.ImageProcessing;
using ConsoleApp.Threads.ThreadPriority;

namespace ConsoleApp.Threads;

public class ThreadProcess
{
    public void Run()
    {
        BasicThreadExample.Run();

        ImageProcessingExample.Run();

        GracefulShotDownExample.RunExample();

        ThreadPriorityExample.Run();
    }
}
