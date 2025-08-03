using System.Linq.Expressions;

public class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification()
    {
    }
    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }

    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

    public Expression<Func<T, object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    public int skip { get; private set; }

    public int take { get; private set; }

    public bool isPagingEnabled { get; private set; }

    public void AddOrderBy(Expression<Func<T, object>> orderBy)
    {
        OrderBy = orderBy;
    }

    public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
    {
        OrderByDescending = orderByDescending;
    }

    public void ApplyPaging(int takeP, int skipP)
    {
        take = takeP;
        skip = skipP;
        isPagingEnabled = true;
    }

}