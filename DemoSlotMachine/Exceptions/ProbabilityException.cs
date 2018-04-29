namespace DemoSlotMachine.Exceptions
{
    /// <summary>
    /// Represents errors that occur when the configured probabilities are invalid.
    /// </summary>
    public class ProbabilityException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProbabilityException"/> class.
        /// </summary>
        public ProbabilityException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProbabilityException"/> class
        /// with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProbabilityException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProbabilityException"/> class
        /// with a specified error messageand a reference to the inner exception that is
        /// the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or <see code="null"/>
        /// if no inner exception is specified.
        /// </param>
        public ProbabilityException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
