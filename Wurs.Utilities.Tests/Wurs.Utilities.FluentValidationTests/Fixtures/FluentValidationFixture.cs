using FluentValidation.Results;

namespace Wurs.Utilities.FluentValidationTests.Fixtures;

public static class FluentValidationFixture
{
    public static IList<ValidationFailure> GetValidationFailures()
        => new List<ValidationFailure>() { new ValidationFailure() { ErrorMessage = "TestMessage", ErrorCode = "TestCode" } };
}
