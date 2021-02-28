using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.DtoValidation.Users.User
{
    public class UserDtoNameValidation : ValidationBase<UserDto>
    {
        public UserDtoNameValidation(UserDto item) : base(item)
        {
        }

        protected override void Validate()
        {
            NameRequiredValidation();
            NameLimitValidation();
        }
        private void NameRequiredValidation()
        {
            StringRequiredValidation(nameof(UserDto.Name), Item.Name);
        }
        private void NameLimitValidation()
        {
            StringLimitValidation(nameof(UserDto.Name), Item.Name, 32);
        }
    }
}
