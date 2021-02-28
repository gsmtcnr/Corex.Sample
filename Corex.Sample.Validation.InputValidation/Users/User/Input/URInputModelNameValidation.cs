using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.InputValidation.Users.User.Input
{
    /// <summary>
    /// UserRegisterInputModelNameValidation
    /// </summary>
    public class URInputModelNameValidation : ValidationBase<UserRegisterInputModel>
    {
        public URInputModelNameValidation(UserRegisterInputModel item) : base(item)
        {
        }

        protected override void Validate()
        {
            NameRequiredValidation();
            NameLimitValidation();
            SurnameRequiredValidation();
            SurnameLimitValidation();
        }
        private void NameRequiredValidation()
        {
            StringRequiredValidation(nameof(UserRegisterInputModel.Name), Item.Name);
        }
        private void NameLimitValidation()
        {
            StringLimitValidation(nameof(UserRegisterInputModel.Name), Item.Name, 32);
        }
        private void SurnameRequiredValidation()
        {
            StringRequiredValidation(nameof(UserRegisterInputModel.Surname), Item.Surname);
        }
        private void SurnameLimitValidation()
        {
            StringLimitValidation(nameof(UserRegisterInputModel.Surname), Item.Surname, 32);
        }
    }
}
