using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void Register_ShouldHashPassword()
    {
        var user = User.Register("test", "1234");

        Assert.AreNotEqual("1234", user.HashedPassword);
    }

    [TestMethod]
    public void Authenticate_ShouldReturnTrue()
    {
        var user = User.Register("test", "1234");

        bool result = user.Authenticate("1234");

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Authenticate_ShouldFail_WrongPassword()
    {
        var user = User.Register("test", "1234");

        bool result = user.Authenticate("wrong");

        Assert.IsFalse(result);
    }
}