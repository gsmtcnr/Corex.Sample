using Corex.Data.Infrastructure;
using Corex.Model.Derived.EntityModel;
using Corex.Operation.Derived.DataOperation;
using Corex.Sample.Core.Infrastructure;
using System;

namespace Corex.Sample.Operation.DataOperation
{
    public abstract class BaseCorexDataOperation<TEntity, TRepository, TKey> : BaseDataOperation<TEntity, TRepository, TKey>
        where TEntity : class, IEntityModel<TKey>, new()
        where TKey : IEquatable<TKey>
        where TRepository : class, IRepository<TEntity, TKey>
    {
        public override IRepository<TEntity, TKey> SetRepository()
        {
            return IoCManager.Resolve<IRepository<TEntity, TKey>>();
        }
    }
}
