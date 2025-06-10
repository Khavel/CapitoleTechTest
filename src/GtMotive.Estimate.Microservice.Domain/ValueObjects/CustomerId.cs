using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents a strongly typed identifier for a customer.
    /// </summary>
    public readonly struct CustomerId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerId"/> struct.
        /// </summary>
        /// <param name="value">The GUID value representing the customer ID.</param>
        /// <exception cref="ArgumentException">Thrown when the value is Guid.Empty.</exception>
        public CustomerId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("CustomerId cannot be empty.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// Gets the underlying GUID value.
        /// </summary>
        public Guid Value { get; }

        /// <summary>
        /// Returns the string representation of the CustomerId.
        /// </summary>
        /// <returns>The GUID as a string.</returns>
        public override string ToString() => Value.ToString();
    }
}
