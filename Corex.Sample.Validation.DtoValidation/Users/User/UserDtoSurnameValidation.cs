using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.DtoValidation.Users.User
{
    public class UserDtoSurnameValidation : ValidationBase<UserDto>
    {
        public UserDtoSurnameValidation(UserDto item) : base(item)
        {
        }

        protected override void Validate()
        {
            SurnameLimitValidation();
        }
        private void SurnameRequiredValidation()
        {
            StringRequiredValidation(nameof(UserDto.Surname), Item.Surname);
        }
        private void SurnameLimitValidation()
        {
            StringLimitValidation(nameof(UserDto.Surname), Item.Surname, 32);
        }
    }
}
