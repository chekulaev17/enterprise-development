using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests.Queries;

public class SpendingTests(FoodDeliveryData data)
    : IClassFixture<FoodDeliveryData>
{
    /// <summary>
    /// Проверяет клиента с наибольшей суммой заказов за всё время
    /// </summary>
    [Fact]
    public void GetCustomerWithMaximumSpending()
    {
        var customer = data.Orders
            .GroupBy(order => order.Customer)
            .Select(group => new
            {
                Customer = group.Key,
                TotalAmount = group.Sum(order => order.TotalAmount)
            })
            .OrderByDescending(item => item.TotalAmount)
            .ThenBy(item => item.Customer.Id)
            .First();

        Assert.Equal("Смирнова", customer.Customer.LastName);
        Assert.Equal("Анна", customer.Customer.FirstName);
        Assert.Equal("Викторовна", customer.Customer.Patronymic);
        Assert.Equal(2820m, customer.TotalAmount);
    }
}