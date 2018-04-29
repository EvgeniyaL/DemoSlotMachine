namespace DemoSlotMachine
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implements configuration properties for the console application.
    /// </summary>
    public static class Configuration
    {
        /// <summary>The default slot machine row count.</summary>
        public const int RowCount = 4;

        /// <summary>The default slot machine column count.</summary>
        public const int ColCount = 3;

        /// <summary>Gets the collection of default slot machine symbols.</summary>
        public static IEnumerable<Symbol> Symbols { get; } = new ReadOnlyCollection<Symbol>(
            new[]
            {
                new Symbol(character: 'A', coefficient: 0.4M, probability: 0.45),
                new Symbol(character: 'B', coefficient: 0.6M, probability: 0.35),
                new Symbol(character: 'P', coefficient: 0.8M, probability: 0.15),
                new Symbol(character: '*', coefficient: 0.0M, probability: 0.05),
            });
    }
}
