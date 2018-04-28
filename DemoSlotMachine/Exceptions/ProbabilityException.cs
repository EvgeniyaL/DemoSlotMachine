namespace DemoSlotMachine
{
    public class ProbabilityException : System.Exception
    {
        public ProbabilityException()
            : base()
        {
        }

        public ProbabilityException(string message)
            : base(message)
        {
        }

        public ProbabilityException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
