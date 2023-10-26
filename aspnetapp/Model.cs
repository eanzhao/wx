using System;
using System.Text.Json.Serialization;

namespace aspnetapp;

public class Counter
{
    public int id { get; set; }
    public int count { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}

public class LiuyaoRequest
{
    [JsonPropertyName("ToUserName")] public string? ToUserName { get; set; }
    [JsonPropertyName("FromUserName")] public string? FromUserName { get; set; }
    [JsonPropertyName("CreateTime")] public long CreateTime { get; set; }
    [JsonPropertyName("MsgType")] public string? MsgType { get; set; }
    [JsonPropertyName("Content")] public string? Content { get; set; }
    [JsonPropertyName("MsgId")] public long MsgId { get; set; }
}

public class LiuyaoResponse
{
    [JsonPropertyName("ToUserName")] public string? ToUserName { get; set; }
    [JsonPropertyName("FromUserName")] public string? FromUserName { get; set; }
    [JsonPropertyName("CreateTime")] public long CreateTime { get; set; }
    [JsonPropertyName("MsgType")] public string? MsgType { get; set; }
    [JsonPropertyName("Content")] public string? Content { get; set; }
}