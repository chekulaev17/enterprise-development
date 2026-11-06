using FoodDelivery.Application.Contracts.Categories;
using FoodDelivery.Application.Contracts.Common;

namespace FoodDelivery.Api.Controllers;

/// <summary>
/// Предоставляет HTTP-операции с категориями блюд
/// </summary>
/// <param name="service">Прикладная служба категорий</param>
/// <param name="logger">Средство журналирования</param>
public sealed class CategoriesController(
    ICrudService<CategoryDto, CategoryRequest> service,
    ILogger<CategoriesController> logger)
    : CrudControllerBase<CategoryDto, CategoryRequest>(service, logger)
{
    /// <inheritdoc/>
    protected override int GetResourceId(CategoryDto resource)
    {
        return resource.Id;
    }
}
