namespace Corex.Sample.Operation.CacheOperation
{
    public interface ICacheOperation<TModel>
        where TModel : class, new()
    {
        TModel Get(string key);
    }
}
