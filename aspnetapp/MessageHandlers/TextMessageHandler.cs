using aspnetapp.Models;

namespace aspnetapp.MessageHandlers;

public class TextMessageHandler : IMessageHandler
{
    public string MsgType => "text";

    public IReply Handle(IUserMessage message)
    {
        var textMessage = (TextUserMessage)message;
        var reply = new TextReply
        {
            FromUserName = textMessage.ToUserName,
            ToUserName = textMessage.FromUserName,
            CreateTime = textMessage.CreateTime + 100,
            MsgType = "text"
        };
        var content = textMessage.Content;
        if (content == null)
        {
            return reply;
        }

        reply.Content = new LiuyaoTextMessageService().Jiegua(content);
        return reply;
    }
}