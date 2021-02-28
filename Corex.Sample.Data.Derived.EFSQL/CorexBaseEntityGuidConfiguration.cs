using Corex.Data.Derived.EntityFramework;
using Corex.Model.Derived.EntityModel;
using System;

namespace Corex.Sample.Data.Derived.EFSQL
{
    public abstract class CorexBaseEntityGuidConfiguration<TEntity> : BaseEntityConfiguration<TEntity, Guid>
    where TEntity : class, IEntityModel<Guid>
    {

    }
}
