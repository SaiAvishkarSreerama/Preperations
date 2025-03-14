namespace PreperationsTest
{
    [TestClass]
    public sealed class Test1
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // This method is called once for the test class, before any tests of the class are run.
        }

        [TestInitialize]
        public void TestInit()
        {
            // This method is called before each test method.
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
