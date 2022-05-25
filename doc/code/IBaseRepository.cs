public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    IQueryable<T> GetAllAsQueryable();
    Task<T> GetById(Guid id);
    Task<Guid> Add(T entity);
    Task Delete(Guid id);
    Task Update(T entity);
}