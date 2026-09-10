using System.Diagnostics;

namespace _02_ThreadPool_Internals.Exercise1;

public class ThreadPoolLab
{
    public async Task RunIoBoundAsync(int count)
    {
        var tasks = Enumerable.Range(0, count)
            .Select(_ => Task.Delay(500));

        await Task.WhenAll(tasks);
    }

    public async Task RunCpuBoundAsync(int count)
    {
        var tasks = Enumerable.Range(0, count)
            .Select(_ => Task.Run(() =>
            {
                var sw = Stopwatch.StartNew();

                while (sw.ElapsedMilliseconds < 200)
                {
                    // simulate CPU work
                    Math.Sqrt(12345.6789);
                }
            }));

        await Task.WhenAll(tasks);
    }
}