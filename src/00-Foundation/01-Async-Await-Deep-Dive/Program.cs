using System.Diagnostics;

const int count = 100000000;
var orderIds = Enumerable.Range(1, count).ToList();

// var orderService = new _01_Async_Await_Deep_Dive.Exercise2.Bad.OrderService();
var orderService = new _01_Async_Await_Deep_Dive.Exercise2.Good.OrderService();

Console.WriteLine("Starting with count {0}...", count);

var sw = Stopwatch.StartNew();

await orderService.ProcessOrdersAsync(orderIds);

sw.Stop();

Console.WriteLine($"Total time: {sw.Elapsed.TotalSeconds:F2} seconds");
