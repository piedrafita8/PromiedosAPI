namespace PromiedosApi.Infrastructure.Exceptions;

public class PromiedosApiException : Exception
{
    public string messageApi { get; set; }
    public PromiedosApiException(string message) : base(message)
    {
        messageApi = message;
    }
}