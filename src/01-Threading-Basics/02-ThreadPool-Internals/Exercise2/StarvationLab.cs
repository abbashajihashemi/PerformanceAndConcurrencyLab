namespace _02_ThreadPool_Internals.Exercise2;

public class StarvationLab
{
    public async Task RunAsync(int blockingCount, int asyncCount)
    {
        var completedCount = 0;

        var blockingTasks = Enumerable.Range(0, blockingCount)
            .Select(_ => Task.Run(() =>
            {
                Thread.Sleep(3000); // blocking the thread
            }));

        var asyncTasks = Enumerable.Range(0, asyncCount)
            .Select(async _ =>
            {
                await Task.Delay(100);
                var current = Interlocked.Increment(ref completedCount);

                Console.WriteLine($"Async work completed. Count: {current}/{asyncCount}");
            });

        var allTasks = blockingTasks.Concat(asyncTasks);
        await Task.WhenAll(allTasks);
    }
}