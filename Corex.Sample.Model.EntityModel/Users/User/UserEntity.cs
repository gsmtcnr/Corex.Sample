namespace Corex.Sample.Model.EntityModel.Users.User
{
    public class UserEntity : BaseCorexEntityIntModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
