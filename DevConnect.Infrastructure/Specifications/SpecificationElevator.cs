using Microsoft.EntityFrameworkCore;

public class SpecificationElevator<T> where T : EntityBase
{
    public static IQueryable<T> GetQuery(IQueryable<T> InputQuery, ISpecification<T> spec)
    {
        var query = InputQuery;
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }
        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }

        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }
        if (spec.isPagingEnabled)
        {
            query = query.Skip(spec.skip).Take(spec.take);
        }

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        return query;
    }
}