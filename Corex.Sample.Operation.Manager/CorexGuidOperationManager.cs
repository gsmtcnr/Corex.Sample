using Corex.Model.Derived.EntityModel;
using Corex.Model.Infrastructure;
using System;

namespace Corex.Sample.Operation.Manager
{
    public abstract class CorexGuidOperationManager<TEntity, TModel> : CorexOperationManager<Guid, TEntity, TModel>
      where TEntity : class, IEntityModel<Guid>, new()
      where TModel : class, IModel<Guid>, new()
    {
        public override IResultObjectModel<TModel> SaveChanges(TModel dto)
        {
            if (dto.Id == Guid.Empty)
                return Insert(dto);
            else
                return Update(dto);
        }
    }
}
