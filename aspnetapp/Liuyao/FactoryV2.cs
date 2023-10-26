namespace aspnetapp.Liuyao;

public class FactoryV2
{
    public 爻卦 Create(string month, string day, string guaName, List<int>? 动爻 = null)
    {
        var guas = 拆卦(guaName);
        var generator = new GuaGenerator();
        var gua = generator.Generate(guas.Item1, guas.Item2);
        var 前卦五行 = gua.五行;

        if (动爻 == null)
        {
            动爻 = guas.Item1.动爻(guas.Item2);
        }

        var yaoGua = new 爻卦
        {
            五行 = 前卦五行,
            月支五行 = Enum.Parse<地支>(month).五行(),
            日干支五行 = new List<五行>
            {
                Enum.Parse<天干>(day[0].ToString()).五行(),
                Enum.Parse<地支>(day[1].ToString()).五行()
            },
            六爻 = new List<爻>()
        };

        for (var i = 1; i < 7; i++)
        {
            var is动爻 = 动爻.Contains(i);
            var beforeLoad = 前卦五行.六亲(Enum.Parse<地支>(gua.前卦装卦[i - 1].ToString()).五行());
            var afterLoad = 前卦五行.六亲(Enum.Parse<地支>(gua.后卦装卦[i - 1].ToString()).五行());
            var yao = new 爻
            {
                Rank = i,
                动爻 = is动爻,
                六亲 = is动爻 ? new List<六亲> { beforeLoad, afterLoad } : new List<六亲> { beforeLoad },
                应爻 = gua.应爻 == i,
                世爻 = gua.世爻 == i
            };
            yaoGua.六爻.Add(yao);
        }

        return yaoGua;
    }

    public 爻卦 Create(InputV2 input)
    {
        return Create(input.月支, input.日干支, input.卦名);
    }

    private (六十四卦, 六十四卦) 拆卦(string guaName)
    {
        if (guaName.Contains('之'))
        {
            var guas = guaName.Split('之');
            return (Enum.Parse<六十四卦>(guas[0]), Enum.Parse<六十四卦>(guas[1]));
        }

        var gua = Enum.Parse<六十四卦>(guaName);
        return (gua, gua);
    }
}