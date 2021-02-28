using Corex.Sample.Model.ViewModel.Users.User.Inputs;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.InputValidation.Users.User.Input
{
    public class URInputModelPasswordValidation : ValidationBase<UserRegisterInputModel>
    {
        public URInputModelPasswordValidation(UserRegisterInputModel item) : base(item)
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
            StringRequiredValidation(nameof(UserRegisterInputModel.Password), Item.Password);
        }
        private void LimitValidation()
        {
            StringLimitValidation(nameof(UserRegisterInputModel.Password), Item.Password, 8);
        }
        private void MinLenghtValidation()
        {

            if (!string.IsNullOrEmpty(Item.Password) && Item.Password.Length < 4)
            {
                IsValid = false;
                Messages.Add(new ValidationMessage()
                {
                    Code = "Min_Length_4",
                    Message = CodeFormat(nameof(UserRegisterInputModel.Password))
                });
            }
        }
    }
}
