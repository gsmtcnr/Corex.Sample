using Corex.Model.Derived.EntityModel;
using Corex.Model.Infrastructure;

namespace Corex.Sample.Operation.Manager
{
    public abstract class CorexIntOperationManager<TEntity, TModel> : CorexOperationManager<int, TEntity, TModel>
       where TEntity : class, IEntityModel<int>, new()
       where TModel : class, IModel<int>, new()
    {
        public override IResultObjectModel<TModel> SaveChanges(TModel dto)
        {
            if (dto.Id == 0)
                return Insert(dto);
            else
                return Update(dto);
        }
    }
}
