using Corex.Data.Infrastructure;
using Corex.Model.Derived.EntityModel;
using System;

namespace Corex.Sample.Operation.DataOperation
{
    public abstract class CorexGuidDataOperation<TEntity, TRepository> : BaseCorexDataOperation<TEntity, TRepository, Guid>
        where TEntity : class, IEntityModel<Guid>, new()
       where TRepository : class, IRepository<TEntity, Guid>
    {

    }
}
