using Corex.Data.Derived.EntityFramework;
using Corex.Sample.Model.EntityModel;
using System;

namespace Corex.Sample.Data.Derived.EFSQL
{
    public abstract class CorexBaseEntityGuidRepository<TEntityModel> : BaseEntityRepository<CorexDBContext, TEntityModel, Guid>
    where TEntityModel : class, ICorexEntityModel<Guid>
    {

    }
}
