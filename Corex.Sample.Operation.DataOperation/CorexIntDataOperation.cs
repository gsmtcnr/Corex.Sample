using Corex.Data.Infrastructure;
using Corex.Model.Derived.EntityModel;

namespace Corex.Sample.Operation.DataOperation
{
    public abstract class CorexIntDataOperation<TEntity, TRepository> : BaseCorexDataOperation<TEntity, TRepository, int>
                where TEntity : class, IEntityModel<int>, new()
        where TRepository : class, IRepository<TEntity, int>
    {

    }
}
