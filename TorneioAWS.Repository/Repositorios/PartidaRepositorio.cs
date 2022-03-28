using TorneioAWS.Domain;
using TorneioAWS.Repository.Comum.Contextos;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification;
using Microsoft.EntityFrameworkCore;

namespace TorneioAWS.Repository.Repositorios;

public class PartidaRepositorio : IRepository<Partida>
{
    private readonly TorneioContext _torneioContext;

    public PartidaRepositorio(TorneioContext torneioContext)
    {
        _torneioContext = torneioContext;
    }

    public void Add(Partida entity)
    {
        _torneioContext.Partidas.Add(entity);
        _torneioContext.SaveChanges();
    }

    public void AddRange(IEnumerable<Partida> entities)
    {
        _torneioContext.Partidas.AddRange(entities);
        _torneioContext.SaveChanges();
    }

    public int Count(ISpecification<Partida> specification)
    {
        throw new NotImplementedException();
    }

    public Partida Get(ISpecification<Partida> specification)
    {
        var query = _torneioContext.Partidas
            .Include(j => j.TimeCasa)
            .Include(j => j.TimeVisitante)
            .Include(j => j.Competicao)
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).FirstOrDefault();
    }

    public Task<Partida> GetAsync(ISpecification<Partida> specification)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Partida> List(ISpecification<Partida> specification)
    {
        var query = _torneioContext.Partidas
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).ToList();
    }

    public IEnumerable<Partida> List(ISpecification<Partida> specification, int skip, int take)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Partida> List()
    {
        var query = _torneioContext.Partidas
            .AsQueryable();

        return query.ToList();
    }

    public void Remove(Partida entity)
    {
        _torneioContext.Partidas.Remove(entity);
        _torneioContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<Partida> entities)
    {
        _torneioContext.Partidas.RemoveRange(entities);
        _torneioContext.SaveChanges();
    }

    public void Update(Partida entity)
    {
        _torneioContext.Partidas.Update(entity);
        _torneioContext.SaveChanges();
    }
}