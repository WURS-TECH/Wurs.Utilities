namespace Wurs.Utilities.OperationResult;

/// <summary>
/// Represents an error on a <see cref="OperationResult{T}"/> with a message and optional code
/// </summary>
public class Error
{
    /// <summary>
    /// Error constructor accepting a error message and optional error code
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="code">The erorr code</param>
    public Error(string message, int code = 0)
    {
        Message = message;
        Code = code;
    }
    /// <summary>
    /// Error message
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Error code
    /// </summary>
    public int Code { get; set; }
}
