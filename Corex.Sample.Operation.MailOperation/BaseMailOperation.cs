using Corex.EmailSender.Infrastructure;
using Corex.ExceptionHandling.Derived.Business;
using Corex.ExceptionHandling.Infrastructure.Models;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.EmailSender.Inftrastructure;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Corex.Sample.Operation.MailOperation
{
    public abstract class BaseMailOperation : IMailOperation
    {
        private readonly IMailSender _mailSender;
        private readonly IConfigurationSection _confSection;
        public BaseMailOperation()
        {
            _mailSender = IoCManager.Resolve<IMailSender>();
            IConfigurationRoot _configurationRoot = IoCManager.Resolve<IConfigurationRoot>();
            _confSection = _configurationRoot.GetSection("EmailSettings");
        }
        public abstract IMailActionInputModel CreateInputModel();
        public virtual Task<IEmailOutput> Send()
        {
            try
            {
                IMailActionInputModel mailInput = CreateInputModel();
                return _mailSender.SendAsync(new MailInput
                {
                    To = mailInput.To,
                    Bcc = mailInput.Bcc,
                    Body = GetTemplate(mailInput.TemplateKey),
                    FromEmail = _confSection["fromEmail"].ToString(),
                    FromName = _confSection["fromName"].ToString(),
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
        private string GetTemplate(string templateKey)
        {
            //TODO: Html parse template
            //TemplateKey'in config üzerinde html path karşılığı ve onun templateRender yapılması
            return string.Empty;
        }
    }
}
