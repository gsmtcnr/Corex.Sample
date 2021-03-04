using Corex.Sample.Model.MailModel;

namespace Corex.Sample.Operation.MailOperation
{
    public class MailActionInputModel : IMailActionInputModel
    {
        public string TemplateKey { get; set; }
        public string To { get; set; }
        public string Bcc { get; set; }
        public IMailModel DynamicObject { get; set; }

    }
}
