using TorneioAWS.Domain;
using System;

namespace TorneioAWS.Application.Specification.Torneio;
public interface IObterJogadorEspecificacao
{
    ISpecification<Jogador> Execute(Guid guid);
}