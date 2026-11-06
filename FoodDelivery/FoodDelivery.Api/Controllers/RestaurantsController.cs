using FoodDelivery.Application.Contracts.Common;
using FoodDelivery.Application.Contracts.Orders;
using FoodDelivery.Application.Contracts.Restaurants;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции с ресторанами
/// </summary>
/// <param name="service">Прикладная служба ресторанов</param>
/// <param name="orderService">Прикладная служба заказов</param>
/// <param name="logger">Средство журналирования</param>
public sealed class RestaurantsController(
    ICrudService<RestaurantDto, RestaurantRequest> service,
    IOrderService orderService,
    ILogger<RestaurantsController> logger)
    : CrudControllerBase<RestaurantDto, RestaurantRequest>(service, logger)
{
    /// <summary>
    /// Возвращает заказы ресторана
    /// </summary>
    /// <param name="id">Идентификатор ресторана</param>
    /// <returns>Заказы ресторана</returns>
    [HttpGet("{id:int}/orders")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public ActionResult<IReadOnlyList<OrderDto>> GetOrders(int id)
    {
        var orders = orderService.GetByRestaurant(id);

        logger.LogInformation(
            "Получены заказы ресторана {RestaurantId}, количество: {Count}",
            id,
            orders.Count);

        return Ok(orders);
    }

    /// <inheritdoc/>
    protected override int GetResourceId(RestaurantDto resource)
    {
        return resource.Id;
    }
}
