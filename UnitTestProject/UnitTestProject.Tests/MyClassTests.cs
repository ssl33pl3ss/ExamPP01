using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class MyClassTests
    {
        [TestMethod]
        public void SumOf10And20()
        {
            int x = 10;
            int y = 20;
            int expected = 30;

            MyClass c = new MyClass();
            int actual = c.MyMethod(x, y);

            Assert.AreEqual(expected, actual);
        }
    }
}
