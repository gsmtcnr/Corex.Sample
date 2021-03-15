using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.InputValidation.Users.User.Input
{
    public class UserEditInputModelAddressValidation : ValidationBase<UserEditInputModel>
    {
        public UserEditInputModelAddressValidation(UserEditInputModel item) : base(item)
        {
        }

        protected override void Validate()
        {
            AdressLimitValidation();
        }
        private void AdressLimitValidation()
        {
            StringLimitValidation(nameof(UserEditInputModel.Address), Item.Address, 512);
        }
    }
}
