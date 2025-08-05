
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly DevConnectDbContext _context;
    public Repository(DevConnectDbContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T obj)
    {
        var entry = await _context.Set<T>().AddAsync(obj);
        await _context.SaveChangesAsync();
        return entry.Entity;
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

    public async Task<T> HardDelete(T obj)
    {
        var entity = await _context.Set<T>().FindAsync(obj);
        if (entity == null)
            return null;

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> RemoveAsync(T obj)
    {
        var removed = await _context.Set<T>().FirstOrDefaultAsync(u => u.Id == obj.Id);
        removed.Status = StatusEnum.removed;
        await _context.SaveChangesAsync();
        return removed;

    }
}