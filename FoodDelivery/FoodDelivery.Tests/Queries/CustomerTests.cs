using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests.Queries;

/// <summary>
/// Тесты запросов по клиентам
/// </summary>
public class CustomerTests(FoodDeliveryData data)
    : IClassFixture<FoodDeliveryData>
{
    /// <summary>
    /// Проверяет клиентов выбранного ресторана, упорядоченных по ФИО
    /// </summary>
    [Theory]
    [InlineData(1, new[] { 1, 4, 2, 6, 3, 5 })]
    [InlineData(4, new[] { 4, 8, 2, 3, 5 })]
    [InlineData(7, new[] { 15, 1 })]
    public void GetRestaurantCustomers(
        int restaurantId,
        int[] expectedCustomerIds)
    {
        var actualCustomerIds = data.Orders
            .Where(order => order.Restaurant.Id == restaurantId)
            .Select(order => order.Customer)
            .DistinctBy(customer => customer.Id)
            .OrderBy(customer => customer.LastName)
            .ThenBy(customer => customer.FirstName)
            .ThenBy(customer => customer.Patronymic)
            .Select(customer => customer.Id)
            .ToArray();

        Assert.Equal(expectedCustomerIds, actualCustomerIds);
    }
}