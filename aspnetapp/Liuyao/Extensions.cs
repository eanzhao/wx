namespace aspnetapp.Liuyao;

public static class Extensions
{
    /// <summary>
    /// 关系
    /// </summary>
    /// <param name="wo">我</param>
    /// <param name="ta">他</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static 关系 Guanxi(this int wo, int ta)
    {
        var distance = wo - ta;
        switch (distance)
        {
            case 0:
                return 关系.同我的;
            case 1 or -4:
                return 关系.生我的;
            case 2 or -3:
                return 关系.克我的;
            case 3 or -2:
                return 关系.我克的;
            case 4 or -1:
                return 关系.我生的;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static int ToInt(this 五行 wuxing)
    {
        return (int)wuxing;
    }

    public static int 五亲(this int @this, int that)
    {
        var distance = @this - that;
        switch (distance)
        {
            case 0:
                // 同我的
                return (int)八字五神.比肩;
            case 1 or -4:
                // 我生的，泻我的
                return (int)八字五神.伤官;
            case 2 or -3:
                // 我克的，耗我的
                return (int)八字五神.妻财;
            case 3 or -2:
                // 克我的
                return (int)八字五神.官杀;
            case 4 or -1:
                // 生我的
                return (int)八字五神.印绶;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static bool? IsHelpful(this int @this, int that)
    {
        switch ((八字五神)@this.五亲(that))
        {
            case 八字五神.印绶 or 八字五神.比肩:
                return true;
            case 八字五神.伤官:
                return null;
            case 八字五神.妻财 or 八字五神.官杀:
                return false;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static 五行 五行(this 地支 dizhi)
    {
        switch (dizhi)
        {
            case 地支.亥 or 地支.子:
                return Liuyao.五行.水;
            case 地支.寅 or 地支.卯:
                return Liuyao.五行.木;
            case 地支.巳 or 地支.午:
                return Liuyao.五行.火;
            case 地支.申 or 地支.酉:
                return Liuyao.五行.金;
            case 地支.辰 or 地支.戌 or 地支.丑 or 地支.未:
                return Liuyao.五行.土;
            default:
                throw new ArgumentOutOfRangeException(nameof(dizhi), dizhi, null);
        }
    }

    public static 五行 五行(this 天干 tiangan)
    {
        switch (tiangan)
        {
            case 天干.壬 or 天干.癸:
                return Liuyao.五行.水;
            case 天干.甲 or 天干.乙:
                return Liuyao.五行.木;
            case 天干.丙 or 天干.丁:
                return Liuyao.五行.火;
            case 天干.庚 or 天干.辛:
                return Liuyao.五行.金;
            case 天干.戊 or 天干.己:
                return Liuyao.五行.土;
            default:
                throw new ArgumentOutOfRangeException(nameof(tiangan), tiangan, null);
        }
    }

    public static int Evaluate(this 爻卦 gua, 六亲 yong, 五行 wuxing)
    {
        var 动爻 = gua.六爻.Where(y => y.动爻);
        var score = 0;

        foreach (var yao in 动爻)
        {
            var 动爻五神 = yong.六爻五神(yao.六亲[0]);
            var 变爻五神 = yong.六爻五神(yao.六亲[1]);
            yao.六爻五神 = new List<六爻五神> { 动爻五神, 变爻五神 };
            score += yao.六亲[0].Score(yong, 六爻常量.动爻分值);
            score += yao.六亲[1].Score(yong, 六爻常量.变爻分值);
        }

        score += gua.月支五行.Score(wuxing, 六爻常量.月支分值);
        score += gua.日干支五行[0].Score(wuxing, 六爻常量.日干分值);
        score += gua.日干支五行[1].Score(wuxing, 六爻常量.日支分值);

        return score;
    }

    public static int Evaluate(this 爻卦 gua, 六亲 yong, string? shen = null)
    {
        var 动爻 = gua.六爻.Where(y => y.动爻);
        var score = 0;
        var wuxing = gua.五行.反推五行(yong);

        var records = new List<string>();

        foreach (var yao in 动爻)
        {
            var 动爻五神 = yong.六爻五神(yao.六亲[0]);
            var 变爻五神 = yong.六爻五神(yao.六亲[1]);
            yao.六爻五神 = new List<六爻五神> { 动爻五神, 变爻五神 };
            var score1 = yao.六亲[0].Score(yong, 六爻常量.动爻分值);
            score += score1;
            var score2 = yao.六亲[1].Score(yong, 六爻常量.变爻分值);
            score += score2;

            records.Add($"动爻：{yao.六亲[0].ToString()}，{score1}\n变爻：{yao.六亲[1].ToString()}，{score2}");
        }

        var scoreYueZhi = gua.月支五行.Score(wuxing, 六爻常量.月支分值);
        score += scoreYueZhi;
        var scoreRiGan = gua.日干支五行[0].Score(wuxing, 六爻常量.日干分值);
        score += scoreRiGan;
        var scoreRiZhi = gua.日干支五行[1].Score(wuxing, 六爻常量.日支分值);
        score += scoreRiZhi;

        records.Add($"{wuxing.ToString()}，{scoreYueZhi}");
        records.Add($"{wuxing.ToString()}，{scoreRiGan}");
        records.Add($"{wuxing.ToString()}，{scoreRiZhi}");

        var comment = "平";
        switch (score)
        {
            case > 0:
            {
                comment = score > 10 ? "强" : "较强";
                if (score > 30)
                {
                    comment = "极强";
                }

                break;
            }
            case < 0:
            {
                comment = score < -10 ? "弱" : "较弱";
                if (score < -30)
                {
                    comment = "极弱";
                }

                break;
            }
        }

        return score;
    }

    public static 估分 Score(this 爻卦 gua, 六亲 yong)
    {
        var score = new 估分();

        if (gua.上卦(yong, Liuyao.六爻五神.用神))
        {
            var yongShen = gua.Evaluate(yong, Liuyao.六爻五神.用神.ToString());
            score.Add(Liuyao.六爻五神.用神.ToString(), yongShen);
        }

        if (gua.上卦(yong, Liuyao.六爻五神.元神))
        {
            var yuanShen = gua.Evaluate((六亲)(int)((五行)(int)yong).反推五行((int)Liuyao.六爻五神.元神), Liuyao.六爻五神.元神.ToString());
            score.Add(Liuyao.六爻五神.元神.ToString(), yuanShen);
        }

        if (gua.上卦(yong, Liuyao.六爻五神.忌神))
        {
            var jiShen = gua.Evaluate((六亲)(int)((五行)(int)yong).反推五行((六亲)(int)Liuyao.六爻五神.忌神),
                Liuyao.六爻五神.忌神.ToString());
            score.Add(Liuyao.六爻五神.忌神.ToString(), jiShen);
        }

        if (gua.上卦(yong, Liuyao.六爻五神.仇神))
        {
            var chouShen = gua.Evaluate((六亲)(int)((五行)(int)yong).反推五行((六亲)(int)Liuyao.六爻五神.仇神),
                Liuyao.六爻五神.仇神.ToString());
            score.Add(Liuyao.六爻五神.仇神.ToString(), chouShen);
        }

        if (gua.上卦(yong, Liuyao.六爻五神.闲神))
        {
            var xianShen = gua.Evaluate((六亲)(int)((五行)(int)yong).反推五行((六亲)(int)Liuyao.六爻五神.闲神),
                Liuyao.六爻五神.闲神.ToString());
            score.Add(Liuyao.六爻五神.闲神.ToString(), xianShen);
        }

        return score;
    }

    public static 估分 Score2(this 爻卦 gua, 六亲 yong)
    {
        var score = new 估分();

        foreach (var shen in new List<六爻五神>
                     { Liuyao.六爻五神.用神, Liuyao.六爻五神.元神, Liuyao.六爻五神.忌神, Liuyao.六爻五神.仇神, Liuyao.六爻五神.闲神 })
        {
            // if (gua.上卦(yong, shen))
            // {
            //     var shenScore = gua.Evaluate((六亲)(int)((五行)(int)yong).反推五行((int)shen), 六爻.六爻五神.元神.ToString());
            //     score.Add(shen.ToString(), shenScore);
            // }
        }

        return score;
    }

    public static 五行 反推五行(this 五行 wuxing, 六亲 liuqin)
    {
        foreach (var wx in new List<五行> { Liuyao.五行.金, Liuyao.五行.水, Liuyao.五行.木, Liuyao.五行.火, Liuyao.五行.土 }.Where(wx =>
                     wuxing.六亲(wx) == liuqin))
        {
            return wx;
        }

        throw new ArgumentException(nameof(liuqin));
    }

    public static 六爻五神 六爻五神(this 六亲 @this, 六亲 that)
    {
        return (六爻五神)((int)that).五亲((int)@this);
    }

    public static 六亲 六亲(this 五行 @this, 五行 that)
    {
        return (六亲)((int)that).五亲((int)@this);
    }

    public static bool? IsHelpful(this 六亲 @this, 六亲 that)
    {
        return ((int)@this).IsHelpful((int)that);
    }

    public static bool? IsHelpful(this 五行 @this, 五行 that)
    {
        return ((int)@this).IsHelpful((int)that);
    }

    public static int Score(this 六亲 @this, 六亲 that, int score)
    {
        var isHelpful = @this.IsHelpful(that);
        return isHelpful.HasValue ? isHelpful == true ? score : -score : 0;
    }

    public static int Score(this 五行 @this, 五行 that, int score)
    {
        var isHelpful = @this.IsHelpful(that);
        return isHelpful.HasValue ? isHelpful == true ? score : -score : 0;
    }

    public static bool 上卦(this 爻卦 gua, 六亲 yong, 六爻五神 shen)
    {
        var lq = (六亲)((五行)(int)shen).反推五行(yong);
        return gua.六爻.SelectMany(yao => yao.六亲).Any(l => l == lq);
    }

    public static 八卦 宫位(this 六十四卦 gua)
    {
        return (八卦)((int)gua / 8);
    }

    public static List<int> 动爻(this 六十四卦 @this, 六十四卦 that)
    {
        var dongYao = new List<int>();

        var 我 = Enum.Parse<六十四卦Flag>(@this.ToString());
        var 他 = Enum.Parse<六十四卦Flag>(that.ToString());
        var flags = 我 ^ 他;
        if (flags.HasFlag((六十四卦Flag)0x000001))
        {
            dongYao.Add(1);
        }

        if (flags.HasFlag((六十四卦Flag)0x000010))
        {
            dongYao.Add(2);
        }

        if (flags.HasFlag((六十四卦Flag)0x000100))
        {
            dongYao.Add(3);
        }

        if (flags.HasFlag((六十四卦Flag)0x001000))
        {
            dongYao.Add(4);
        }

        if (flags.HasFlag((六十四卦Flag)0x010000))
        {
            dongYao.Add(5);
        }

        if (flags.HasFlag((六十四卦Flag)0x100000))
        {
            dongYao.Add(6);
        }

        var output = dongYao.Aggregate("", (c, i) => $"{c}{i.ToString()} ");
        return dongYao;
    }

    public static 六十四卦Flag ParseToFlag(this 六十四卦 gua)
    {
        var name = gua.ToString();
        return Enum.Parse<六十四卦Flag>(name);
    }
}