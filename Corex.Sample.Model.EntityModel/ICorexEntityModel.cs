using Corex.Model.Derived.EntityModel;
using Corex.Sample.Model.Infrastructure;

namespace Corex.Sample.Model.EntityModel
{

    public interface ICorexEntityModel<TKey> : IEntityModel<TKey>,ICorexModel<TKey>
    {

    }
}
