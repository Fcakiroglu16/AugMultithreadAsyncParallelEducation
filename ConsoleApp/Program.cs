using ConsoleApp.SemaPhoreSlimExample;

Console.WriteLine("Main Thread");

var semaPhoreSlimExample = new SemaPhoreSlimExample();

semaPhoreSlimExample.Run();


//var mutexExample = new MutexExample();

//mutexExample.Run();


//LockExample lockExample= new LockExample();
//await lockExample.Run();


//var monitorExample = new MonitorExample();

//monitorExample.WaitPulse();


// RaceConditionExample raceConditionExample = new RaceConditionExample();
//
// raceConditionExample.Run();

// RaceConditionExampleWithInterlocked raceConditionExampleWithInterlocked = new RaceConditionExampleWithInterlocked();
//
// raceConditionExampleWithInterlocked.Run();
;


// var asyncExample = new AsyncExample();
//
// var successful = await asyncExample.MakeHttpRequest();


// TaskExample task = new TaskExample();
//
// task.Run();

// ThreadProcess threadProcess = new ThreadProcess();
//
// threadProcess.Run();
//
// var thread = new Thread(() =>
// {
// //File Operation
//
// });
// var thread2 = new Thread(() =>
// {
// //Network Operation
//
// });
// thread.Start();
// thread2.Start();
//
//
// Console.WriteLine("Main thread continues...");