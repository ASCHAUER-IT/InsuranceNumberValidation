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

            // Valid social insurance numbers.
            Assert.True(attribute.IsValid("1237010180"));
            Assert.True(attribute.IsValid("7829280755"));
            Assert.True(attribute.IsValid("3285171076"));

            // Social security number with wrong check digit.
            Assert.False(attribute.IsValid("7823280755"));

            // Incorrect length social security number.
            Assert.False(attribute.IsValid("123001018"));

            // Social security number not just made up of digits.
            Assert.False(attribute.IsValid("1230010s18"));
        }

        #endregion Public Methods
    }
}