using System.Text.Json.Serialization;

namespace aspnetapp.Models;

public class ArticleReply : ReplyBase
{
    /// <summary>
    /// 图文消息个数；当用户发送文本、图片、语音、视频、图文、地理位置这六种消息时，开发者只能回复1条图文消息；其余场景最多可回复8条图文消息
    /// </summary>
    [JsonPropertyName("ArticleCount")]
    public int ArticleCount { get; set; }

    /// <summary>
    /// 图文消息信息，注意，如果图文数超过限制，则将只发限制内的条数
    /// </summary>
    [JsonPropertyName("Articles")]
    public string Articles { get; set; }
    
    /// <summary>
    /// 图文消息标题
    /// </summary>
    [JsonPropertyName("Title")]
    public string Title { get; set; }
    
    /// <summary>
    /// 图文消息描述
    /// </summary>
    [JsonPropertyName("Description")]
    public string? Description { get; set; }
    
    /// <summary>
    /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
    /// </summary>
    [JsonPropertyName("PicUrl")]
    public string PicUrl { get; set; }
    
    /// <summary>
    /// 点击图文消息跳转链接
    /// </summary>
    [JsonPropertyName("Url")]
    public string Url { get; set; }
}

public class MusicReply : ReplyBase
{
    /// <summary>
    /// 音乐标题
    /// </summary>
    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 音乐描述
    /// </summary>
    [JsonPropertyName("Description")]
    public string? Description { get; set; }
    
    /// <summary>
    /// 音乐链接
    /// </summary>
    [JsonPropertyName("MusicURL")]
    public string? MusicURL { get; set; }
    
    /// <summary>
    /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐
    /// </summary>
    [JsonPropertyName("HQMusicUrl")]
    public string? HQMusicUrl { get; set; }
    
    /// <summary>
    /// 缩略图的媒体id，通过素材管理中的接口上传多媒体文件，得到的id
    /// </summary>
    [JsonPropertyName("ThumbMediaId")]
    public string ThumbMediaId { get; set; }
}

public class VideoReply : MediaReply
{
    /// <summary>
    /// 视频消息的标题
    /// </summary>
    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// 视频消息的描述
    /// </summary>
    [JsonPropertyName("Description")]
    public string? Description { get; set; }
}

public class MediaReply : ReplyBase
{
    /// <summary>
    /// 通过素材管理中的接口上传多媒体文件，得到的id
    /// </summary>
    [JsonPropertyName("MediaId")]
    public string MediaId { get; set; }
}

public class TextReply : ReplyBase
{
    /// <summary>
    /// 回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）
    /// </summary>
    [JsonPropertyName("Content")]
    public string? Content { get; set; }
}

public class ReplyBase : MessageBase, IReply
{
}

public interface IReply
{
}