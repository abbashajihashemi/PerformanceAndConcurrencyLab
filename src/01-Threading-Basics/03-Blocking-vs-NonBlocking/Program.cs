using _03_Blocking_vs_NonBlocking;

// 1. get application PID
Console.WriteLine($"PID: {Environment.ProcessId}");

// 2. run this command in PowerShell:
// dotnet-counters monitor --counters System.Runtime[threadpool-thread-count,threadpool-queue-length] -p <PID>

// 3. Press any key to continue
Console.WriteLine("Press any key to continue...\n");
Console.ReadKey();

// await BlockingVsNonBlockingTest.TestBlockingVersion(500);
await BlockingVsNonBlockingTest.TestNonBlockingVersion(500);

Console.ReadKey();