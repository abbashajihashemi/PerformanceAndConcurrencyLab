namespace _01_Async_Await_Deep_Dive.Exercise2.Bad;

public class OrderService
{
    public async Task ProcessOrdersAsync(List<int> orderIds)
    {
        var tasks = orderIds.Select(async orderId =>
        {
            var order = await GetOrderDetails(orderId);
            var inventory = await CheckInventory(orderId);

            if (inventory.Available)
            {
                await UpdateOrderStatus(orderId, "Processing");
                await SendNotification(orderId);
            }
        });

        await Task.WhenAll(tasks);
    }

    private async Task<Order> GetOrderDetails(int orderId)
    {
        await Task.Delay(80); // شبیه‌سازی I/O
        return new Order { Id = orderId };
    }

    private async Task<Inventory> CheckInventory(int orderId)
    {
        await Task.Delay(60);
        return new Inventory { Available = true };
    }

    private async Task UpdateOrderStatus(int orderId, string status)
    {
        await Task.Delay(40);
    }

    private async Task SendNotification(int orderId)
    {
        await Task.Delay(30);
    }
}