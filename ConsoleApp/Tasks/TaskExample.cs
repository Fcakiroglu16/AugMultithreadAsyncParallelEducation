using System.Diagnostics;

namespace ConsoleApp.Tasks;

public class TaskExample
{

    public void Run()
    {
        Thread t1= new Thread(()=>{Console.WriteLine("Thread 1 running");});
        t1.Start();
        
        Task task = new Task(() => { Console.WriteLine("Task 2 running"); });
        task.Start();
        Task task2 = new Task(() => { Console.WriteLine("Task 3 running"); });
        task2.Start();
        
        Task.Run(()=> { Console.WriteLine("Task 4 running"); });
        
        Task.Factory.StartNew(() => { Console.WriteLine("Task 5 running"); });
        Task.Factory.StartNew(() => { Console.WriteLine("Task 5 running"); }, TaskCreationOptions.LongRunning);
    }
}