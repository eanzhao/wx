using System.Text.Json.Serialization;

namespace aspnetapp.Liuyao;


public class Input
{
    [JsonPropertyName("月支")] public string 月支 { get; set; }
    [JsonPropertyName("日干支")] public string 日干支 { get; set; }
    [JsonPropertyName("前卦装配地支")] public string 前卦装配地支 { get; set; }
    [JsonPropertyName("后卦装配地支")] public string 后卦装配地支 { get; set; }
    [JsonPropertyName("动爻的位置")] public List<int> 动爻的位置 { get; set; }
    [JsonPropertyName("前卦的五行属性")] public string 前卦的五行属性 { get; set; }
    [JsonPropertyName("用神")] public string 用神 { get; set; }
}