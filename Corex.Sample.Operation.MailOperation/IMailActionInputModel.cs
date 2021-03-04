using Corex.Sample.Model.MailModel;

namespace Corex.Sample.Operation.MailOperation
{
    public interface IMailActionInputModel
    {
        string TemplateKey { get; set; }
        string To { get; set; }
        string Bcc { get; set; }
        IMailModel DynamicObject { get; set; }
    }
}
