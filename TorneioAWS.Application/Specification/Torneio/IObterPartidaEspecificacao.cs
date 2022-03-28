using TorneioAWS.Domain;
using System;

namespace TorneioAWS.Application.Specification.Torneio;
public interface IObterPartidaEspecificacao
{
    ISpecification<Partida> Execute(Guid guid);
}