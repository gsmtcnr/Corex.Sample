using Corex.Sample.Data.Infrastructure.Users.User;
using Corex.Sample.Model.EntityModel.Users.User;

namespace Corex.Sample.Data.Derived.EFSQL.Users.User
{
    public class UserRepository : CorexBaseEntityIntRepository<UserEntity>, IUserRepository
    {
    }
}
