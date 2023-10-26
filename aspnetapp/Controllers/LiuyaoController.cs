#nullable disable
using Microsoft.AspNetCore.Mvc;
using aspnetapp.Liuyao;

namespace aspnetapp.Controllers;

[Route("api/liuyao")]
[ApiController]
public class LiuyaoController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<LiuyaoResponse>> PostGua(LiuyaoRequest data)
    {
        if (data.Content == null)
        {
            return Ok();
        }

        var content = data.Content.Split(' ');
        var input = new InputV2
        {
            月支 = content[0],
            日干支 = content[1],
            卦名 = content[2],
            用神 = content[3]
        };
        var gua = new FactoryV2().Create(input);

        if (!Enum.TryParse(input.用神, out 六亲 用神))
        {
            if (input.用神 == "世爻")
            {
                用神 = gua.六爻.Single(yao => yao.世爻).六亲[0];
            }
            else
            {
                throw new Exception("缺少用神");
            }
        }

        var score = gua.Score(用神);
        return new ActionResult<LiuyaoResponse>(new LiuyaoResponse
        {
            ToUserName = data.FromUserName,
            FromUserName = data.ToUserName,
            MsgType = data.MsgType,
            CreateTime = data.CreateTime + 1000,
            Content = score.ToString()
        });
    }
}