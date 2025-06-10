using System;
using System.Globalization;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents a year value object with validation.
    /// </summary>
    public readonly struct Year
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Year"/> struct.
        /// </summary>
        /// <param name="year">The year value.</param>
        public Year(int year)
        {
            var currentYear = DateTime.UtcNow.Year;

            if (year < currentYear - 50 || year > currentYear)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be within the last 50 years and not in the future.");
            }

            Value = year;
        }

        /// <summary>
        /// Gets the integer value of the year.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Returns the string representation of the year.
        /// </summary>
        /// <returns>The year as a string.</returns>
        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }
}
