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
        }
        private void RequiredValidation()
        {
            StringRequiredValidation(nameof(UserDto.Password), Item.Password);
        }
        private void LimitValidation()
        {
            StringLimitValidation(nameof(UserDto.Password), Item.Password, 64);
        }
    }
}
