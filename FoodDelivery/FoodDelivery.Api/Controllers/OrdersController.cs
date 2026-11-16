using FoodDelivery.Application.Contracts.Orders;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции с заказами
/// </summary>
/// <param name="service">Прикладная служба заказов</param>
/// <param name="logger">Средство журналирования</param>
[Route("api/orders")]
[ProducesActionProblem(nameof(OrdersController.Create), StatusCodes.Status422UnprocessableEntity)]
[ProducesActionProblem(nameof(OrdersController.Update), StatusCodes.Status422UnprocessableEntity)]
[ProducesActionProblem(nameof(OrdersController.Update), StatusCodes.Status409Conflict)]
public sealed class OrdersController(
    IOrderService service,
    ILogger<OrdersController> logger)
    : CrudControllerBase<OrderDto, OrderRequest>(service, logger)
{
    /// <inheritdoc/>
    protected override int GetResourceId(OrderDto resource)
    {
        return resource.Id;
    }
}
