namespace tests;

public class ApplicationArgsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Methods()
    {
        var sut = new ApplicationArgs(new string[]{"-m", "GET"});
    }
}