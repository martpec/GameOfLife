namespace GameOfLife.Tests;

public class UnitTest1
{
    [Fact]
    public void TestHelloWorldOutput()
    {
        var expected = "Hello, World";
        var actual = Program.TestHelloWorldOutput();

        Assert.Equal(expected, actual);
    }
}