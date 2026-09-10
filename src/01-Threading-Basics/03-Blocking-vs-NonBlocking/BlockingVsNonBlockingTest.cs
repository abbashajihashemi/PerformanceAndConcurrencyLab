using System.Diagnostics;

namespace _03_Blocking_vs_NonBlocking;

public static class BlockingVsNonBlockingTest
{
    public static Task TestBlockingVersion(int count) =>
        RunTest("Blocking", count, lab => lab.RunBlockingVersion(count));

    public static Task TestNonBlockingVersion(int count) =>
        RunTest("Non-Blocking", count, lab => lab.RunNonBlockingVersion(count));

    private static async Task RunTest(string label, int count, Func<BlockingVsNonBlockingLab, Task> action)
    {
        Console.WriteLine("Starting {0} Test", label);

        var lab = new BlockingVsNonBlockingLab();
        var sw = Stopwatch.StartNew();

        await action(lab);

        sw.Stop();

        Console.WriteLine("Finished {0} Test, Total Time: {1}", label, sw.Elapsed);
    }
}