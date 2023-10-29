using aspnetapp.Models;

namespace aspnetapp.MessageHandlers;

public interface IMessageHandler
{
    string MsgType { get; }
    IReply Handle(IUserMessage message);
}