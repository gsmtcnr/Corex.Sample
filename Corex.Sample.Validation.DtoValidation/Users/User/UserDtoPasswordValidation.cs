using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.DtoValidation.Users.User
{
    public class UserDtoPasswordValidation : ValidationBase<UserDto>
    {
        public UserDtoPasswordValidation(UserDto item) : base(item)
        {
        }

        protected override void Validate()
        {
            RequiredValidation();
            LimitValidation();
            MinLenghtValidation();
        }
        private void RequiredValidation()
        {
            StringRequiredValidation(nameof(UserDto.Password), Item.Password);
        }
        private void LimitValidation()
        {
            StringLimitValidation(nameof(UserDto.Password), Item.Password, 8);
        }
        private void MinLenghtValidation()
        {

            //Base'den sadece format methodunu alıp message'a kendim ekleyebilirim.
            //Böylece istediğim code ve message değerini set edebilirim.
            //Örn : 4 karakterden küçük ise..
            if (!string.IsNullOrEmpty(Item.Password) && Item.Password.Length < 4)
            {
                IsValid = false;
                Messages.Add(new ValidationMessage()
                {
                    Code = "Min_Length_4",
                    Message = CodeFormat(nameof(UserDto.Password))
                });
            }
        }
    }
}
