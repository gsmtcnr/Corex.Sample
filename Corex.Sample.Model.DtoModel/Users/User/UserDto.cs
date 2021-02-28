namespace Corex.Sample.Model.DtoModel.Users.User
{
    public class UserDto : BaseCorexDtoIntModel
    {
        public UserDto()
        {

        }
        public UserDto(string password, string email)
        {
            Password = password;
            Email = email;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address  { get; set; }
    }
}
