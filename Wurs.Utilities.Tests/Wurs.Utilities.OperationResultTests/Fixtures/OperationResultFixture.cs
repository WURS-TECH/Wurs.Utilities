using Wurs.Utilities.OperationResult;

namespace Wurs.Utilities.OperationResultTests.Fixtures;

public static class OperationResultFixture
{
    public static List<Error> GetErrors(int errorCount)
    {
        var errorList = new List<Error>();
        for (int i = 0; i < errorCount; i++)
            errorList.Add(new Error($"TestMessage{i}", i));

        return errorList;
    }

    public static List<T> GetResults<T>(int resultCount, T testInstance) where T : class
    {
        var resultList = new List<T>();
        for (int i = 0; i < resultCount; i++)
            resultList.Add(testInstance);

        return resultList;
    }
}
