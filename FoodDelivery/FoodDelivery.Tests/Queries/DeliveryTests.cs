using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests.Queries;

public class DeliveryTests(FoodDeliveryData data)
    : IClassFixture<FoodDeliveryData>
{
    /// <summary>
    /// Проверяет заказы с минимальным временем доставки
    /// </summary>
    [Fact]
    public void GetOrdersWithMinimumDeliveryTime()
    {
        var expectedMinimumTime = TimeSpan.FromMinutes(20);
        var expectedOrderIds = new[] { 4, 12, 19, 24, 30, 36 };

        var minimumTime = data.Orders
            .Min(order => order.DeliveredAt - order.CreatedAt);

        var actualOrderIds = data.Orders
            .Where(order => order.DeliveredAt - order.CreatedAt == expectedMinimumTime)
            .Select(order => order.Id)
            .ToArray();

        Assert.Equal(expectedMinimumTime, minimumTime);
        Assert.Equal(expectedOrderIds, actualOrderIds);
    }
}