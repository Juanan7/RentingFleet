using System;
using System.Globalization;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Value object representing the manufacture date of a vehicle.
    /// Enforces the business rule that vehicles cannot be older than 5 years.
    /// </summary>
    public readonly struct ManufactureDate : IEquatable<ManufactureDate>
    {
        private const int MaxAgeYears = 5;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufactureDate"/> struct.
        /// </summary>
        /// <param name="value">The manufacture date. Must not be older than <see cref="MaxAgeYears"/> years.</param>
        /// <exception cref="DomainException">Thrown when the date is older than 5 years.</exception>
        public ManufactureDate(DateTime value)
        {
            if (value < DateTime.UtcNow.AddYears(-MaxAgeYears))
            {
                throw new DomainException($"Vehicle manufacture date cannot be older than {MaxAgeYears} years.");
            }

            Value = value.Date;
        }

        /// <summary>Gets the underlying <see cref="DateTime"/> value.</summary>
        public DateTime Value { get; }

        /// <summary>Equality operator.</summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns><c>true</c> if both values are equal.</returns>
        public static bool operator ==(ManufactureDate left, ManufactureDate right)
        {
            return left.Equals(right);
        }

        /// <summary>Inequality operator.</summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns><c>true</c> if both values are not equal.</returns>
        public static bool operator !=(ManufactureDate left, ManufactureDate right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc/>
        public override string ToString() => Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        /// <inheritdoc/>
        public bool Equals(ManufactureDate other) => Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is ManufactureDate other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode();
    }
}
