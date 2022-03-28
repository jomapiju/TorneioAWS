using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TorneioAWS.Domain.Comum;

namespace TorneioAWS.Application.Specification;
public interface ISpecification<T> : IEntity
{
    Expression<Func<T, bool>> Criteria { get; }
    List<string> Includes { get; }
}