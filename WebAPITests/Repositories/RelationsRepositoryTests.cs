using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Domain.ViewModels.Relation;

namespace WebAPI.Infrastructure.Repositories.Tests
{
    [TestClass()]
    public class RelationsRepositoryTests
    {
        // arrange

        RelationDetailsCreateModel caseAzerbeidzjan 
            = new RelationDetailsCreateModel { PostalCode = "NNNN_ll", Country = "Azerbeidzjan" }; //NNNN_ll
        RelationDetailsCreateModel caseBelgië 
            = new RelationDetailsCreateModel { PostalCode = "1234-LL", Country = "België" }; //NNNNN
        RelationDetailsCreateModel caseBosniëenHerzegovina
            = new RelationDetailsCreateModel { PostalCode = "1234-LL", Country = "Bosnië en Herzegovina" }; //NNNN
        RelationDetailsCreateModel caseBulgarije
            = new RelationDetailsCreateModel { PostalCode = "1234-LL", Country = "Bulgarije" }; //NNNN ll
        RelationDetailsCreateModel caseEstland
            = new RelationDetailsCreateModel { PostalCode = "1234-LL", Country = "Estland" }; //NNNN-lL
        RelationDetailsCreateModel caseNederland
            = new RelationDetailsCreateModel { PostalCode = "1234-LL", Country = "Nederland" }; //NNNN LL

        RelationsRepositoryTests test = new RelationsRepositoryTests();
        [DataTestMethod]
        //[DataRow(caseAzerbeidzjan.PostalCode, "NNNN-LL", "4545 - BX")]
        [DataRow("4545bx", "NNNN_lL", "4545 _ bX")]
        public void TryFormatPostalCodeTest()
        {


            // act


            // assert
            Assert.Fail();
        }
    }
}