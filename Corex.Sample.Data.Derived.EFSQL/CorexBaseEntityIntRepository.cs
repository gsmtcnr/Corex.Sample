using Corex.Data.Derived.EntityFramework;
using Corex.Sample.Model.EntityModel;

namespace Corex.Sample.Data.Derived.EFSQL
{
    public abstract class CorexBaseEntityIntRepository<TEntityModel> : BaseEntityRepository<CorexDBContext, TEntityModel, int>
where TEntityModel : class, ICorexEntityModel<int>
    {

    }
}
