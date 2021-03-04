using Corex.EmailSender.Infrastructure;
using Corex.Sample.Model.DtoModel.Users.User;
using Corex.Sample.Model.MailModel.Users.User;
using System.Threading.Tasks;

namespace Corex.Sample.Operation.MailOperation.Users.User
{
    public class UserRegisterMailOperation : BaseMailOperation, IUserRegisterMailOperation
    {
        public Task<IEmailOutput> Welcome(UserDto userDto)
        {
            return Send(CreateInputModel(userDto));
        }
        #region Private Methods
        private static UserRegisterMailModel CreateDynamicObject(UserDto userDto)
        {
            return new UserRegisterMailModel
            {
                Email = userDto.Email
            };
        }
        private static MailActionInputModel CreateInputModel(UserDto userDto)
        {
            return new MailActionInputModel
            {
                DynamicObject = CreateDynamicObject(userDto),
                TemplateKey = "user_Register_Welcome_Mail",
                To = userDto.Email
            };
        }
        #endregion
    }
}
