namespace DemoSlotMachine
{
    using System.Collections.Generic;

    public static class Configuration
    {
        public const int ROWCOUNT = 4;

        public const int COLCOUNT = 3;

        public static IEnumerable<Symbol> Symbols { get; } = new[]
        {
            new Symbol(character: 'A', coefficient: 0.4M, probability: 0.45),
            new Symbol(character: 'B', coefficient: 0.6M, probability: 0.35),
            new Symbol(character: 'P', coefficient: 0.8M, probability: 0.15),
            new Symbol(character: '*', coefficient: 0.0M, probability: 0.05),
        };
    }
}
