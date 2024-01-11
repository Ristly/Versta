namespace VerstaWebApi.Models.Wrapper;

public class Result
{
    public int Status { get; set; }
    public string Message { get; set; }

    public static Result Success(string message, int status = 200)
         => new Result { Status = status, Message = message };

    public static Result Fail(string message, int status)
        => new Result { Status = status, Message = message };
}

public class Result<T> : Result
{
    public T? Data { get; set; }

    public static Result<T> Success(string message, T data, int status = 200)
        => new Result<T> { Status = status, Data = data, Message = message };

    public static Result<T> Fail(string message, T? data, int status)
        => new Result<T> { Status = status, Data = data, Message = message };
}
