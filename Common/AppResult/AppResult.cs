using static Dm.net.buffer.ByteArrayBuffer;

namespace ChatApi.Common.Result;

public class AppResult
{
    public ResultRCode Code { get; set; }
    public Object? Data { get; set; }
    public string? Msg { get; set; }
    public static AppResult Ok()
    {
        return new AppResult()
        {
            Code = ResultRCode.Ok,
            Msg = "操作成功"
        };
    }
    public static AppResult OkMessage(string message)
    {
        return new AppResult()
        {
            Code = ResultRCode.Ok,
            Msg = message
        };
    }
    public static AppResult OkData(object data)
    {
        return new AppResult()
        {
            Code = ResultRCode.Ok,
            Msg = "SUCCESS",
            Data = data
        };
    }
    public static AppResult OkDetailed(Object data, string message)
    {
        return new AppResult()
        {
            Code = ResultRCode.Ok,
            Msg = message,
            Data = data
        };
    }
    public static AppResult Error()
    {
        return new AppResult()
        {
            Code = ResultRCode.Error,
            Msg = "操作失败"
        };
    }
    public static AppResult ErrorMessage(string message)
    {
        return new AppResult()
        {
            Code = ResultRCode.Error,
            Msg = message
        };
    }
    public static AppResult ErrorData(object data)
    {
        return new AppResult()
        {
            Code = ResultRCode.Error,
            Data = data,
            Msg = "操作失败"
        };
    }
    public static AppResult ErrorDetailed(object data, string message)
    {
        return new AppResult()
        {
            Code = ResultRCode.Error,
            Data = data,
            Msg = message
        };
    }
    public static AppResult Fail()
    {
        return new AppResult()
        {
            Code = ResultRCode.Fail,
            Msg = "操作失败"
        };
    }
    public static AppResult FailMessage(string message)
    {
        return new AppResult()
        {
            Code = ResultRCode.Fail,
            Msg = message
        };
    }
    public static AppResult FailData(object data)
    {
        return new AppResult()
        {
            Code = ResultRCode.Fail,
            Data = data,
            Msg = "操作失败"
        };
    }
    public static AppResult FailDetailed(object data, string message)
    {
        return new AppResult()
        {
            Code = ResultRCode.Fail,
            Msg = message,
            Data = data
        };
    }
}



public enum ResultRCode
{

    Ok,
    Fail,
    Error
}