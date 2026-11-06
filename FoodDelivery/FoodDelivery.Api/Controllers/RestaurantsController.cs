using FoodDelivery.Application.Contracts.Common;
using FoodDelivery.Application.Contracts.Restaurants;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции с ресторанами
/// </summary>
/// <param name="service">Прикладная служба ресторанов</param>
/// <param name="logger">Средство журналирования</param>
public sealed class RestaurantsController(
    ICrudService<RestaurantDto, RestaurantRequest> service,
    ILogger<RestaurantsController> logger)
    : CrudControllerBase<RestaurantDto, RestaurantRequest>(service, logger)
{
    /// <inheritdoc/>
    protected override int GetResourceId(RestaurantDto resource)
    {
        return resource.Id;
    }
}
