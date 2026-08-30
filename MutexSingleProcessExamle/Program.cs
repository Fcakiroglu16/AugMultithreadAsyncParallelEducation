Console.WriteLine("Hello, World!");

const string mutexName = "Global\\MutexSingleProcessExample";

using var mutex = new Mutex(false, mutexName, out var createdNew);

if (!createdNew)
{
    Console.WriteLine("Another instance is already running. Exiting...");
    return;
}

;

Console.WriteLine("This is the only instance running.");
Console.ReadLine();