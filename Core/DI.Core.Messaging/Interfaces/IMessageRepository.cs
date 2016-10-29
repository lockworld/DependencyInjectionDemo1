using System.Net.Mail;

namespace DI.Core.Messaging.Interfaces
{
    public interface IMessageRepository
    {
        void WriteMessage(IMessage message);

        void EmailMessage(IMessage message);
    }
}
