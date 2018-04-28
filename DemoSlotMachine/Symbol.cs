namespace DemoSlotMachine
{
    using Contracts;

    public class Symbol : ISymbol
    {
        public Symbol(char character, decimal coefficient, double probability)
        {
            this.Character = character;
            this.Coefficient = coefficient;
            this.Probability = probability;
        }

        public char Character { get; }

        public decimal Coefficient { get; }

        public double Probability { get; }

        public bool IsWildcard => this.Coefficient == 0;
    }
}
