
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly DevConnectDbContext _context;
    public Repository(DevConnectDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationElevator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
    public async Task<int> Count(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }



    public async Task<T?> GetByFilter(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }
}