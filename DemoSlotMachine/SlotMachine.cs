namespace DemoSlotMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SlotMachine
    {
        private static readonly Random Random = new Random();

        public SlotMachine(int rowsCount, int colsCount)
        {
            this.Table = new Symbol[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                this.Table[i] = new Symbol[colsCount];
            }
        }

        private Symbol[][] Table { get; set; }

        public Symbol[][] PopulateTableWithSymbols(IEnumerable<Symbol> symbols)
        {
            for (int i = 0; i < this.Table.Length; i++)
            {
                for (int j = 0; j < this.Table[i].Length; j++)
                {
                    this.Table[i][j] = GetCharacter(symbols);
                }
            }

            return this.Table;
        }

        public decimal CalculeGlobalCoefficient(Symbol[][] table = null)
        {
            table = table ?? this.Table;
            decimal sum = 0;
            foreach (var row in table)
            {
                if (row.Skip(1).All(x => x == row[0] || x.IsWildcard))
                {
                    sum += row.Sum(x => x.Coefficient);
                }
            }

            return sum;
        }

        private static Symbol GetCharacter(IEnumerable<Symbol> symbols)
        {
            if (symbols.Sum(x => x.Probability) > 1)
            {
                throw new ProbabilityException("Symbol probability sum is more than 100%.");
            }

            double randomNumber = Random.NextDouble();
            foreach (var symbol in symbols)
            {
                if (randomNumber <= symbol.Probability)
                {
                    return symbol;
                }

                randomNumber -= symbol.Probability;
            }

            throw new ProbabilityException("Symbol probability sum is less than 100%.");
        }
    }
}
