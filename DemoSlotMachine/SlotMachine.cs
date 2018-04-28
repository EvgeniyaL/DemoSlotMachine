namespace DemoSlotMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class SlotMachine
    {
        private static readonly Random Random = new Random();

        public SlotMachine(int rowsCount, int colsCount)
        {
            this.Table = new ISymbol[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                this.Table[i] = new ISymbol[colsCount];
            }
        }

        private ISymbol[][] Table { get; set; }

        public ISymbol[][] PopulateTableWithSymbols(IEnumerable<ISymbol> symbols)
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

        public decimal CalculeGlobalCoefficient()
        {
            decimal sum = 0;
            for (int i = 0; i < this.Table.Length; i++)
            {
                if (this.Table[i].Skip(1).All(x => x == this.Table[i][0] || x.IsWildcard))
                {
                    sum += this.Table[i].Sum(x => x.Coefficient);
                }
            }

            return sum;
        }

        private static ISymbol GetCharacter(IEnumerable<ISymbol> symbols)
        {
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
