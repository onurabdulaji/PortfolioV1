namespace PortfolioV1.Application.Commons.Operations;

public class OperationResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public static OperationResult Success(string message = null) => new OperationResult { IsSuccess = true, Message = message };
    public static OperationResult Failure(string message = null, List<string> errors = null) => new OperationResult { IsSuccess = false, Message = message, Errors = errors ?? new List<string>() };

}
