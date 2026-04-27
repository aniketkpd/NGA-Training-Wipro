namespace CalculatorApp.Tests
{
    [TestClass]
    public sealed class CalculatorTests
    {
        private Calculator calc = new Calculator();

        [TestMethod]
        public void Add_Test()
        {
            Assert.AreEqual(5, calc.Add(2, 3));
        }

        [TestMethod]
        public void Subtract_Test()
        {
            Assert.AreEqual(2, calc.Subtract(5, 3));
        }

        [TestMethod]
        public void Multiply_Test()
        {
            Assert.AreEqual(6, calc.Multiply(2, 3));
        }

        [TestMethod]
        public void Divide_By_Zero_Test()
        {
            try
            {
                calc.Divide(5, 0);
                Assert.Fail("Expected exception not thrown");
            }
            catch (DivideByZeroException)
            {
                
            }
        }
    }
}
