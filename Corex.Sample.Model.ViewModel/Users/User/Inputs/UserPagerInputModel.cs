using Corex.Model.Infrastructure;

namespace Corex.Sample.Model.ViewModel.Users.User.Inputs
{
    public class UserPagerInputModel : BasePagerInputModel, IUserInputModel
    {
        public string Email { get; set; }
    }
}
