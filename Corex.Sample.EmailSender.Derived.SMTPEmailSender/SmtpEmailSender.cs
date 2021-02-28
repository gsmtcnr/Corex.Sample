using Corex.EmailSender.Derived.SMTP;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.EmailSender.Inftrastructure;
using Microsoft.Extensions.Configuration;
using System;

namespace Corex.Sample.EmailSender.Derived.SMTPEmailSender
{
    public class SmtpEmailSender : BaseSMTPEmailSender, ICorexEmailSender
    {
        public override SMTPInformation CreateInformation()
        {
            //appsettings üzerinden SMTP bilgilerinizi girmelisiniz.
            //SMTP kullanımı için burada bilgilerimizi belirtmemiz yeterli olacaktır.
            IConfigurationRoot configurationRoot = IoCManager.Resolve<IConfigurationRoot>();
            IConfigurationSection conf = configurationRoot.GetSection("EmailSettings");
            SMTPInformation smtpInformation = new SMTPInformation
            {
                From = conf["from"],
                Password = conf["password"],
                Host = conf["host"],
                Port = Convert.ToInt32(conf["port"]),

            };
            return smtpInformation;
        }
    }
}
