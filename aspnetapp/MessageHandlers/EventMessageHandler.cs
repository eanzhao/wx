using aspnetapp.Models;

namespace aspnetapp.MessageHandlers;

public class EventMessageHandler : IMessageHandler
{
    public string MsgType => "event";
    public IReply Handle(IUserMessage message)
    {
        throw new NotImplementedException();
    }
}