using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.InputValidation.Users.User.Input
{
    public class UserEditInputModelNameValidation : ValidationBase<UserEditInputModel>
    {
        public UserEditInputModelNameValidation(UserEditInputModel item) : base(item)
        {
        }

        protected override void Validate()
        {
            NameRequiredValidation();
        }
        private void NameRequiredValidation()
        {
            StringRequiredValidation(nameof(UserEditInputModel.Name), Item.Name);
        }
        private void NameLimitValidation()
        {
            StringLimitValidation(nameof(UserEditInputModel.Name), Item.Name, 32);
        }
    }
}
