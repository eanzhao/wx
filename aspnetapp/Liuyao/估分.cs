namespace aspnetapp.Liuyao;

public class 估分
{
    public Dictionary<string, int> 阵营得分 { get; set; } = new();

    public int 结果()
    {
        return 阵营得分.Sum(pair => pair.Value);
    }

    public void Add(string 阵营, int 分数)
    {
        if (阵营得分.ContainsKey(阵营))
        {
            阵营得分[阵营] += 分数;
        }
        else
        {
            阵营得分[阵营] = 分数;
        }
    }

    public override string ToString()
    {
        return 阵营得分.Aggregate(string.Empty, (current, pair) => current + $"{pair.Key}: {pair.Value}\n");
    }
}