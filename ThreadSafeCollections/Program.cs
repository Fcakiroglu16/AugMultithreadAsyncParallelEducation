using ThreadSafeCollections;

Console.WriteLine("Concurrency Collection");

/*
var concurrencyBagExample = new ConcurrencyBagExample();
await concurrencyBagExample.Run();
*/

/*
var concurrencyQueueExample = new ConcurrencyQueueExample();
await concurrencyQueueExample.Run();
*/

/*
var queueExample = new ConcurrencyQueueExample();
await queueExample.Run();
*/

/*
var stackExample= new ConcurrencyStack();
await stackExample.Run();
*/

var blockingCollection = new BlockingCollectionExample();
await blockingCollection.Run();

 
