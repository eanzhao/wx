using System.Text.Json.Serialization;

namespace aspnetapp.Models;

public class FollowingEvent : EventBase
{
    
}

public class ScanningQRCodeEvent : EventBase
{
    /// <summary>
    /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
    /// </summary>
    [JsonPropertyName("EventKey")]
    public string EventKey { get; set; }

    /// <summary>
    /// 二维码的ticket，可用来换取二维码图片
    /// </summary>
    [JsonPropertyName("Ticket")]
    public string Ticket { get; set; }
}

public class ReportingGeographicLocationEvent : EventBase
{
    /// <summary>
    /// 地理位置纬度
    /// </summary>
    [JsonPropertyName("Latitude")]
    public string Latitude { get; set; }

    /// <summary>
    /// 地理位置经度
    /// </summary>
    [JsonPropertyName("Longitude")]
    public string Longitude { get; set; }

    /// <summary>
    /// 地理位置精度
    /// </summary>
    [JsonPropertyName("Precision")]
    public string Precision { get; set; }
}

public class TappingMenuToPullMessageEvent : EventBase
{
    /// <summary>
    /// 事件KEY值，与自定义菜单接口中KEY值对应
    /// </summary>
    [JsonPropertyName("EventKey")]
    public string EventKey { get; set; }
}

public class TappingMenuToRedirectToUrlEvent : EventBase
{
    /// <summary>
    /// 事件KEY值，设置的跳转URL
    /// </summary>
    [JsonPropertyName("EventKey")]
    public string EventKey { get; set; }
}

public class EventBase : MessageBase, IUserMessage
{
    /// <summary>
    /// 事件类型
    /// 订阅：subscribe
    /// 取消订阅：unsubscribe
    /// 未关注用户扫描二维码：subscribe
    /// 已关注用户扫描二维码：scan
    /// 上报地理位置：location
    /// 自定义菜单：click
    /// 点击菜单跳转链接：view
    /// </summary>
    [JsonPropertyName("Event")]
    public string Event { get; set; }
}