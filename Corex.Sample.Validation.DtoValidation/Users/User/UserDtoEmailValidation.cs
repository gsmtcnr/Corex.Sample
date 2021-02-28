using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.DtoValidation.Users.User
{
    public class UserDtoEmailValidation : ValidationBase<UserDto>
    {
        public UserDtoEmailValidation(UserDto item) : base(item)
        {
        }

        protected override void Validate()
        {
            EmailRequiredValidation();
            EmailLimitValidation();
            EmailFormatValidation();
        }
        private void EmailRequiredValidation()
        {
            StringRequiredValidation(nameof(UserDto.Email), Item.Email);
        }
        private void EmailLimitValidation()
        {
            StringLimitValidation(nameof(UserDto.Email), Item.Email, 32);
        }
        private void EmailFormatValidation()
        {
            //Base'den sadece format methodunu alıp message'a kendim ekleyebilirim.
            //Böylece istediğim code ve message değerini set edebilirim.
            if (!EmailFormatIsValid(Item.Email))
            {
                IsValid = false;
                Messages.Add(new ValidationMessage()
                {
                    Code = ValidationConstans.NOTVALID_VALUE,
                    Message = CodeFormat(nameof(UserDto.Email))
                });
            }
        }
    }
}
