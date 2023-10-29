using aspnetapp.MessageHandlers;
using aspnetapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetapp.Controllers;

[Route("api/v1")]
[ApiController]
public class MainController : ControllerBase
{
    private IEnumerable<IMessageHandler> _messageHandlers = new List<IMessageHandler>
    {
        new TextMessageHandler(),
        new EventMessageHandler()
    };

    [HttpPost]
    public async Task<ActionResult<IReply>> Post(IUserMessage message)
    {
        if (message.MsgType == null)
        {
            return Ok();
        }

        var handler = _messageHandlers.Single(h => message.MsgType.ToLower() == h.MsgType);
        return new ActionResult<IReply>(handler.Handle(message));
    }
}