using Corex.Operation.Inftrastructure;
using Corex.Sample.Model.DtoModel.Users.User;

namespace Corex.Sample.Operation.BusinessOperation.Users.User
{
    public interface IUserPasswordEncryptBusinessOperation : IBusinessOperation
    {
        public UserDto Encrypt(UserDto userDto);
    }
}
