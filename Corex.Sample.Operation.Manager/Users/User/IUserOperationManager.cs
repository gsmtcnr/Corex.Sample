using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.EntityModel.Users.User;

namespace Corex.Sample.Operation.Manager.Users.User
{
    public interface IUserOperationManager : ICorexOperationManager<int, UserEntity, UserDto>
    {
    }
}
