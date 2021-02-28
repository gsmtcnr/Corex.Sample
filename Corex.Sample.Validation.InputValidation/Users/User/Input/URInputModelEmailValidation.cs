using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.InputValidation.Users.User.Input
{
    public class URInputModelEmailValidation : ValidationBase<UserRegisterInputModel>
    {
        public URInputModelEmailValidation(UserRegisterInputModel item) : base(item)
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
            StringRequiredValidation(nameof(UserRegisterInputModel.Email), Item.Email);
        }
        private void EmailLimitValidation()
        {
            StringLimitValidation(nameof(UserRegisterInputModel.Email), Item.Email, 32);
        }
        private void EmailFormatValidation()
        {
            
            if (!EmailFormatIsValid(Item.Email))
            {
                IsValid = false;
                Messages.Add(new ValidationMessage()
                {
                    Code = ValidationConstans.NOTVALID_VALUE,
                    Message = CodeFormat(nameof(UserRegisterInputModel.Email))
                });
            }
        }
    }
}
