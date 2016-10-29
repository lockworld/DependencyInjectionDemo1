namespace DI.Core.Messaging.Interfaces
{
    public interface IMessageService
    {
        void WriteMessage(IMessage message);

        void EmailMessage(IMessage message);
    }
}
