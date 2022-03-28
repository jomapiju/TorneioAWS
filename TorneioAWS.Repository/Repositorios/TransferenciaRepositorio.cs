using TorneioAWS.Domain;
using TorneioAWS.Repository.Comum.Contextos;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification;
using Microsoft.EntityFrameworkCore;

namespace TorneioAWS.Repository.Repositorios;

public class TransferenciaRepositorio : IRepository<Transferencia>
{
    private readonly TorneioContext _torneioContext;

    public TransferenciaRepositorio(TorneioContext torneioContext)
    {
        _torneioContext = torneioContext;
    }

    public void Add(Transferencia entity)
    {
        _torneioContext.Transferencias.Add(entity);
        _torneioContext.SaveChanges();
    }

    public void AddRange(IEnumerable<Transferencia> entities)
    {
        _torneioContext.Transferencias.AddRange(entities);
        _torneioContext.SaveChanges();
    }

    public int Count(ISpecification<Transferencia> specification)
    {
        throw new NotImplementedException();
    }

    public Transferencia Get(ISpecification<Transferencia> specification)
    {
        var query = _torneioContext.Transferencias
            .Include(j => j.Jogador)
            .Include(j => j.TimeOrigem)
            .Include(j => j.TimeDestino)
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).FirstOrDefault();
    }

    public Task<Transferencia> GetAsync(ISpecification<Transferencia> specification)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transferencia> List(ISpecification<Transferencia> specification)
    {
        var query = _torneioContext.Transferencias
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).ToList();
    }

    public IEnumerable<Transferencia> List(ISpecification<Transferencia> specification, int skip, int take)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transferencia> List()
    {
        var query = _torneioContext.Transferencias
            .AsQueryable();

        return query.ToList();
    }

    public void Remove(Transferencia entity)
    {
        _torneioContext.Transferencias.Remove(entity);
        _torneioContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<Transferencia> entities)
    {
        _torneioContext.Transferencias.RemoveRange(entities);
        _torneioContext.SaveChanges();
    }

    public void Update(Transferencia entity)
    {
        _torneioContext.Transferencias.Update(entity);
        _torneioContext.SaveChanges();
    }
}