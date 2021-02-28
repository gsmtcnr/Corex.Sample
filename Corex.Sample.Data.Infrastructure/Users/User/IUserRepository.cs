using Corex.Data.Infrastructure;
using Corex.Sample.Model.EntityModel.Users.User;

namespace Corex.Sample.Data.Infrastructure.Users.User
{
    public interface IUserRepository :
        ISelectableRepository<UserEntity, int>,
        IUpdatableRepository<UserEntity, int>,
        IDeletableRepository<UserEntity, int>,
        IInsertableRepository<UserEntity, int>
    {
    }
}
