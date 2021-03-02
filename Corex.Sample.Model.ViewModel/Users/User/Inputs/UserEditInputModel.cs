namespace Corex.Sample.Model.ViewModel.Users.User.Inputs
{
    public class UserEditInputModel : IUserInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
