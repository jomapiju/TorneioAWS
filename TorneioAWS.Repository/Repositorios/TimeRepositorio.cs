using TorneioAWS.Domain;
using TorneioAWS.Repository.Comum.Contextos;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification;
using Microsoft.EntityFrameworkCore;

namespace TorneioAWS.Repository.Repositorios;

public class TimeRepositorio : IRepository<Time>
{
    private readonly TorneioContext _torneioContext;

    public TimeRepositorio(TorneioContext torneioContext)
    {
        _torneioContext = torneioContext;
    }

    public void Add(Time entity)
    {
        _torneioContext.Times.Add(entity);
        _torneioContext.SaveChanges();
    }

    public void AddRange(IEnumerable<Time> entities)
    {
        _torneioContext.Times.AddRange(entities);
        _torneioContext.SaveChanges();
    }

    public int Count(ISpecification<Time> specification)
    {
        throw new NotImplementedException();
    }

    public Time Get(ISpecification<Time> specification)
    {
        var query = _torneioContext.Times
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).FirstOrDefault();
    }

    public Task<Time> GetAsync(ISpecification<Time> specification)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Time> List(ISpecification<Time> specification)
    {
        var query = _torneioContext.Times
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).ToList();
    }

    public IEnumerable<Time> List(ISpecification<Time> specification, int skip, int take)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Time> List()
    {
        var query = _torneioContext.Times
            .AsQueryable();

        return query.ToList();
    }

    public void Remove(Time entity)
    {
        _torneioContext.Times.Remove(entity);
        _torneioContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<Time> entities)
    {
        _torneioContext.Times.RemoveRange(entities);
        _torneioContext.SaveChanges();
    }

    public void Update(Time entity)
    {
        _torneioContext.Times.Update(entity);
        _torneioContext.SaveChanges();
    }
}