using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.DtoValidation.Users.User
{
    public class UserDtoAddressValidation : ValidationBase<UserDto>
    {
        public UserDtoAddressValidation(UserDto item) : base(item)
        {
        }

        protected override void Validate()
        {
            SurnameLimitValidation();
        }
        private void SurnameLimitValidation()
        {
            StringLimitValidation(nameof(UserDto.Address), Item.Address, 512);
        }
    }
}
