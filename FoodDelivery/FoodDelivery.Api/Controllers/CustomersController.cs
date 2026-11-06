using FoodDelivery.Application.Contracts.Common;
using FoodDelivery.Application.Contracts.Customers;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции с клиентами
/// </summary>
/// <param name="service">Прикладная служба клиентов</param>
/// <param name="logger">Средство журналирования</param>
public sealed class CustomersController(
    ICrudService<CustomerDto, CustomerRequest> service,
    ILogger<CustomersController> logger)
    : CrudControllerBase<CustomerDto, CustomerRequest>(service, logger)
{
    /// <inheritdoc/>
    protected override int GetResourceId(CustomerDto resource)
    {
        return resource.Id;
    }
}
