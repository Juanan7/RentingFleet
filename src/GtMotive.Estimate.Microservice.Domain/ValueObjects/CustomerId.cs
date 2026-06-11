using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Value object that uniquely identifies a customer.
    /// Wraps a string to prevent mixing up different kinds of identifiers.
    /// </summary>
    public readonly struct CustomerId : IEquatable<CustomerId>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerId"/> struct.
        /// </summary>
        /// <param name="value">The customer identifier. Cannot be null or empty.</param>
        /// <exception cref="DomainException">Thrown when <paramref name="value"/> is null or empty.</exception>
        public CustomerId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException("CustomerId cannot be null or empty.");
            }

            _value = value;
        }

        /// <summary>Equality operator.</summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns><c>true</c> if both values are equal.</returns>
        public static bool operator ==(CustomerId left, CustomerId right)
        {
            return left.Equals(right);
        }

        /// <summary>Inequality operator.</summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns><c>true</c> if both values are not equal.</returns>
        public static bool operator !=(CustomerId left, CustomerId right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <inheritdoc/>
        public bool Equals(CustomerId other) => _value == other._value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is CustomerId other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode(StringComparison.Ordinal);
    }
}
