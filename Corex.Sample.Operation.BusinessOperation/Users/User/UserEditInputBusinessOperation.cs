using Corex.ExceptionHandling.Derived.Business;
using Corex.ExceptionHandling.Infrastructure.Models;
using Corex.Operation.Derived.BusinessOperation;
using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using System;

namespace Corex.Sample.Operation.BusinessOperation.Users.User
{
    public class UserEditInputBusinessOperation : BaseBusinessOperation, IUserEditInputBusinessOperation
    {
        public UserDto Edit(UserDto userDto, IUserInputModel inputModel)
        {
            UserEditInputModel editInputModel = (UserEditInputModel)inputModel;
            NullCheck(editInputModel);
            try
            {
                userDto.Name = editInputModel.Name;
                userDto.Surname = editInputModel.Surname;
                userDto.Address = editInputModel.Address;
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
