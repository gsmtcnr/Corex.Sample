using Corex.EmailSender.Infrastructure;

namespace Corex.Sample.EmailSender.Inftrastructure
{
    public class MailInput : IEmailInput
    {
        public string To { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
    }
}
