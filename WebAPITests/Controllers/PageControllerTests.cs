using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAPI.Controllers.Tests
{
    [TestClass()]
    public class PageControllerTests
    {
        [DataTestMethod]
        [DataRow("4545bx", "NNNN-LL", "4545 - BX")]
        [DataRow("4545bx", "NNNN_lL", "4545 _ bX")]
        public void PostRelationTest()
        {
            //var result = PostalCodeFormatter();
            Assert.Fail();
        }
    }
}