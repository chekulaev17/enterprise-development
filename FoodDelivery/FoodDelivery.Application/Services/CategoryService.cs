using FoodDelivery.Application.Contracts.Categories;
using FoodDelivery.Application.Contracts.Common;
using FoodDelivery.Application.Exceptions;
using FoodDelivery.Domain.Models;
using FoodDelivery.Domain.Repositories;

namespace FoodDelivery.Application.Services;

/// <summary>
/// Выполняет операции с категориями блюд
/// </summary>
/// <param name="repository">Репозиторий категорий</param>
public sealed class CategoryService(ICategoryRepository repository)
    : ICrudService<CategoryDto, CategoryRequest>
{
    /// <inheritdoc/>
    public IReadOnlyList<CategoryDto> GetAll()
    {
        return repository.GetAll()
            .Select(ToDto)
            .ToArray();
    }

    /// <inheritdoc/>
    public CategoryDto? GetById(int id)
    {
        var category = repository.GetById(id);

        return category is null ? null : ToDto(category);
    }

    /// <inheritdoc/>
    public CategoryDto Create(CategoryRequest request)
    {
        var category = new Category
        {
            Id = 0,
            Name = request.Name.Trim()
        };

        var createdCategory = repository.Add(category);

        return ToDto(createdCategory);
    }

    /// <inheritdoc/>
    public CategoryDto? Update(int id, CategoryRequest request)
    {
        var category = new Category
        {
            Id = id,
            Name = request.Name.Trim()
        };

        return repository.Update(category) ? ToDto(category) : null;
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        if (repository.HasDishes(id))
        {
            throw new ResourceConflictException(
                "Нельзя удалить категорию, которая используется блюдами");
        }

        repository.Delete(id);
    }

    private static CategoryDto ToDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
