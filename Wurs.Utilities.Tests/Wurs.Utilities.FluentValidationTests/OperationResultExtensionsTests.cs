using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wurs.Utilities.FluentValidationTests.Fixtures;
using Wurs.Utilities.OperationResult;
using Wurs.Utilities.OperationResult.FluentValidation;

namespace Wurs.Utilities.Tests.OperationResult.Extensions.FluentValidationTests;

[TestClass()]
public class OperationResultExtensionsTests
{
    [TestMethod()]
    public void AddErrors_OK()
    {
        var operationResult = new OperationResult<string>();
        var validationFailures = FluentValidationFixture.GetValidationFailures();
        var expectedErrorCount = validationFailures.Count;

        var result = OperationResultFluentValidation.AddErrors(operationResult, validationFailures);

        Assert.IsNotNull(result);
        Assert.AreEqual(operationResult, result);
        CollectionAssert.AllItemsAreNotNull(result.Errors);
        CollectionAssert.AllItemsAreUnique(result.Errors);
        Assert.AreEqual(expectedErrorCount, result.Errors.Count);
    }

    [TestMethod()]
    public void When_Failures_IsEmpty_Return_OperationResult_NoErrors()
    {
        var operationResult = new OperationResult<string>();
        var validationFailures = new List<ValidationFailure>();
        var expectedErrorCount = 0;

        var result = OperationResultFluentValidation.AddErrors(operationResult, validationFailures);

        Assert.IsNotNull(result);
        Assert.AreEqual(operationResult, result);
        Assert.AreEqual(expectedErrorCount, result.Errors.Count);
    }

    [TestMethod()]
    public void When_OperationResult_IsNull_Throws_ArgumentNullException()
    {
        var validationFailures = FluentValidationFixture.GetValidationFailures();

        Assert.ThrowsException<ArgumentNullException>(()
            => OperationResultFluentValidation.AddErrors(default(OperationResult<string>)!, validationFailures));
    }

    [TestMethod()]
    public void When_failures_IsNull_Throws_ArgumentNullException()
    {
        var operationResult = new OperationResult<string>();

        Assert.ThrowsException<ArgumentNullException>(()
            => OperationResultFluentValidation.AddErrors(operationResult, default(List<ValidationFailure>)!));
    }
}