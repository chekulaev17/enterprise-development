namespace FoodDelivery.Domain.Models;

/// <summary>
/// Заказ клиента в ресторане
/// </summary>
public class Order
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Клиент, который сделал заказ
    /// </summary>
    public required Customer Customer { get; set; }

    /// <summary>
    /// Ресторан, в котором сделан заказ
    /// </summary>
    public required Restaurant Restaurant { get; set; }

    /// <summary>
    /// Время создания заказа
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Время доставки заказа
    /// </summary>
    public required DateTime DeliveredAt { get; set; }

    /// <summary>
    /// Общая сумма заказа
    /// </summary>
    public required decimal TotalAmount { get; set; }

    /// <summary>
    /// Список блюд в заказе
    /// </summary>
    public required List<OrderItem> Items { get; set; }
}