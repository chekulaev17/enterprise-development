using FoodDelivery.Tests.TestData;

namespace FoodDelivery.Tests.Queries;

public class RestaurantTests
{
    private readonly FoodDeliveryData _data = new();

    /// <summary>
    /// Проверяет пять ресторанов с наибольшим количеством заказов
    /// </summary>
    [Fact]
    public void GetTopFiveRestaurants()
    {
        var restaurants = _data.Orders
            .GroupBy(order => order.Restaurant)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key.Name)
            .Take(5)
            .ToList();

        Assert.Equal(5, restaurants.Count);

        Assert.Equal(
            "Вкусно рядом",
            restaurants[0].Key.Name);

        Assert.Equal(6, restaurants[0].Count());

        Assert.Equal(
            "Городская кухня",
            restaurants[1].Key.Name);

        Assert.Equal(5, restaurants[1].Count());

        Assert.Equal(
            "Дом еды",
            restaurants[2].Key.Name);

        Assert.Equal(5, restaurants[2].Count());
    }
}