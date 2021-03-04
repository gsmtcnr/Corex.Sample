using Corex.EmailSender.Infrastructure;
using Corex.Sample.Model.DtoModel.Users.User;
using System.Threading.Tasks;

namespace Corex.Sample.Operation.MailOperation.Users.User
{
    public interface IUserRegisterMailOperation : IMailOperation
    {
        Task<IEmailOutput> Welcome(UserDto userDto);
    }
}
