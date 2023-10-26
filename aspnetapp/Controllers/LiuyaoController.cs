#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetapp;
using aspnetapp.Liuyao;

namespace aspnetapp.Controllers;

[Route("api/liuyao")]
[ApiController]
public class LiuyaoController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<LiuyaoResponse>> PostCounter(LiuyaoRequest data)
    {
        var input = JsonSerializer.Deserialize<InputV2>(data.Content)!;
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