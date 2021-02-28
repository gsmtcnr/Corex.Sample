using Corex.Data.Derived.EntityFramework;
using Corex.Sample.Model.EntityModel;
using System;

namespace Corex.Sample.Data.Derived.EFSQL.Orders
{
    public abstract class CorexBaseEntityGuidRepository<TEntityModel> : BaseEntityRepository<CorexDBContext, TEntityModel, Guid>
    where TEntityModel : class, ICorexEntityModel<Guid>
    {

    }
}
