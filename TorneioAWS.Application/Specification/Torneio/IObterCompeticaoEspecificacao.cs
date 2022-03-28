using TorneioAWS.Domain;
using System;

namespace TorneioAWS.Application.Specification.Torneio;
public interface IObterCompeticaoEspecificacao
{
    ISpecification<Competicao> Execute(Guid guid);
}