using Corex.Model.Derived.EntityModel;
using Corex.Model.Infrastructure;
using Corex.Operation.Manager;

namespace Corex.Sample.Operation.Manager
{
    public interface ICorexOperationManager<TKey, TEntity, TModel> : IOperationManager<TKey, TEntity, TModel>
        where TEntity : class, IEntityModel<TKey>, new()
        where TModel : class, IModel<TKey>, new()
    {

    }
}
