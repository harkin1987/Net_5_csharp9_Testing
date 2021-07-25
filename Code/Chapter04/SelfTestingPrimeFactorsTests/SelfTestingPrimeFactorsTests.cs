using Packt;
using Xunit;

namespace SelfTestingPrimeFactorsTests
{
    public class SelfTestingPrimeFactorsTests
    {
        [Fact]
        public void TestFour()
        {
            // arrange
            int a = 4;
            int expected = 2;
            var primeCalc = new SelfTestingPrimeFactors();
            // act
            int actual = primeCalc.PrimeFactor(a);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}
