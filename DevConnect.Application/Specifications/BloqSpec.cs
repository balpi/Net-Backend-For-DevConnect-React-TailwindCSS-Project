
using System.Linq.Expressions;

public class BloqSpec : BaseSpecification<Bloq>
{
    public BloqSpec(FilterDto filter) : base(
        x =>
        (string.IsNullOrEmpty(filter._search))
        || (x.Title.ToLower().Contains(filter._search))

    )
    {
    }
}