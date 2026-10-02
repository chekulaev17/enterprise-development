using FoodDelivery.Domain.Data;

namespace FoodDelivery.Tests.Queries;

public class CategoryTests(FoodDeliveryData data)
    : IClassFixture<FoodDeliveryData>
{
    private const int AmountPrecision = 2;

    /// <summary>
    /// Проверяет количество, среднюю и общую сумму заказов выбранной категории за период
    /// </summary>
    [Theory]
    [InlineData(1, 3, 1000, 3000)]
    [InlineData(5, 5, 698, 3490)]
    [InlineData(8, 5, 216, 1080)]
    public void GetCategoryOrderInfo(
        int categoryId,
        int expectedOrderCount,
        decimal expectedAverageAmount,
        decimal expectedTotalAmount)
    {
        var startDate = new DateTime(2026, 9, 1);
        var endDate = new DateTime(2026, 9, 20);

        var category = data.Categories
            .Single(item => item.Id == categoryId);

        var orders = data.Orders
            .Where(order =>
                order.CreatedAt >= startDate &&
                order.CreatedAt <= endDate &&
                order.Items.Any(item =>
                    item.Dish.Category.Id == category.Id))
            .ToList();

        var orderCount = orders.Count;
        var totalAmount = orders.Sum(order => order.TotalAmount);
        var averageAmount = Math.Round(
            orders.Average(order => order.TotalAmount),
            AmountPrecision);

        Assert.Equal(expectedOrderCount, orderCount);
        Assert.Equal(expectedTotalAmount, totalAmount);
        Assert.Equal(expectedAverageAmount, averageAmount);
    }
}