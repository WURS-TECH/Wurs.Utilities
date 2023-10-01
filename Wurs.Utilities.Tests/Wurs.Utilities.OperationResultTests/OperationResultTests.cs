using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wurs.Utilities.OperationResult;
using Wurs.Utilities.OperationResultTests.Fixtures;

namespace Wurs.Utilities.Tests.OperationResultTests;

[TestClass()]
public class OperationResultTests
{
    [TestMethod()]
    public void AddResult()
    {
        var expectedResult = "TestResult";
        var expectedResultsCount = 1;
        var expectedErrorsCount = 0;

        var operationResult = new OperationResult<string>().AddResult(expectedResult);

        Assert.IsNotNull(operationResult);
        Assert.AreEqual(expectedResult, operationResult.Result);
        Assert.AreEqual(expectedResultsCount, operationResult.Results.Count);
        CollectionAssert.AllItemsAreNotNull(operationResult.Results);
        Assert.IsNull(operationResult.Error);
        Assert.AreEqual(expectedErrorsCount, operationResult.Errors.Count);
        Assert.IsFalse(operationResult.HasErrors);
    }

    [TestMethod()]
    public void AddResults()
    {
        var expectedResultsCount = 10;
        var expectedErrorsCount = 0;
        var expectedResults = OperationResultFixture.GetResults(expectedResultsCount, "TestResult");
        var expectedResult = expectedResults.Last();

        var operationResult = new OperationResult<string>().AddResults(expectedResults);

        Assert.IsNotNull(operationResult);
        Assert.AreEqual(expectedResult, operationResult.Result);
        Assert.AreEqual(expectedResultsCount, operationResult.Results.Count);
        CollectionAssert.AllItemsAreNotNull(operationResult.Results);
        Assert.IsNull(operationResult.Error);
        Assert.AreEqual(expectedErrorsCount, operationResult.Errors.Count);
        Assert.IsFalse(operationResult.HasErrors);
    }

    [TestMethod()]
    public void AddError()
    {
        var expectedErrorMessage = "TestError";
        var expectedErrorCode = 1;
        var expectedResultsCount = 0;
        var expectedErrorsCount = 1;
        var expectedError = new Error(expectedErrorMessage, expectedErrorCode);

        var operationResult = new OperationResult<string>().AddError(expectedError);

        Assert.IsNotNull(operationResult);
        Assert.IsTrue(operationResult.HasErrors);
        Assert.AreEqual(expectedError, operationResult.Error);
        Assert.AreEqual(expectedErrorCode, operationResult.Error?.Code);
        Assert.AreEqual(expectedErrorMessage, operationResult.Error?.Message);
        Assert.AreEqual(expectedErrorsCount, operationResult.Errors.Count);
        CollectionAssert.AllItemsAreNotNull(operationResult.Errors);
        Assert.IsNull(operationResult.Result);
        Assert.AreEqual(expectedResultsCount, operationResult.Results.Count);
    }

    [TestMethod()]
    public void AddErrorsTest()
    {
        var expectedResultsCount = 0;
        var expectedErrorsCount = 10;
        var expectedErrors = OperationResultFixture.GetErrors(expectedErrorsCount);
        var expectedError = expectedErrors.Last();

        var operationResult = new OperationResult<string>().AddErrors(expectedErrors);

        Assert.IsNotNull(operationResult);
        Assert.IsTrue(operationResult.HasErrors);
        Assert.AreEqual(expectedError, operationResult.Error);
        Assert.AreEqual(expectedErrorsCount, operationResult.Errors.Count);
        CollectionAssert.AllItemsAreNotNull(operationResult.Errors);
        Assert.IsNull(operationResult.Result);
        Assert.AreEqual(expectedResultsCount, operationResult.Results.Count);
    }

    [TestMethod()]
    public void ClearErrorsTest()
    {
        var expectedErrorsCount = 0;
        var errors = OperationResultFixture.GetErrors(10);

        var operationResult = new OperationResult<string>()
            .AddErrors(errors)
            .ClearErrors();

        Assert.IsNotNull(operationResult);
        Assert.IsFalse(operationResult.HasErrors);
        Assert.IsNull(operationResult.Error);
        Assert.AreEqual(expectedErrorsCount, operationResult.Errors.Count);
    }

    [TestMethod()]
    public void ClearResultsTest()
    {
        var expectedResultsCount = 0;
        var results = OperationResultFixture.GetResults(10, "TestResult");

        var operationResult = new OperationResult<string>()
            .AddResults(results)
            .ClearResults();

        Assert.IsNotNull(operationResult);
        Assert.IsFalse(operationResult.HasErrors);
        Assert.AreEqual(expectedResultsCount, operationResult.Results.Count);
        Assert.IsNull(operationResult.Result);
    }

    [TestMethod()]
    public void AddResult_When_Result_IsNull_Throws_ArgumentNullException()
    {
        OperationResult<string>? nullOperationResult = default;

        Assert.ThrowsException<ArgumentNullException>(() => new OperationResult<OperationResult<string>>().AddResult(nullOperationResult!));
    }

    [TestMethod()]
    public void AddResult_When_Result_IsEmptyString_Throws_ArgumentNullException()
    {
        Assert.ThrowsException<ArgumentException>(() => new OperationResult<string>().AddResult(string.Empty));
    }

    [TestMethod()]
    public void AddError_When_Error_IsNull_Throws_ArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new OperationResult<string>().AddError(default!));
    }
}