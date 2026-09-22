using FoodDelivery.Tests.TestData;

namespace FoodDelivery.Tests.Queries;

public class DeliveryTests
{
    private readonly FoodDeliveryData _data = new();

    /// <summary>
    /// Проверяет заказы с минимальным временем доставки
    /// </summary>
    [Fact]
    public void GetOrdersWithMinimumDeliveryTime()
    {
        var minimumTime = _data.Orders
            .Min(order => order.DeliveredAt - order.CreatedAt);

        var orders = _data.Orders
            .Where(order =>
                order.DeliveredAt - order.CreatedAt == minimumTime)
            .ToList();

        Assert.NotEmpty(orders);

        Assert.All(
            orders,
            order => Assert.Equal(
                minimumTime,
                order.DeliveredAt - order.CreatedAt));
    }
}