using Corex.Operation.Derived.ValidationOperation;

namespace Corex.Sample.Operation.ValidationOperation
{
    public abstract class CorexValidationOperation<T> : BaseValidationOperation<T>, ICorexValidationOperation<T>
      where T : class
    {
        //protected CorexValidationOperation(T item) : base(item)
        //{
        //    //Direkt BaseValidationOperation kullanmak yerine "CorexValidationOperation" yapıyoruz.
        //    //Böylece projemize özel bir düzenlemede ekleyebiliriz.
        //}
    }
}
