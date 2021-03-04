using Corex.Sample.Model.DtoModel.Users.User;

namespace Corex.Sample.Operation.MailOperation.Users.User
{
    public interface IUserRegisterMailOperation : IMailOperation
    {
        void Welcome(UserDto userDto);
    }
    public class UserRegisterMailOperation : BaseMailOperation, IUserRegisterMailOperation
    {
        public override MailActionInputModel CreateInputModel()
        {
            return new MailActionInputModel
            {
                TemplateKey = "userRegisterMail",
                To = GetTo(),
                DynamicObject = GetDynamicObject()
            }
        }

        public void Welcome(UserDto userDto)
        {
            throw new System.NotImplementedException();
        }
     
    }
}
