using System.Diagnostics;

namespace _02_ThreadPool_Internals.Exercise2;

public static class StarvationTest
{
    public static async Task RunAsync()
    {
        const int blockingCount = 200;
        const int asyncCount = 500;

        Console.WriteLine("Starvation started...\n");

        var sw = Stopwatch.StartNew();

        StarvationLab lab = new();
        await lab.RunAsync(blockingCount, asyncCount);

        sw.Stop();

        Console.WriteLine("Total time: {0:F2} seconds", sw.Elapsed.TotalSeconds);
    }
}