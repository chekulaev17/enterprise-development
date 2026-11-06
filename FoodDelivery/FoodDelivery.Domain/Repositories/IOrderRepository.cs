using FoodDelivery.Domain.Models;

namespace FoodDelivery.Domain.Repositories;

/// <summary>
/// Определяет операции хранения заказов
/// </summary>
public interface IOrderRepository : IRepository<Order>
{
    /// <summary>
    /// Возвращает заказы клиента
    /// </summary>
    /// <param name="customerId">Идентификатор клиента</param>
    /// <returns>Заказы клиента</returns>
    IReadOnlyList<Order> GetByCustomer(int customerId);

    /// <summary>
    /// Возвращает заказы ресторана
    /// </summary>
    /// <param name="restaurantId">Идентификатор ресторана</param>
    /// <returns>Заказы ресторана</returns>
    IReadOnlyList<Order> GetByRestaurant(int restaurantId);
}
