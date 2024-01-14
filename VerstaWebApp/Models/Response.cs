namespace VerstaWebApp.Models;

public class Response
{
    public int Status { get; set; }
    public string Message { get; set; }
}

public class Response<T>:Response
{
    public T? Data { get; set; }
}