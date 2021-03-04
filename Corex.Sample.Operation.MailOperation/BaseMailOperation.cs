using Corex.EmailSender.Infrastructure;
using Corex.ExceptionHandling.Derived.Business;
using Corex.ExceptionHandling.Infrastructure.Models;
using Corex.Operation.Derived.BusinessOperation;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.EmailSender.Inftrastructure;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Corex.Sample.Operation.MailOperation
{
    public abstract class BaseMailOperation : BaseBusinessOperation, IMailOperation
    {
        private readonly IMailSender _mailSender;
        private readonly IConfigurationSection _confSection;
        public BaseMailOperation()
        {
            _mailSender = IoCManager.Resolve<IMailSender>();
            IConfigurationRoot _configurationRoot = IoCManager.Resolve<IConfigurationRoot>();
            _confSection = _configurationRoot.GetSection("EmailSettings");
        }
        public virtual Task<IEmailOutput> Send(IMailActionInputModel mailActionInputModel)
        {
            try
            {
 
                return _mailSender.SendAsync(new MailInput
                {
                    To = mailActionInputModel.To,
                    Bcc = mailActionInputModel.Bcc,
                    Body = GetTemplate(mailActionInputModel.TemplateKey, mailActionInputModel.DynamicObject),
                    FromEmail = _confSection["from"].ToString(),
                    FromName = _confSection["sender"].ToString(),
                });
            }
            catch (System.Exception ex)
            {
                throw new BusinessOperationException(new BusinesOperationExceptionModel()
                {
                    MethodName = "Send",
                    ClassName = "BaseMailOperation",
                    Code = "IEmailOutput",
                    OriginalMessage = ex.ToString()
                });
            }
        }
        private string GetTemplate(string templateKey, object dynamicObject)
        {
            //TODO: Html parse template
            //TemplateKey'in config üzerinde html path karşılığı ve onun templateRender yapılması
            return string.Empty;
        }
    }
}
