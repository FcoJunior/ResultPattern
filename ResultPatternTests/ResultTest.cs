using ResultPattern;

namespace ResultPatternTests;

public sealed class ResultTest
{
    public Result<int> ConvertToInt(string value)
    {
        
        if (Int32.TryParse(value, out int result))
        {
            return result;
        }

        return Error.Failure();
    }
    
    [Fact]
    public void SetValue_WhenPutImplicitConvert_ShouldReturnSuccess()
    {
        Result<int> result = 10;
        Assert.False(result.IsError);
        Assert.Equal(10, result.Value);
    }

    [Fact]
    public void GetResultError()
    {
        var result = ConvertToInt("error");
        Assert.True(result.IsError);
    }
}