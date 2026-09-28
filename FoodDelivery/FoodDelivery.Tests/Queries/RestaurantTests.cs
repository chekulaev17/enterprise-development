using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests.Queries;

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
            .CountBy(order => order.Restaurant.Id)
            .OrderByDescending(item => item.Value)
            .ThenBy(item =>
                data.Restaurants.Single(r => r.Id == item.Key).Name)
            .Take(5)
            .Select(item => new
            {
                Name = data.Restaurants.Single(r => r.Id == item.Key).Name,
                Count = item.Value
            })
            .ToList();

        var expected = new (string Name, int Count)[]
        {
            ("Вкусно рядом", 6),
            ("Городская кухня", 5),
            ("Дом еды", 5),
            ("Пицца Хаус", 5),
            ("Суши Тайм", 5)
        };

        Assert.Equal(expected.Length, restaurants.Count);

        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i].Name, restaurants[i].Name);
            Assert.Equal(expected[i].Count, restaurants[i].Count);
        }
    }
}