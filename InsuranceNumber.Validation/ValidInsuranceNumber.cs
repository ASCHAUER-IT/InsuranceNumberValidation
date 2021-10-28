using System;
using System.ComponentModel.DataAnnotations;

namespace AschauerIT.InsuranceNumber.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidInsuranceNumber : ValidationAttribute
    {
        #region Protected Methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var socialInsuranceNumber = (string)value;

            try
            {
                return CheckDigit.IsValid(socialInsuranceNumber)
                    ? ValidationResult.Success
                    : new ValidationResult($"Social insurance number is not valid.");
            }
            catch (ArgumentException ex)
            {
                return new ValidationResult(ex.Message);
            }
        }

        #endregion Protected Methods
    }
}