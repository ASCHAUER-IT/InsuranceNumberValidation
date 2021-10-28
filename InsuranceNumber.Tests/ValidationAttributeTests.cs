using AschauerIT.InsuranceNumber.Validation;
using Xunit;

namespace InsuranceNumber.Tests
{
    public class ValidationAttributeTests
    {
        #region Public Methods

        [Fact]
        public void ValidInsuranceNumber()
        {
            var attribute = new ValidInsuranceNumber();

            Assert.True(attribute.IsValid("1237010180"));
            Assert.True(attribute.IsValid("7829280755"));
            Assert.True(attribute.IsValid("3285171076"));

            Assert.False(attribute.IsValid("123001018"));
            Assert.False(attribute.IsValid("1230010s18"));
        }

        #endregion Public Methods
    }
}