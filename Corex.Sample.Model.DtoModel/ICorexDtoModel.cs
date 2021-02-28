using Corex.Model.Derived.DtoModel;
using Corex.Sample.Model.Infrastructure;

namespace Corex.Sample.Model.DtoModel
{
    public interface  ICorexDtoModel<TKey> : IDtoModel<TKey>, ICorexModel<TKey>
    {
    }
}
