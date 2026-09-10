namespace _03_Blocking_vs_NonBlocking;

public class BlockingVsNonBlockingLab
{
    public async Task RunBlockingVersion(int count)
    {
        var tasks = Enumerable.Range(0, count)
            .Select(_ => Task.Run(() => Thread.Sleep(1000)));

        await Task.WhenAll(tasks);
    }

    public async Task RunNonBlockingVersion(int count)
    {
        var tasks = Enumerable.Range(0, count)
            .Select(_ => Task.Delay(1000));

        await Task.WhenAll(tasks);
    }
}