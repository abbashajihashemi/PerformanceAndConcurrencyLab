using Microsoft.Extensions.Logging;

namespace _01_Async_Await_Deep_Dive.Exercise1.Bad;

public class OrderService(ILogger<OrderService> logger)
{
    public async Task ProcessOrdersAsync(List<int> orderIds)
    {
        foreach (var orderId in orderIds)
        {
            var order = GetOrderDetails(orderId).Result;
            var inventory = CheckInventory(orderId).GetAwaiter().GetResult();

            if (inventory.Available)
            {
                await UpdateOrderStatus(orderId, "Processing");
                SendNotification(orderId).Wait();
            }
        }
    }

    private async Task<Order> GetOrderDetails(int orderId)
    {
        // Simulation I/O
        await Task.Delay(100);
        return new Order { Id = orderId, Amount = orderId * 100 };
    }

    private async Task<Inventory> CheckInventory(int orderId)
    {
        await Task.Delay(80);
        return new Inventory { Available = true };
    }

    private async Task UpdateOrderStatus(int orderId, string status)
    {
        await Task.Delay(50);
        logger.LogInformation("Order {OrderId} updated to {Status}", orderId, status);
    }

    private async Task SendNotification(int orderId)
    {
        await Task.Delay(30);
        logger.LogInformation("Notification sent for order {OrderId}", orderId);
    }
}