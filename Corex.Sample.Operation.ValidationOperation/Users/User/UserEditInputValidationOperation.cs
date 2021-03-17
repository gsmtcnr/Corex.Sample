using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Sample.Validation.InputValidation.Users.User.Input;
using Corex.Validation.Infrastucture;
using System.Collections.Generic;

namespace Corex.Sample.Operation.ValidationOperation.Users.User
{
    public class UserEditInputValidationOperation : CorexValidationOperation<UserEditInputModel>, IUserEditInputValidationOperation
    {
        public override List<ValidationBase<UserEditInputModel>> GetValidations()
        {
            List<ValidationBase<UserEditInputModel>> validationBases = new List<ValidationBase<UserEditInputModel>>()
            {
               new UserEditInputModelAddressValidation(Item),
               new UserEditInputModelNameValidation(Item),
               new UserEditInputModelSurnameValidation(Item)
            };
            return validationBases;
        }
    }
}
