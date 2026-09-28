namespace FoodDelivery.Domain.Models;

/// <summary>
/// Блюдо в составе заказа
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Идентификатор позиции заказа
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Блюдо в позиции заказа
    /// </summary>
    public required Dish Dish { get; set; }

    /// <summary>
    /// Количество блюд
    /// </summary>
    public required int Quantity { get; set; }
}