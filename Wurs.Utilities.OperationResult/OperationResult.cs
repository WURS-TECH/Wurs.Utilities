namespace Wurs.Utilities.OperationResult;

/// <summary>
/// Encapsulates the result of an operation
/// </summary>
/// <typeparam name="T">The type of the operation</typeparam>
public class OperationResult<T> where T : class
{
    /// <summary>
    /// Contains the list of the results added to the operation
    /// Read only
    /// </summary>
    public List<T> Results { get; private set; } = new List<T>();

    /// <summary>
    /// Contains the list of the errors added to the operation
    /// Read only
    /// </summary>
    public List<Error> Errors { get; private set; } = new List<Error>();

    /// <summary>
    /// Contains the last error added to the operation
    /// Read only
    /// </summary>
    public Error? Error { get; private set; }

    /// <summary>
    /// Contains the last result added to the operation
    /// Read only
    /// </summary>
    public T? Result { get; private set; }

    /// <summary>
    /// Indicates if there are any errors associated with the operation.
    /// Read only
    /// </summary>
    public bool HasErrors => Errors.Count > 0;

    /// <summary>
    /// Adds the result to the end of <see cref="Results"/> and overrides the current <see cref="Result"/>
    /// </summary>
    /// <param name="result">The result to add</param>
    /// <exception cref="ArgumentNullException">If <paramref name="result"/>is null</exception>
    /// <exception cref="ArgumentException">If <paramref name="result"/>is empty string</exception>
    /// <returns>Current instance of <see cref="OperationResult{T}"/> so additional calls can be chained</returns>
    public OperationResult<T> AddResult(T result)
    {
        ArgumentNullException.ThrowIfNull(result, nameof(result));
        if (result.GetType() == typeof(string))
            ArgumentException.ThrowIfNullOrEmpty(result as string, nameof(result));

        Results.Add(result);
        Result = result;
        return this;
    }

    /// <summary>
    /// Adds the <paramref name="results"/> to the end of <see cref="Results"/>
    /// and overrides the current <see cref="Result"/> with the last entry of <paramref name="results"/>
    /// </summary>
    /// <param name="results">The list of results to add</param>
    /// <exception cref="ArgumentNullException">If <paramref name="results"/>is null</exception>
    /// <returns>Current instance of <see cref="OperationResult{T}"/> so additional calls can be chained</returns>
    public OperationResult<T> AddResults(List<T> results)
    {
        ArgumentNullException.ThrowIfNull(results, nameof(results));
        if (results.Count > 0)
        {
            Results.AddRange(results);
            Result = results.Last();
        }
        return this;
    }

    /// <summary>
    /// Adds an error to <see cref="Errors"/> 
    /// and overrides the current <see cref="Error"/>
    /// </summary>
    /// <param name="error">The error to add</param>
    /// <exception cref="ArgumentNullException">If <paramref name="error"/>is null</exception>
    /// <returns>Current instance of <see cref="OperationResult{T}"/> so additional calls can be chained</returns>
    public OperationResult<T> AddError(Error error)
    {
        ArgumentNullException.ThrowIfNull(error, nameof(error));
        Errors.Add(error);
        Error = error;
        return this;
    }

    /// <summary>
    /// Adds the <paramref name="errors"/> to the end of <see cref="Errors"/>
    /// and overrides the current <see cref="Error"/> with the last entry of <paramref name="errors"/>
    /// </summary>
    /// <param name="errors">The list of errors to add</param>
    /// <exception cref="ArgumentNullException">If <paramref name="errors"/>is null</exception>
    /// <returns>Current instance of <see cref="OperationResult{T}"/> so additional calls can be chained</returns>
    public OperationResult<T> AddErrors(List<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors, nameof(errors));
        if (errors.Count > 0)
        {
            Errors.AddRange(errors);
            Error = errors.Last();
        }
        return this;
    }

    /// <summary>
    /// Clears the values of <see cref="Errors"/> and <see cref="Error"/>
    /// </summary>
    /// <returns>Current instance of <see cref="OperationResult{T}"/> so additional calls can be chained</returns>
    public OperationResult<T> ClearErrors()
    {
        Errors.Clear();
        Error = default;
        return this;
    }

    /// <summary>
    /// Clears the values of <see cref="Results"/> and <see cref="Result"/>
    /// </summary>
    /// <returns>Current instance of <see cref="OperationResult{T}"/> so additional calls can be chained</returns>
    public OperationResult<T> ClearResults()
    {
        Results.Clear();
        Result = default;
        return this;
    }
}
