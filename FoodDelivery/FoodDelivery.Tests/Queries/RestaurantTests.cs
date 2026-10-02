using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests.Queries;

/// <summary>
/// Тесты запросов по ресторанам
/// </summary>
public class RestaurantTests(FoodDeliveryData data)
    : IClassFixture<FoodDeliveryData>
{
    /// <summary>
    /// Проверяет пять ресторанов с наибольшим количеством заказов
    /// </summary>
    [Fact]
    public void GetTopFiveRestaurants()
    {
        var restaurants = data.Orders
            .GroupBy(order => order.Restaurant)
            .Select(group => (
                RestaurantId: group.Key.Id,
                OrderCount: group.Count()))
            .OrderByDescending(item => item.OrderCount)
            .ThenBy(item => item.RestaurantId)
            .Take(5)
            .ToArray();

        var expected = new[]
        {
            (RestaurantId: 1, OrderCount: 6),
            (RestaurantId: 5, OrderCount: 6),
            (RestaurantId: 2, OrderCount: 5),
            (RestaurantId: 3, OrderCount: 5),
            (RestaurantId: 4, OrderCount: 5)
        };

        Assert.Equal(expected, restaurants);
    }
}