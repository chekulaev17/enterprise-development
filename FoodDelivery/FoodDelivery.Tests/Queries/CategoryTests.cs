using FoodDelivery.Tests.TestData;

namespace FoodDelivery.Tests.Queries;

public class CategoryTests
{
    private readonly FoodDeliveryData _data = new();

    /// <summary>
    /// Проверяет количество и суммы заказов выбранной категории за период
    /// </summary>
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    public void GetCategoryOrderInfo(int categoryId)
    {
        var startDate = new DateTime(2026, 9, 1);
        var endDate = new DateTime(2026, 9, 20);

        var category = _data.Categories
            .Single(item => item.Id == categoryId);

        var orders = _data.Orders
            .Where(order =>
                order.CreatedAt >= startDate &&
                order.CreatedAt <= endDate &&
                order.Items.Any(item =>
                    item.Dish.Category.Id == category.Id))
            .ToList();

        Assert.NotEmpty(orders);

        var orderCount = orders.Count;
        var totalAmount = orders.Sum(order => order.TotalAmount);
        var averageAmount = orders.Average(order => order.TotalAmount);

        Assert.Equal(
            orderCount,
            orders.DistinctBy(order => order.Id).Count());

        Assert.Equal(
            totalAmount,
            orders.DistinctBy(order => order.Id)
                .Sum(order => order.TotalAmount));

        Assert.Equal(
            averageAmount,
            orders.DistinctBy(order => order.Id)
                .Average(order => order.TotalAmount));
    }
}