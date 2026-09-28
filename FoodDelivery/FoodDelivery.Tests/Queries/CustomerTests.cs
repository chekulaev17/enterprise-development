using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests.Queries;

public class CustomerTests(FoodDeliveryData data)
    : IClassFixture<FoodDeliveryData>
{
    /// <summary>
    /// Проверяет клиентов выбранного ресторана в алфавитном порядке по ФИО
    /// </summary>
    [Theory]
    [InlineData(1, new string[]
    {
        "Иванов Иван Петрович",
        "Кузнецов Дмитрий Сергеевич",
        "Петров Алексей Иванович",
        "Попов Максим Олегович",
        "Сидорова Мария Александровна",
        "Смирнова Анна Викторовна"
    })]
    [InlineData(2, new string[]
    {
        "Иванов Иван Петрович",
        "Кузнецов Дмитрий Сергеевич",
        "Петров Алексей Иванович",
        "Сидорова Мария Александровна",
        "Смирнова Анна Викторовна"
    })]
    [InlineData(3, new string[]
    {
        "Иванов Иван Петрович",
        "Кузнецов Дмитрий Сергеевич",
        "Петров Алексей Иванович",
        "Сидорова Мария Александровна",
        "Смирнова Анна Викторовна"
    })]
    public void GetRestaurantCustomers(
        int restaurantId,
        string[] expectedFullNames)
    {
        var restaurant = data.Restaurants
            .Single(item => item.Id == restaurantId);

        var actualFullNames = data.Orders
            .Where(order => order.Restaurant.Id == restaurant.Id)
            .Select(order => order.Customer)
            .Distinct()
            .OrderBy(customer => customer.LastName)
            .ThenBy(customer => customer.FirstName)
            .ThenBy(customer => customer.Patronymic)
            .Select(customer =>
                $"{customer.LastName} " +
                $"{customer.FirstName} " +
                $"{customer.Patronymic}".Trim())
            .ToArray();

        Assert.Equal(expectedFullNames, actualFullNames);
    }
}