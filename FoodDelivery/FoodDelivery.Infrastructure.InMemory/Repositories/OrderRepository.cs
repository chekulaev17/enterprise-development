using FoodDelivery.Domain.Data;
using FoodDelivery.Domain.Models;
using FoodDelivery.Domain.Repositories;

namespace FoodDelivery.Infrastructure.InMemory.Repositories;

/// <summary>
/// Хранит заказы в памяти
/// </summary>
/// <param name="data">Данные приложения</param>
public sealed class OrderRepository(FoodDeliveryData data)
    : InMemoryRepository<Order>(
        data.Orders,
        order => order.Id),
        IOrderRepository
{
    /// <inheritdoc/>
    public IReadOnlyList<Order> GetByCustomer(int customerId)
    {
        return GetAll()
            .Where(order => order.Customer.Id == customerId)
            .ToArray();
    }

    /// <inheritdoc/>
    public IReadOnlyList<Order> GetByRestaurant(int restaurantId)
    {
        return GetAll()
            .Where(order => order.Restaurant.Id == restaurantId)
            .ToArray();
    }

    /// <inheritdoc/>
    protected override void SetId(Order entity, int id)
    {
        entity.Id = id;
    }

    /// <inheritdoc/>
    protected override void UpdateEntity(
        Order existingEntity,
        Order updatedEntity)
    {
        existingEntity.Customer = updatedEntity.Customer;
        existingEntity.Restaurant = updatedEntity.Restaurant;
        existingEntity.CreatedAt = updatedEntity.CreatedAt;
        existingEntity.DeliveredAt = updatedEntity.DeliveredAt;
    }
}
