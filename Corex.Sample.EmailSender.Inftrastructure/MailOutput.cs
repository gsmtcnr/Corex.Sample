using Corex.EmailSender.Infrastructure;

namespace Corex.Sample.EmailSender.Inftrastructure
{
    public class MailOutput : IEmailOutput
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
