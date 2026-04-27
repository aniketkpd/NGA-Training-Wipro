using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class EncryptionTests
{
    [TestMethod]
    public void EncryptDecrypt_ShouldReturnSameData()
    {
        string data = "hello";

        string encrypted = EncryptionHelper.Encrypt(data);
        string decrypted = EncryptionHelper.Decrypt(encrypted);

        Assert.AreEqual(data, decrypted);
    }
}