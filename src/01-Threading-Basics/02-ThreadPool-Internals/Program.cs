using _02_ThreadPool_Internals.Exercise1;
using _02_ThreadPool_Internals.Exercise2;

// // Run Exercise1
// await ThreadPoolTest.RunAsync(200);
// await ThreadPoolTest.RunAsync(1000);
// await ThreadPoolTest.RunAsync(5000);

Console.WriteLine($"PID: {Environment.ProcessId}");
Console.WriteLine("Press Enter to continue...");
Console.ReadLine();

await StarvationTest.RunAsync();
