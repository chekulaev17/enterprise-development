using FoodDelivery.Domain.Data;
using FoodDelivery.Domain.Models;
using FoodDelivery.Domain.Repositories;

namespace FoodDelivery.Infrastructure.InMemory.Repositories;

/// <summary>
/// Хранит категории блюд в памяти
/// </summary>
/// <param name="data">Начальные данные приложения</param>
public sealed class CategoryRepository(FoodDeliveryData data)
    : IRepository<Category>
{
    private readonly List<Category> _categories = [.. data.Categories];
    private readonly Lock _syncRoot = new();

    private int _lastId = data.Categories
        .Select(category => category.Id)
        .DefaultIfEmpty()
        .Max();

    /// <inheritdoc/>
    public IReadOnlyList<Category> GetAll()
    {
        lock (_syncRoot)
        {
            return [.. _categories];
        }
    }

    /// <inheritdoc/>
    public Category? GetById(int id)
    {
        lock (_syncRoot)
        {
            return _categories.FirstOrDefault(category => category.Id == id);
        }
    }

    /// <inheritdoc/>
    public Category Add(Category entity)
    {
        lock (_syncRoot)
        {
            entity.Id = ++_lastId;
            _categories.Add(entity);

            return entity;
        }
    }

    /// <inheritdoc/>
    public bool Update(Category entity)
    {
        lock (_syncRoot)
        {
            var category = _categories
                .FirstOrDefault(item => item.Id == entity.Id);

            if (category is null)
            {
                return false;
            }

            category.Name = entity.Name;

            return true;
        }
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        lock (_syncRoot)
        {
            _categories.RemoveAll(category => category.Id == id);
        }
    }
}
