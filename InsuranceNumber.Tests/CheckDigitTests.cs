using AschauerIT.InsuranceNumber;
using System;
using Xunit;

namespace InsuranceNumber.Tests
{
    public class CheckDigitTests
    {
        #region Public Methods

        [Fact]
        public void GetCheckDigit()
        {
            Assert.Equal(7, CheckDigit.Get("1230010180"));
            Assert.Equal(9, CheckDigit.Get("7820280755"));
            Assert.Equal(5, CheckDigit.Get("3280171076"));

            Assert.Throws<ArgumentException>(() => CheckDigit.Get("123001018"));
            Assert.Throws<ArgumentException>(() => CheckDigit.Get("1230010s18"));
        }

        [Fact]
        public void IsValid()
        {
            Assert.True(CheckDigit.IsValid("1237010180"));
            Assert.True(CheckDigit.IsValid("7829280755"));
            Assert.True(CheckDigit.IsValid("3285171076"));
        }

        #endregion Public Methods
    }
}