using FoodDelivery.Domain.Repositories;

namespace FoodDelivery.Infrastructure.InMemory.Repositories;

/// <summary>
/// Реализует общие операции хранения сущностей в памяти
/// </summary>
/// <typeparam name="TEntity">Тип доменной сущности</typeparam>
/// <param name="entities">Коллекция сущностей приложения</param>
/// <param name="getId">Функция получения идентификатора сущности</param>
public abstract class InMemoryRepository<TEntity>(
    List<TEntity> entities,
    Func<TEntity, int> getId) : IRepository<TEntity>
    where TEntity : class
{
    private readonly Lock _syncRoot = new();

    private int _lastId = entities
        .Select(getId)
        .DefaultIfEmpty()
        .Max();

    /// <inheritdoc/>
    public IReadOnlyList<TEntity> GetAll()
    {
        lock (_syncRoot)
        {
            return [.. entities];
        }
    }

    /// <inheritdoc/>
    public TEntity? GetById(int id)
    {
        lock (_syncRoot)
        {
            return entities.FirstOrDefault(entity => getId(entity) == id);
        }
    }

    /// <inheritdoc/>
    public TEntity Add(TEntity entity)
    {
        lock (_syncRoot)
        {
            SetId(entity, ++_lastId);
            entities.Add(entity);

            return entity;
        }
    }

    /// <inheritdoc/>
    public bool Update(TEntity entity)
    {
        lock (_syncRoot)
        {
            var id = getId(entity);
            var existingEntity = entities
                .FirstOrDefault(item => getId(item) == id);

            if (existingEntity is null)
            {
                return false;
            }

            UpdateEntity(existingEntity, entity);

            return true;
        }
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        lock (_syncRoot)
        {
            entities.RemoveAll(entity => getId(entity) == id);
        }
    }

    /// <summary>
    /// Назначает идентификатор сущности
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <param name="id">Назначаемый идентификатор</param>
    protected abstract void SetId(TEntity entity, int id);

    /// <summary>
    /// Переносит новые значения в существующую сущность
    /// </summary>
    /// <param name="existingEntity">Существующая сущность</param>
    /// <param name="updatedEntity">Сущность с новыми значениями</param>
    protected abstract void UpdateEntity(
        TEntity existingEntity,
        TEntity updatedEntity);
}
