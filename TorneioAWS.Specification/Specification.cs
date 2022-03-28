using TorneioAWS.Application.Specification;
using System.Linq.Expressions;

namespace TorneioAWS.Specification;

public abstract class Specification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }

    public List<string> Includes { get; } = new List<string>();

    protected Specification(Expression<Func<T, bool>> criteria) => Criteria = criteria;

    protected void Include(string include) => Includes.Add(include);
}