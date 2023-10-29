using System.Collections.Generic;

namespace aspnetapp.Liuyao;

/// <summary>
/// 爻卦
/// </summary>
public class 爻卦
{
    /// <summary>
    /// 六爻
    /// </summary>
    public List<爻> 六爻 { get; set; }

    public 五行 五行 { get; set; }
    public 五行 月支五行 { get; set; }
    public List<五行> 日干支五行 { get; set; }
}

public class 爻
{
    /// <summary>
    /// 次序
    /// </summary>
    public int Rank { get; set; }

    /// <summary>
    /// 是否为应爻
    /// </summary>
    public bool 应爻 { get; set; }

    /// <summary>
    /// 是否为世爻
    /// </summary>
    public bool 世爻 { get; set; }

    /// <summary>
    /// 是否为动爻
    /// </summary>
    public bool 动爻 { get; set; }

    /// <summary>
    /// 0.动爻，1.变爻
    /// </summary>
    public List<六亲> 六亲 { get; set; }

    public List<六爻五神> 六爻五神 { get; set; }

    /// <summary>
    /// 0.动爻五行，1.变爻五行
    /// </summary>
    public List<五行> 五行 { get; set; }

    public int Score { get; set; }
}