namespace ChatApi.Common.Result;

public partial class AppResultException : Exception
{


    public AppResult AppResult { get; private set; }

    public Exception? SourceException { get; private set; }


    public AppResultException() : this(new AppResult())
    {

    }

    public AppResultException(AppResult result) : this(result, null)
    {

    }

    public AppResultException(Exception exception) : this(new AppResult(), exception)
    {

    }

    public AppResultException(AppResult result, Exception? sourceException)
    {
        AppResult = result;
        SourceException = sourceException;
    }

}

public partial class AppResultException : Exception
{
    public static AppResultException FailMessageException(string message,Exception? exception=null)

        => new(AppResult.FailMessage(message),exception);



    public static AppResultException ErrorMessageException(string message, Exception? exception = null)
        => new(AppResult.ErrorMessage(message), exception);

}