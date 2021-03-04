using Corex.EmailSender.Infrastructure;
using Corex.Operation.Inftrastructure;
using System.Threading.Tasks;

namespace Corex.Sample.Operation.MailOperation
{
    public interface IMailOperation : IBusinessOperation
    {
        Task<IEmailOutput> Send(IMailActionInputModel mailActionInputModel);
    }
}
