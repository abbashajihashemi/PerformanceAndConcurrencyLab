using System.Diagnostics;

namespace _02_ThreadPool_Internals.Exercise1;

public class ThreadPoolTest
{
    public static async Task RunAsync(int count)
    {
        var lab = new ThreadPoolLab();

        var sw = Stopwatch.StartNew();

        sw.Start();
        Console.WriteLine("Running I/O Bound with 200");
        await lab.RunIoBoundAsync(count);

        sw.Stop();
        Console.WriteLine($"Total time for I/O Bound: {sw.Elapsed.TotalSeconds:F2} seconds");

        sw.Restart();

        Console.WriteLine("Running CPU Bound with 200");
        await lab.RunCpuBoundAsync(count);

        sw.Stop();
        Console.WriteLine($"Total time for CPU Bound: {sw.Elapsed.TotalSeconds:F2} seconds");
    }
}