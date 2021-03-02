using Corex.Operation.Inftrastructure;
using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.ViewModel.Users.User.Inputs;

namespace Corex.Sample.Operation.BusinessOperation.Users.User
{
    public interface IUserEditInputBusinessOperation : IBusinessOperation
    {
        UserDto Edit(UserDto userDto, IUserInputModel inputModel);
    }
}
