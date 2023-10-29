using System.Text.Json.Serialization;

namespace aspnetapp.Models;

public class TextUserMessage : UserMessageBase
{
}

public class ImageUserMessage : UserMessageBase
{
    /// <summary>
    /// 图片链接（由系统生成）
    /// </summary>
    [JsonPropertyName("PicUrl")]
    public string PicUrl { get; set; }
    
    /// <summary>
    /// 图片消息媒体id，可以调用获取临时素材接口拉取数据
    /// </summary>
    [JsonPropertyName("MediaId")]
    public string MediaId { get; set; }
}

public class VoiceUserMessage : UserMessageBase
{
    /// <summary>
    /// 语音消息媒体id，可以调用获取临时素材接口拉取该媒体
    /// </summary>
    [JsonPropertyName("MediaId")]
    public string MediaId { get; set; }
    
    /// <summary>
    /// 语音格式，如amr，speex等
    /// </summary>
    [JsonPropertyName("Format")]
    public string Format { get; set; }
    
    /// <summary>
    /// 语音识别结果，UTF8编码
    /// </summary>
    [JsonPropertyName("Recognition")]
    public string Recognition { get; set; }
}

public class VideoUserMessage : UserMessageBase
{
    /// <summary>
    /// 视频消息媒体id，可以调用获取临时素材接口拉取数据
    /// </summary>
    [JsonPropertyName("MediaId")]
    public string MediaId { get; set; }
    
    /// <summary>
    /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据
    /// </summary>
    [JsonPropertyName("ThumbMediaId")]
    public string ThumbMediaId { get; set; }
}

public class ShortVideoUserMessage : VideoUserMessage
{
}

public class GeographicLocationUserMessage : UserMessageBase
{
    /// <summary>
    /// 地理位置纬度
    /// </summary>
    [JsonPropertyName("Location_X")]
    public double LocationX { get; set; }
    
    /// <summary>
    /// 地理位置经度
    /// </summary>
    [JsonPropertyName("Location_Y")]
    public double LocationY { get; set; }
    
    /// <summary>
    /// 地图缩放大小
    /// </summary>
    [JsonPropertyName("Scale")]
    public string Scale { get; set; }
    
    /// <summary>
    /// 地理位置信息
    /// </summary>
    [JsonPropertyName("Label")]
    public string Label { get; set; }
}

public class LinkUserMessage : UserMessageBase
{
    /// <summary>
    /// 消息标题
    /// </summary>
    [JsonPropertyName("Title")]
    public string Title { get; set; }
    
    /// <summary>
    /// 消息描述
    /// </summary>
    [JsonPropertyName("Description")]
    public double Description { get; set; }
    
    /// <summary>
    /// 消息链接
    /// </summary>
    [JsonPropertyName("Url")]
    public string Url { get; set; }
}

public class UserMessageBase : MessageBase, IUserMessage
{
    /// <summary>
    /// 文本消息内容
    /// </summary>
    [JsonPropertyName("Content")]
    public string? Content { get; set; }

    /// <summary>
    /// 消息id，64位整型
    /// </summary>
    [JsonPropertyName("MsgId")]
    public long MsgId { get; set; }

    /// <summary>
    /// 消息的数据ID（消息如果来自文章时才有）
    /// </summary>
    [JsonPropertyName("MsgDataId")]
    public string? MsgDataId { get; set; }

    /// <summary>
    /// 多图文时第几篇文章，从1开始（消息如果来自文章时才有）
    /// </summary>
    [JsonPropertyName("Idx")]
    public string? Idx { get; set; }
}

public interface IUserMessage
{
    public string? MsgType { get; set; }
}

public class MessageBase
{
    /// <summary>
    /// 接收：开发者微信号
    /// 回复：接收方账号（收到的OpenID）
    /// </summary>
    [JsonPropertyName("ToUserName")]
    public string? ToUserName { get; set; }

    /// <summary>
    /// 接收：发送方账号（一个OpenID）
    /// 回复：开发者微信号
    /// </summary>
    [JsonPropertyName("FromUserName")]
    public string? FromUserName { get; set; }

    /// <summary>
    /// 消息创建时间 （整型）
    /// </summary>
    [JsonPropertyName("CreateTime")]
    public long CreateTime { get; set; }

    /// <summary>
    /// 消息类型
    /// 接收：
    /// 文本为text
    /// 图片为image
    /// 语音为voice
    /// 视频为video
    /// 小视频为shortvideo
    /// 地理位置为location
    /// 事件推送为event
    /// 回复：
    /// 文本为text
    /// 图片为image
    /// 语音为voice
    /// 视频为video
    /// 音乐为music
    /// 图文为news
    /// </summary>
    [JsonPropertyName("MsgType")]
    public string? MsgType { get; set; }
}