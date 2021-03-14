using Corex.Cache.Infrastructure;
using Corex.Model.Derived.EntityModel;
using Corex.Model.Infrastructure;
using Corex.Operation.Derived.ValidationOperation;
using Corex.Operation.Inftrastructure;
using Corex.Operation.Manager;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.Mapper.Infrastructure;
using System;

namespace Corex.Sample.Operation.Manager
{
    public abstract class CorexOperationManager<TKey, TEntity, TModel> : BaseOperationManager<TKey, TEntity, TModel>, ICorexOperationManager<TKey, TEntity, TModel>
       where TKey : IEquatable<TKey>, new()
       where TEntity : class, IEntityModel<TKey>, new()
       where TModel : class, IModel<TKey>, new()
    {
        public override ICorexMapper SetMapper()
        {
            //Tüm managerlar için mapper tek bir yer set ediyorum.
            return IoCManager.Resolve<ICorexMapper>();
        }
        public override BaseValidationOperation<TModel> SetDeleteValidationOperation(TModel dto)
        {
            //Tüm methodlar delete validation yapmamızı gerektirmiyor.
            return null;
        }
        public override ICacheSettings SetCacheSettings()
        {
            return new CacheSettings
            {
                CacheManager = IoCManager.Resolve<ICacheManager>(),
                Prefix = "Corex"
            };
        }

    }
}
