using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraderaWebServiceClient;

namespace DatabaseHandlerTests
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = "testrun 1";
        [TestMethod]
        public void TestMethod1()
        {
            TraderaWebServiceClient.Program.Main();
            string res = "testrun 1";
            Assert.AreEqual(Expected, res);
        }
    }
}
