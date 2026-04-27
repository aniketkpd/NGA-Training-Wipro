namespace DemoApp.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        var calc = new Calculator();

        int result = calc.Sub(10,5);

        Assert.AreEqual(5, result);
    }


    [TestMethod]
    public void TestMethod2()
    {
        var calc = new Calculator();

        int result = calc.Sum(10,5);

        Assert.AreEqual(15, result);
    }


    [TestMethod]
    public void TestMethod3()
    {
        var calc = new Calculator();

        int result = calc.Mul(10,5);

        Assert.AreEqual(50, result);
    }

    [TestMethod]
    public void TestMethod4()
    {
        var calc = new Calculator();

        int result = calc.Div(10,5);

        Assert.AreEqual(2, result);
    }
}
