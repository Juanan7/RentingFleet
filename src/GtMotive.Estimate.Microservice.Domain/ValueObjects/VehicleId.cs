using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Value object that uniquely identifies a vehicle.
    /// Wraps a <see cref="Guid"/> to prevent mixing up different kinds of identifiers.
    /// </summary>
    public readonly struct VehicleId : IEquatable<VehicleId>
    {
        private readonly Guid _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleId"/> struct.
        /// </summary>
        /// <param name="value">The underlying GUID. Cannot be empty.</param>
        /// <exception cref="DomainException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
        public VehicleId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException("VehicleId cannot be empty.");
            }

            _value = value;
        }

        /// <summary>Equality operator.</summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns><c>true</c> if both values are equal.</returns>
        public static bool operator ==(VehicleId left, VehicleId right)
        {
            return left.Equals(right);
        }

        /// <summary>Inequality operator.</summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns><c>true</c> if both values are not equal.</returns>
        public static bool operator !=(VehicleId left, VehicleId right)
        {
            return !left.Equals(right);
        }

        /// <summary>Creates a new <see cref="VehicleId"/> with a random value.</summary>
        /// <returns>A new <see cref="VehicleId"/>.</returns>
        public static VehicleId New() => new(Guid.NewGuid());

        /// <summary>Returns the underlying <see cref="Guid"/> value.</summary>
        /// <returns>The GUID.</returns>
        public Guid ToGuid() => _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public bool Equals(VehicleId other) => _value == other._value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is VehicleId other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();
    }
}
