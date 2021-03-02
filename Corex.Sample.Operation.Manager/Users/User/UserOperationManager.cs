using Corex.ExceptionHandling.Derived.Validation;
using Corex.ExceptionHandling.Infrastructure.Models;
using Corex.Model.Infrastructure;
using Corex.Operation.Infrastructure;
using Corex.Operation.Manager;
using Corex.Operation.Manager.Results;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.EntityModel.Users.User;
using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Sample.Operation.BusinessOperation.Users.User;
using Corex.Sample.Operation.DataOperation.Users.User;
using Corex.Sample.Operation.ValidationOperation.Users.User;
using Corex.Validation.Infrastucture;
using System.Collections.Generic;
using System.Linq;

namespace Corex.Sample.Operation.Manager.Users.User
{
    public class UserOperationManager : CorexIntOperationManager<UserEntity, UserDto>, IUserOperationManager
    {
        #region Edit Operations
        public IResultObjectModel<UserDto> Edit(IUserInputModel inputModel)
        {

            IResultObjectModel<UserDto> resultObjectModel = new ResultObjectModel<UserDto>();
            try
            {
                //UserEditInputModel için özel bir validationOperation'da tercih edilebilir.
                UserEditInputModel userEditInputModel = (UserEditInputModel)inputModel;
                IResultObjectModel<UserDto> editResult = EditUserDtoByInputModel(inputModel, userEditInputModel);
                resultObjectModel = UpdateByEditResult(resultObjectModel, editResult);
            }
            catch (System.Exception ex)
            {
                resultObjectModel.IsSuccess = false;
                ExceptionManager exceptionManager = new ExceptionManager(ex);
                resultObjectModel.Messages.AddRange(exceptionManager.GetMessages());
            }
            resultObjectModel.SetResult();
            return resultObjectModel;
        }
        #region Private Methods
        private IResultObjectModel<UserDto> UpdateByEditResult(IResultObjectModel<UserDto> resultObjectModel, IResultObjectModel<UserDto> editResult)
        {
            if (editResult.IsSuccess)
                resultObjectModel = Update(editResult.Data);
            else
                resultObjectModel.Messages.AddRange(editResult.Messages);
            return resultObjectModel;
        }
        private IResultObjectModel<UserDto> EditUserDtoByInputModel(IUserInputModel inputModel, UserEditInputModel userEditInputModel)
        {
            IResultObjectModel<UserDto> getResult = Get(userEditInputModel.Id);
            if (getResult.IsSuccess)
            {
                IUserEditInputBusinessOperation userEditBusinessOperation = IoCManager.Resolve<IUserEditInputBusinessOperation>();
                getResult.Data = userEditBusinessOperation.Edit(getResult.Data, inputModel);
            }
            getResult.SetResult();
            return getResult;
        }
        #endregion
        #endregion
        #region Register Operations
        public IResultObjectModel<UserDto> Register(IUserInputModel inputModel)
        {
            IResultObjectModel<UserDto> resultObjectModel = new ResultObjectModel<UserDto>();
            try
            {
                RegisterInputValidation(inputModel);
                UserDto userDto = CreateUserDtoByRegisterInputModel(inputModel);
                userDto = EncryptUserDtoPassword(userDto);
                resultObjectModel = Insert(userDto);
            }
            catch (System.Exception ex)
            {
                resultObjectModel.IsSuccess = false;
                ExceptionManager exceptionManager = new ExceptionManager(ex);
                resultObjectModel.Messages.AddRange(exceptionManager.GetMessages());
            }
            resultObjectModel.SetResult();
            return resultObjectModel;
        }
        #region Private Methods
        private static UserDto EncryptUserDtoPassword(UserDto userDto)
        {
            IUserPasswordEncryptBusinessOperation passwordEncryptBusinessOperation = IoCManager.Resolve<IUserPasswordEncryptBusinessOperation>();
            userDto = passwordEncryptBusinessOperation.Encrypt(userDto);
            return userDto;
        }
        private static UserDto CreateUserDtoByRegisterInputModel(IUserInputModel inputModel)
        {
            IUserRegisterInputBusinessOperation registerBusinessOperation = IoCManager.Resolve<IUserRegisterInputBusinessOperation>();
            UserDto userDto = registerBusinessOperation.Create(inputModel);
            return userDto;
        }
        private static void RegisterInputValidation(IUserInputModel inputModel)
        {
            IUserRegisterInputValidationOperation registerInputValidationOperation = IoCManager.Resolve<IUserRegisterInputValidationOperation>();
            registerInputValidationOperation.SetItem((UserRegisterInputModel)inputModel);
            List<ValidationMessage> messages = registerInputValidationOperation.GetValidationResults();
            if (messages.Any())
            {
                throw new ValidationOperationException(new ValidationExceptionModel()
                {
                    ModelName = nameof(UserRegisterInputModel),
                    OriginalMessage = "Register-Model not valid",
                    ValidationMessages = messages.Select(v =>
                    new ValidationExceptionMessage
                    {
                        Code = v.Code,
                        Message = v.Message
                    }).ToList()
                });
            }
        }
        #endregion
        #endregion
        #region Abstract Methods
        public override IDataOperation<UserEntity, int> SetDataOperation()
        {
            return IoCManager.Resolve<IUserDataOperation>();
        }
        public override IValidationOperation<UserDto> SetInsertValidationOperation(UserDto dto)
        {
            var validationOperation = IoCManager.Resolve<IUserDtoValidationOperation>();
            validationOperation.SetItem(dto);
            return validationOperation;
        }
        public override IValidationOperation<UserDto> SetUpdateValidationOperation(UserDto dto)
        {
            var validationOperation = IoCManager.Resolve<IUserDtoValidationOperation>();
            validationOperation.SetItem(dto);
            return validationOperation;
        }
        #endregion
    }
}
