namespace _01_Shared_State_and_Race_Conditions.Bad;

public class OrderProcessor
{
    private int _processedCount;
    private readonly List<int> _processedIds = new();

    public async Task ProcessOrdersAsync(IEnumerable<int> orderIds)
    {
        var tasks = orderIds.Select(async orderId =>
        {
            await Task.Delay(Random.Shared.Next(10, 50)); // simulate I/O

            _processedCount++;
            _processedIds.Add(orderId);
        });

        await Task.WhenAll(tasks);
    }

    public int ProcessedCount => _processedCount;
    public IReadOnlyList<int> ProcessedIds => _processedIds;
}