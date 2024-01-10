namespace WebApi.UnitTests;

public class UnitTest1
{
    [Fact]
    public void FirstTest_WithoutFluent()
    {
        string hello = "Hello, world";
        Assert.Equal("Hello, world", hello);
        Assert.StartsWith("Hel", hello);
        Assert.EndsWith("old", hello);

    }
}