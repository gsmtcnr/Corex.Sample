using Corex.Sample.Data.Infrastructure.Users.User;
using Corex.Sample.Model.EntityModel.Users.User;

namespace Corex.Sample.Operation.DataOperation.Users.User
{
    public class UserDataOperation : CorexIntDataOperation<UserEntity, IUserRepository>, IUserDataOperation
    {
    }
}
