using FoodDelivery.Tests.TestData;

namespace FoodDelivery.Tests.Queries;

public class SpendingTests
{
    private readonly FoodDeliveryData _data = new();

    /// <summary>
    /// Проверяет клиента с наибольшей суммой заказов за всё время
    /// </summary>
    [Fact]
    public void GetCustomerWithMaximumSpending()
    {
        var customer = _data.Orders
            .GroupBy(order => order.Customer)
            .Select(group => new
            {
                Customer = group.Key,
                TotalAmount = group.Sum(order => order.TotalAmount)
            })
            .OrderByDescending(item => item.TotalAmount)
            .First();

        Assert.Equal("Иванов", customer.Customer.LastName);
        Assert.Equal("Иван", customer.Customer.FirstName);
        Assert.Equal(6080m, customer.TotalAmount);
    }
}