using Corex.Sample.Model.ViewModel.Users.User.Inputs;

namespace Corex.Sample.Model.ViewModel.Users.Inputs
{
    public class UserUpdateInputModel : IUserInputModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
