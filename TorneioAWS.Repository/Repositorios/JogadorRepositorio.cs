using TorneioAWS.Domain;
using TorneioAWS.Repository.Comum.Contextos;
using TorneioAWS.Application.Repository;
using TorneioAWS.Application.Specification;
using Microsoft.EntityFrameworkCore;

namespace TorneioAWS.Repository.Repositorios;

public class JogadorRepositorio : IRepository<Jogador>
{
    private readonly TorneioContext _torneioContext;

    public JogadorRepositorio(TorneioContext torneioContext)
    {
        _torneioContext = torneioContext;
    }

    public void Add(Jogador entity)
    {
        _torneioContext.Jogadores.Add(entity);
        _torneioContext.SaveChanges();
    }

    public void AddRange(IEnumerable<Jogador> entities)
    {
        _torneioContext.Jogadores.AddRange(entities);
        _torneioContext.SaveChanges();
    }

    public int Count(ISpecification<Jogador> specification)
    {
        throw new NotImplementedException();
    }

    public Jogador Get(ISpecification<Jogador> specification)
    {
        var query = _torneioContext.Jogadores
            .Include(j => j.Time)
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).FirstOrDefault();
    }

    public Task<Jogador> GetAsync(ISpecification<Jogador> specification)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Jogador> List(ISpecification<Jogador> specification)
    {
        var query = _torneioContext.Jogadores
            .AsQueryable();

        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        return query.Where(specification.Criteria).ToList();
    }

    public IEnumerable<Jogador> List(ISpecification<Jogador> specification, int skip, int take)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Jogador> List()
    {
        var query = _torneioContext.Jogadores
            .AsQueryable();

        return query.ToList();
    }

    public void Remove(Jogador entity)
    {
        _torneioContext.Jogadores.Remove(entity);
        _torneioContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<Jogador> entities)
    {
        _torneioContext.Jogadores.RemoveRange(entities);
        _torneioContext.SaveChanges();
    }

    public void Update(Jogador entity)
    {
        _torneioContext.Jogadores.Update(entity);
        _torneioContext.SaveChanges();
    }
}