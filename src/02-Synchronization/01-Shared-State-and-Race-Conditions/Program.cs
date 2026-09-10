using System.Diagnostics;

const int count = 5000;
var orderIds = Enumerable.Range(1, count);

// var orderProcessor = new _01_Shared_State_and_Race_Conditions.Bad.OrderProcessor();
// var orderProcessor = new _01_Shared_State_and_Race_Conditions.Good.OrderProcessor();
var orderProcessor = new _01_Shared_State_and_Race_Conditions.Good.InterlockedOrderProcessor();

var sw = new Stopwatch();

Console.WriteLine("Starting with count {0}...", count);

sw.Start();
await orderProcessor.ProcessOrdersAsync(orderIds);

sw.Stop();

Console.WriteLine($"Total time: {sw.Elapsed.TotalSeconds:F2} seconds");
Console.WriteLine("Processed orders count: {0}", orderProcessor.ProcessedCount);
Console.WriteLine("ProcessedIds count: {0}", orderProcessor.ProcessedIds.Count);
