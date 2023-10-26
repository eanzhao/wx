namespace aspnetapp.Liuyao;


public class GuaGenerator
{
    public Gua Generate(六十四卦 前卦, 六十四卦 后卦)
    {
        var shiYing = 世爻应爻(前卦);
        var name = 卦名(前卦, 后卦);
        var gua = new Gua
        {
            卦名 = name,
            世爻 = shiYing.世爻,
            应爻 = shiYing.应爻,
            五行 = 五行(前卦),
            前卦装卦 = 装卦(前卦),
            后卦装卦 = 装卦(后卦)
        };
        return gua;
    }

    private string 卦名(六十四卦 前卦, 六十四卦 后卦)
    {
        return 前卦 != 后卦 ? $"{前卦}之{后卦}" : 前卦.ToString();
    }

    private 世爻应爻 世爻应爻(六十四卦 gua)
    {
        var mod = (int)gua % 8;
        switch (mod)
        {
            case 0:
                return new 世爻应爻(6, 3);
            case 1 or 2 or 3:
                return new 世爻应爻(mod, mod + 3);
            case 4 or 5:
                return new 世爻应爻(mod, mod - 3);
            case 6:
                return new 世爻应爻(4, 1);
            case 7:
                return new 世爻应爻(3, 6);
            default:
                throw new ArgumentException();
        }
    }

    private 五行 五行(六十四卦 gua)
    {
        var res = (int)gua / 8;
        switch (res)
        {
            case 0 or 7:
                return Liuyao.五行.金;
            case 1:
                return Liuyao.五行.水;
            case 2 or 6:
                return Liuyao.五行.土;
            case 3 or 4:
                return Liuyao.五行.木;
            case 5:
                return Liuyao.五行.火;
            default:
                throw new ArgumentException();
        }
    }

    private string 装卦(六十四卦 gua)
    {
        八卦 上卦;
        八卦 下卦;
        var name = gua.ToString();
        if (name.Contains('为'))
        {
            上卦 = Enum.Parse<八卦>(name[0].ToString());
            下卦 = 上卦;
        }
        else
        {
            上卦 = Enum.Parse<八卦>(Constants.名称八卦[name[0]]);
            下卦 = Enum.Parse<八卦>(Constants.名称八卦[name[1]]);
        }

        return 装卦(上卦, 下卦);
    }

    private string 装卦(八卦 上卦, 八卦 下卦)
    {
        return $"{Constants.装卦歌[下卦][内外卦.内卦]}{Constants.装卦歌[上卦][内外卦.外卦]}";
    }
}

public record 世爻应爻(int 世爻, int 应爻);