using TorneioAWS.Domain;
using System;

namespace TorneioAWS.Application.Specification.Torneio;
public interface IObterTransferenciaEspecificacao
{
    ISpecification<Transferencia> Execute(Guid guid);
}