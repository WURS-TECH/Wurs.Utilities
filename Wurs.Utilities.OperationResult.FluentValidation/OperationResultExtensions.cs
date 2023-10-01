using FluentValidation.Results;

namespace Wurs.Utilities.OperationResult.Extensions.FluentValidation;

/// <summary>
/// Contains util extensions to use <see cref="OperationResult{T}"/> in conjuction with FluentValidation library.
/// </summary>
public static class OperationResultExtensions
{
    /// <summary>
    /// Extension method to map <see cref="List{ValidationFailure}"/> to <see cref="List{Error}"/>
    /// </summary>
    /// <typeparam name="T">Used type of <see cref="OperationResult{T}"/></typeparam>
    /// <param name="result">The <see cref="OperationResult{T}"/>where to add the mapped errors</param>
    /// <param name="failures">The list of fluent validation <see cref="ValidationFailure"/>/></param>
    /// <returns>The current instance of <see cref="OperationResult{T}"/> so adittional calls can be chained</returns>
    public static OperationResult<T> AddErrors<T>(this OperationResult<T> result, IList<ValidationFailure> failures) where T : class
    {
        ArgumentNullException.ThrowIfNull(result, nameof(result));
        ArgumentNullException.ThrowIfNull(failures, nameof(failures));
        if (failures.Count == 0)
            return result;

        return result.AddErrors(failures.Select(x => new Error(x.ErrorMessage)).ToList());
    }
}