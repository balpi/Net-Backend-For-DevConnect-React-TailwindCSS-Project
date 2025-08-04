public interface IRepository<T> where T : EntityBase
{
    Task<T> GetById(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec);
    Task<T> GetByFilter(ISpecification<T> spec);
    Task<int> Count(ISpecification<T> spec);



}