using System.Collections.Generic;
using System.Threading.Tasks;
using TorneioAWS.Application.Specification;
using TorneioAWS.Domain.Comum;

namespace TorneioAWS.Application.Repository;
public interface IRepository<T> where T : IEntity
{
    T Get(ISpecification<T> specification);
    Task<T> GetAsync(ISpecification<T> specification);
    IEnumerable<T> List(ISpecification<T> specification);
    IEnumerable<T> List(ISpecification<T> specification, int skip, int take);
    int Count(ISpecification<T> specification);
    IEnumerable<T> List();
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void AddRange(IEnumerable<T> entities);
}