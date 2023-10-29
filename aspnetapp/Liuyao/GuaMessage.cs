using System.Text.Json.Serialization;

namespace aspnetapp.Liuyao;

public class GuaMessage
{
    [JsonPropertyName("月支")] public string 月支 { get; set; }
    [JsonPropertyName("日干支")] public string 日干支 { get; set; }
    [JsonPropertyName("卦名")] public string 卦名 { get; set; }
    [JsonPropertyName("用神")] public string 用神 { get; set; }
}