using System;

namespace AschauerIT.InsuranceNumber
{
    public class CheckDigit
    {
        #region Public Methods

        /// <summary>
        /// Calculates the check digit of a social security number. The number must be 10 digits
        /// long and only consist of digits. The check digit itself is ignored in the calculation.
        /// </summary>
        /// <param name="socialSecurityNumber">The ten-digit social security number</param>
        /// <returns>The check digit</returns>
        /// <exception cref="ArgumentException">
        /// If the social security number is not exactly ten digits.
        /// </exception>
        public static int Get(string socialSecurityNumber)
        {
            // Check the length of the number.
            if (socialSecurityNumber.Length != 10)
                throw new ArgumentException("The social security number must consist of ten characters.", nameof(socialSecurityNumber));

            // Check that the number is only made up of digits todo check if numeric.
            if (!long.TryParse(socialSecurityNumber, out long _))
                throw new ArgumentException("The social security number may only consist of digits.", nameof(socialSecurityNumber));

            // The multipliers for all positions. The 0 in the 4th position causes the position to
            // be ignored.
            int[] multipliers = { 3, 7, 9, 0, 5, 8, 4, 2, 1, 6 };

            // Each digit in the social security number is multiplied by the respective multiplier
            // and the individual results are summed up.
            int sum = 0;
            for (int i = 0; i < 10; i++)
                sum += multipliers[i] * (int)char.GetNumericValue(socialSecurityNumber[i]);

            // The remainder from dividing by 11 results in the check digit.
            return sum % 11;
        }

        /// <summary>
        /// Checks that a social security number is valid. Only the validity of the check digit is
        /// checked. The plausibility of the date of birth is not checked.
        /// </summary>
        /// <param name="socialSecurityNumber">The ten-digit social security number</param>
        /// <returns>Whether the check digit is correct.</returns>
        /// <exception cref="ArgumentException">
        /// If the social security number is not exactly ten digits.
        /// </exception>
        public static bool IsValid(string socialSecurityNumber)
        {
            return char.GetNumericValue(socialSecurityNumber[3]) == Get(socialSecurityNumber);
        }

        #endregion Public Methods
    }
}