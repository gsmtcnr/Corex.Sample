using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Sample.Validation.InputValidation.Users.User.Input;
using Corex.Validation.Infrastucture;
using System.Collections.Generic;

namespace Corex.Sample.Operation.ValidationOperation.Users.User
{
    public class UserRegisterInputValidationOperation : CorexValidationOperation<UserRegisterInputModel>, IUserRegisterInputValidationOperation
    {
        public override List<ValidationBase<UserRegisterInputModel>> GetValidations()
        {
            List<ValidationBase<UserRegisterInputModel>> validationBases = new List<ValidationBase<UserRegisterInputModel>>()
            {
                new URInputModelEmailValidation(Item),
                new URInputModelPasswordValidation(Item),
            };
            return validationBases;
        }
    }
}
