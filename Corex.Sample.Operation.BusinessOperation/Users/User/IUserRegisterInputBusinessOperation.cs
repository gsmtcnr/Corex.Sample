using Corex.Model.Infrastructure;
using Corex.Operation.Inftrastructure;
using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.ViewModel.Users.User.Inputs;

namespace Corex.Sample.Operation.BusinessOperation.Users.User
{
    public interface IUserRegisterInputBusinessOperation  : IBusinessOperation
    {
        UserDto Create(IUserInputModel inputModel);
    }
}
