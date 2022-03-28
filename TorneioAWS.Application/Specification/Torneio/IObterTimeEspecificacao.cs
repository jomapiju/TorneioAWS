using TorneioAWS.Domain;
using System;

namespace TorneioAWS.Application.Specification.Torneio;
public interface IObterTimeEspecificacao
{
    ISpecification<Time> Execute(Guid guid);
}