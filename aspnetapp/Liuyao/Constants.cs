namespace aspnetapp.Liuyao;

public static class Constants
{
    public static readonly string[] 六十甲子纳音歌 =
    {
        "甲子乙丑海中金", "丙寅丁卯炉中火", "戊辰己巳大林木", "庚午辛未路傍土", "壬申癸酉剑锋金",
        "甲戌乙亥山头火", "丙子丁丑涧下水", "戊寅己卯城头土", "庚辰辛巳白蜡金", "壬午癸未杨柳木",
        "甲申乙酉泉中水", "丙戌丁亥屋上土", "戊子己丑霹雳火", "庚寅辛卯松柏木", "壬辰癸巳长流水",
        "甲午乙未砂中金", "丙申丁酉山下火", "戊戌己亥平地木", "庚子辛丑壁上土", "壬寅癸卯锡箔金",
        "甲辰乙巳覆灯火", "丙午丁未天河水", "戊申己酉大驿土", "庚戌辛亥钗钏金", "壬子癸丑桑拓木",
        "甲寅乙卯大溪水", "丙辰丁巳沙中土", "戊午己未天上火", "庚申辛酉石榴木", "壬戌癸亥大海水"
    };
    
    public static Dictionary<八卦, Dictionary<内外卦, string>> 装卦歌 = new()
    {
        {
            八卦.乾, new Dictionary<内外卦, string>
            {
                { 内外卦.内卦, "子寅辰" },
                { 内外卦.外卦, "午申戌" },
            }
        },
        {
            八卦.坎, new Dictionary<内外卦, string>
            {
                { 内外卦.内卦, "寅辰午" },
                { 内外卦.外卦, "申戌子" },
            }
        },
        {
            八卦.艮, new Dictionary<内外卦, string>
            {
                { 内外卦.内卦, "辰午申" },
                { 内外卦.外卦, "戌子寅" },
            }
        },
        {
            八卦.震, new Dictionary<内外卦, string>
            {
                { 内外卦.内卦, "子寅辰" },
                { 内外卦.外卦, "午申戌" },
            }
        },
        {
            八卦.巽, new Dictionary<内外卦, string>
            {
                { 内外卦.内卦, "丑亥酉" },
                { 内外卦.外卦, "未巳卯" },
            }
        },
        {
            八卦.离, new Dictionary<内外卦, string>
            {
                { 内外卦.内卦, "卯丑亥" },
                { 内外卦.外卦, "酉未巳" },
            }
        },
        {
            八卦.坤, new Dictionary<内外卦, string>
            {
                { 内外卦.内卦, "未巳卯" },
                { 内外卦.外卦, "丑亥酉" },
            }
        },
        {
            八卦.兑, new Dictionary<内外卦, string>
            {
                { 内外卦.内卦, "巳卯丑" },
                { 内外卦.外卦, "亥酉未" },
            }
        }
    };

    public static Dictionary<string, char> 八卦名称 = new()
    {
        { 八卦.乾.ToString(), '天' },
        { 八卦.坎.ToString(), '水' },
        { 八卦.艮.ToString(), '山' },
        { 八卦.震.ToString(), '雷' },
        { 八卦.巽.ToString(), '风' },
        { 八卦.离.ToString(), '火' },
        { 八卦.坤.ToString(), '地' },
        { 八卦.兑.ToString(), '泽' }
    };

    public static Dictionary<char, string> 名称八卦 = new()
    {
        { '天', 八卦.乾.ToString() },
        { '水', 八卦.坎.ToString() },
        { '山', 八卦.艮.ToString() },
        { '雷', 八卦.震.ToString() },
        { '风', 八卦.巽.ToString() },
        { '火', 八卦.离.ToString() },
        { '地', 八卦.坤.ToString() },
        { '泽', 八卦.兑.ToString() }
    };
}