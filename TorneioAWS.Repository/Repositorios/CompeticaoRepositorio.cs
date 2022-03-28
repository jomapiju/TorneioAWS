using TorneioAWS.Domain;
using TorneioAWS.Repository.Comum.Contextos;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification;
using Microsoft.EntityFrameworkCore;

namespace TorneioAWS.Repository.Repositorios;

public class CompeticaoRepositorio : IRepository<Competicao>
{
    private readonly TorneioContext _torneioContext;

    public CompeticaoRepositorio(TorneioContext torneioContext)
    {
        _torneioContext = torneioContext;
    }

    public void Add(Competicao entity)
    {
        _torneioContext.Competicoes.Add(entity);
        _torneioContext.SaveChanges();
    }

    public void AddRange(IEnumerable<Competicao> entities)
    {
        _torneioContext.Competicoes.AddRange(entities);
        _torneioContext.SaveChanges();
    }

    public int Count(ISpecification<Competicao> specification)
    {
        throw new NotImplementedException();
    }

    public Competicao Get(ISpecification<Competicao> specification)
    {
        var query = _torneioContext.Competicoes
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).FirstOrDefault();
    }

    public Task<Competicao> GetAsync(ISpecification<Competicao> specification)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Competicao> List(ISpecification<Competicao> specification)
    {
        var query = _torneioContext.Competicoes
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).ToList();
    }

    public IEnumerable<Competicao> List(ISpecification<Competicao> specification, int skip, int take)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Competicao> List()
    {
        var query = _torneioContext.Competicoes
            .AsQueryable();

        return query.ToList();
    }

    public void Remove(Competicao entity)
    {
        _torneioContext.Competicoes.Remove(entity);
        _torneioContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<Competicao> entities)
    {
        _torneioContext.Competicoes.RemoveRange(entities);
        _torneioContext.SaveChanges();
    }

    public void Update(Competicao entity)
    {
        _torneioContext.Competicoes.Update(entity);
        _torneioContext.SaveChanges();
    }
}