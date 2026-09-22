using FoodDelivery.Tests.TestData;

namespace FoodDelivery.Tests.Queries;

public class CustomerTests
{
    private readonly FoodDeliveryData _data = new();

    /// <summary>
    /// Проверяет клиентов выбранного ресторана в алфавитном порядке
    /// </summary>
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetRestaurantCustomers(int restaurantId)
    {
        var restaurant = _data.Restaurants
            .Single(item => item.Id == restaurantId);

        var customers = _data.Orders
            .Where(order => order.Restaurant.Id == restaurant.Id)
            .Select(order => order.Customer)
            .Distinct()
            .OrderBy(customer => customer.LastName)
            .ThenBy(customer => customer.FirstName)
            .ThenBy(customer => customer.Patronymic)
            .ToList();

        Assert.NotEmpty(customers);

        var sortedNames = customers
            .Select(customer =>
                $"{customer.LastName} " +
                $"{customer.FirstName} " +
                $"{customer.Patronymic}")
            .ToList();

        var expectedNames = sortedNames
            .OrderBy(name => name)
            .ToList();

        Assert.Equal(expectedNames, sortedNames);
    }
}