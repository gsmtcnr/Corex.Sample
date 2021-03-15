using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.InputValidation.Users.User.Input
{
    public class UserEditInputModelSurnameValidation : ValidationBase<UserEditInputModel>
    {
        public UserEditInputModelSurnameValidation(UserEditInputModel item) : base(item)
        {
        }

        protected override void Validate()
        {
            SurnameLimitValidation();
        }
        private void SurnameRequiredValidation()
        {
            StringRequiredValidation(nameof(UserEditInputModel.Surname), Item.Surname);
        }
        private void SurnameLimitValidation()
        {
            StringLimitValidation(nameof(UserEditInputModel.Surname), Item.Surname, 32);
        }
    }
}
