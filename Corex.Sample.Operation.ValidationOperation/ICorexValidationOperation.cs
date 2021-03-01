using Corex.Operation.Infrastructure;

namespace Corex.Sample.Operation.ValidationOperation
{
    public interface ICorexValidationOperation<T> : IValidationOperation<T>
      where T : class
    {
    }
}
