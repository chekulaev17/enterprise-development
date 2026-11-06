using FoodDelivery.Domain.Models;

namespace FoodDelivery.Domain.Repositories;

/// <summary>
/// Определяет операции хранения блюд
/// </summary>
public interface IDishRepository : IRepository<Dish>
{
    /// <summary>
    /// Проверяет использование блюда в заказах
    /// </summary>
    /// <param name="dishId">Идентификатор блюда</param>
    /// <returns>Признак использования блюда в заказах</returns>
    bool IsUsedInOrders(int dishId);
}
