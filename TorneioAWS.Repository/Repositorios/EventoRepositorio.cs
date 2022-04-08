using TorneioAWS.Domain;
using TorneioAWS.Repository.Comum.Contextos;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification;
using Microsoft.EntityFrameworkCore;

namespace TorneioAWS.Repository.Repositorios;

public class EventoRepositorio : IRepository<Evento>
{
    private readonly TorneioContext _torneioContext;

    public EventoRepositorio(TorneioContext torneioContext)
    {
        _torneioContext = torneioContext;
    }

    public void Add(Evento entity)
    {
        _torneioContext.Eventos.Add(entity);
        _torneioContext.SaveChanges();
    }

    public void AddRange(IEnumerable<Evento> entities)
    {
        _torneioContext.Eventos.AddRange(entities);
        _torneioContext.SaveChanges();
    }

    public int Count(ISpecification<Evento> specification)
    {
        throw new NotImplementedException();
    }

    public Evento Get(ISpecification<Evento> specification)
    {
        var query = _torneioContext.Eventos
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).FirstOrDefault();
    }

    public Task<Evento> GetAsync(ISpecification<Evento> specification)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Evento> List(ISpecification<Evento> specification)
    {
        var query = _torneioContext.Eventos
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).ToList();
    }

    public IEnumerable<Evento> List(ISpecification<Evento> specification, int skip, int take)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Evento> List()
    {
        var query = _torneioContext.Eventos
            .AsQueryable();

        return query.ToList();
    }

    public void Remove(Evento entity)
    {
        _torneioContext.Eventos.Remove(entity);
        _torneioContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<Evento> entities)
    {
        _torneioContext.Eventos.RemoveRange(entities);
        _torneioContext.SaveChanges();
    }

    public void Update(Evento entity)
    {
        _torneioContext.Eventos.Update(entity);
        _torneioContext.SaveChanges();
    }
}