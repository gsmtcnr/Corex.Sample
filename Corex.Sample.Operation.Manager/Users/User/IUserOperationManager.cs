using Corex.Model.Infrastructure;
using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.EntityModel.Users.User;
using Corex.Sample.Model.ViewModel.Users.User.Inputs;

namespace Corex.Sample.Operation.Manager.Users.User
{
    public interface IUserOperationManager : ICorexOperationManager<int, UserEntity, UserDto>
    {
        IResultObjectModel<UserDto> Register(IUserInputModel inputModel);
        IResultObjectModel<UserDto> Edit(IUserInputModel inputModel);
    }
}
