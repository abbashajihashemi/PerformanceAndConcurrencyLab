namespace _01_Shared_State_and_Race_Conditions.Good;

public class OrderProcessor
{
    private int _processedCount;
    private readonly List<int> _processedIds = [];
    private readonly object _lock = new();

    public async Task ProcessOrdersAsync(IEnumerable<int> orderIds)
    {
        var tasks = orderIds.Select(async orderId =>
        {
            await Task.Delay(Random.Shared.Next(10, 50)); // simulate I/O

            lock (_lock)
            {
                _processedCount++;
                _processedIds.Add(orderId);
            }
        });

        await Task.WhenAll(tasks);
    }

    public int ProcessedCount
    {
        get
        {
            lock (_lock)
            {
                return _processedCount;
            }
        }
    }

    public IReadOnlyList<int> ProcessedIds
    {
        get
        {
            lock (_lock)
            {
                return _processedIds;
            }
        }
    }
}