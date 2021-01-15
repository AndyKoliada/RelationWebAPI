using Xunit;
using WebAPI.Infrastructure.Context;

namespace WebAPI.Infrastructure.Repositories.Tests
{
    public class RelationsRepositoryTests
    {
        [Theory]
        [InlineData("1111-kM", "NNNN_ll", "1111_km")] //Azerbeidzjan
        [InlineData("11111", "NNNNN", "11111")] //België
        [InlineData("1111", "NNNN", "1111")] //Bosnië en Herzegovina
        [InlineData("1111-kM", "NNNN ll", "1111 km")] //Bulgarije
        [InlineData("1111+KM", "NNNN-lL", "1111-kM")] //Estland
        [InlineData("1111-kM", "NNNN LL", "1111 KM")] //Nederland
        public void ModifyPostalCodeTest(string input, string mask, string expected)
        {
            var context = new RepositoryContext();
            var repo = new RelationsRepository(context);
            string result = repo.ModifyPostalCode(input, mask);

            Assert.Equal(expected, result);
        }
    }
}