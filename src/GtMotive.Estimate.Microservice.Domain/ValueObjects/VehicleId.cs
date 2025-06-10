using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents a strongly typed identifier for a vehicle.
    /// </summary>
    public readonly struct VehicleId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleId"/> struct.
        /// </summary>
        /// <param name="value">The GUID value representing the vehicle ID.</param>
        /// <exception cref="ArgumentException">Thrown when the value is Guid.Empty.</exception>
        public VehicleId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("VehicleId cannot be empty.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// Gets the underlying GUID value.
        /// </summary>
        public Guid Value { get; }

        /// <summary>
        /// Returns the string representation of the VehicleId.
        /// </summary>
        /// <returns>The GUID as a string.</returns>
        public override string ToString() => Value.ToString();
    }
}
