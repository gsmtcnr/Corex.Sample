using Corex.Data.Derived.EntityFramework;
using Corex.Model.Derived.EntityModel;

namespace Corex.Sample.Data.Derived.EFSQL
{
    public abstract class CorexBaseEntityIntConfiguration<TEntity> : BaseEntityConfiguration<TEntity, int>
         where TEntity : class, IEntityModel<int>
    {

    }
}
