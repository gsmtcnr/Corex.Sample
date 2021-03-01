using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Validation.DtoValidation.Users.User;
using Corex.Validation.Infrastucture;
using System.Collections.Generic;

namespace Corex.Sample.Operation.ValidationOperation.Users.User
{
    public class UserDtoValidationOperation : CorexValidationOperation<UserDto>, IUserDtoValidationOperation
    {
        public override List<ValidationBase<UserDto>> GetValidations()
        {
            List<ValidationBase<UserDto>> validationBases = new List<ValidationBase<UserDto>>()
            {
                new UserDtoAddressValidation(Item),
                new UserDtoEmailValidation(Item),
                new UserDtoNameValidation(Item),
                new UserDtoPasswordValidation(Item),
                new UserDtoSurnameValidation(Item),
            };
            return validationBases;
        }
    }
}
