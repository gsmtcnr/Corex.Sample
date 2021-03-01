using Corex.ExceptionHandling.Derived.Business;
using Corex.ExceptionHandling.Infrastructure.Models;
using Corex.Operation.Derived.BusinessOperation;
using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using System;

namespace Corex.Sample.Operation.BusinessOperation.Users.User
{
    public class UserRegisterInputBusinessOperation : BaseBusinessOperation, IUserRegisterInputBusinessOperation
    {
        public UserDto Create(IUserInputModel inputModel)
        {
            UserRegisterInputModel userRegisterInputModel = (UserRegisterInputModel)inputModel;
            NullCheck(userRegisterInputModel);
            try
            {
                UserDto userDto = new UserDto(userRegisterInputModel.Password, userRegisterInputModel.Email);
                return userDto;
            }
            catch (Exception ex)
            {
                throw new BusinessOperationException(new BusinesOperationExceptionModel
                {
                    ClassName = "UserRegisterInputBusinessOperation",
                    MethodName = "Create",
                    OriginalMessage = ex.Message
                }, ex);
            }
        }
    }
}
