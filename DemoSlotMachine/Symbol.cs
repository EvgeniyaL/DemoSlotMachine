namespace DemoSlotMachine
{
    /// <summary>
    /// Implements slot machine symbol specific properties.
    /// </summary>
    public class Symbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Symbol"/> class with the specified characteristics.
        /// </summary>
        /// <param name="character">The character this symbol is represented by.</param>
        /// <param name="coefficient">The symbol's winnings coefficient.</param>
        /// <param name="probability">The symbol's probability to be chosen.</param>
        public Symbol(char character, decimal coefficient, double probability)
        {
            this.Character = character;
            this.Coefficient = coefficient;
            this.Probability = probability;
        }

        /// <summary>Gets the representing character for this symbol.</summary>
        public char Character { get; }

        /// <summary>Gets the winnings coefficient.</summary>
        public decimal Coefficient { get; }

        /// <summary>Gets the symbol's probability to be chosen.</summary>
        public double Probability { get; }

        /// <summary>Gets a value indicating whether the symbol is a wild-card.</summary>
        public bool IsWildcard => this.Coefficient == 0;
    }
}
