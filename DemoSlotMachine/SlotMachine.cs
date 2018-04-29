namespace DemoSlotMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;

    /// <summary>
    /// Implements methods for a simple slot machine's logic.
    /// </summary>
    public class SlotMachine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SlotMachine"/> class with
        /// the specified rows and columns counts.
        /// </summary>
        /// <param name="rowsCount">The number of rows.</param>
        /// <param name="colsCount">The number of columns.</param>
        public SlotMachine(int rowsCount, int colsCount)
        {
            this.Table = new Symbol[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                this.Table[i] = new Symbol[colsCount];
            }
        }

        /// <summary>Gets the randomizer instance.</summary>
        private static Random Random { get; } = new Random();

        /// <summary>Gets the current symbol's table.</summary>
        private Symbol[][] Table { get; }

        /// <summary>
        /// Populates and returns the current symbol's table based on their specified probabilities.
        /// </summary>
        /// <param name="symbols">A list of symbols to use to populate the table.</param>
        /// <exception cref="ProbabilityException">
        /// Thrown when the specified symbols' probabilities don't add up to 100%.
        /// </exception>
        /// <returns>The populated symbol's table.</returns>
        public Symbol[][] PopulateTableWithSymbols(IEnumerable<Symbol> symbols)
        {
            if (symbols.Sum(x => x.Probability) != 1)
            {
                throw new ProbabilityException("Symbol probability sum is not 100%.");
            }

            for (int i = 0; i < this.Table.Length; i++)
            {
                for (int j = 0; j < this.Table[i].Length; j++)
                {
                    this.Table[i][j] = GetCharacter(symbols);
                }
            }

            return this.Table;
        }

        /// <summary>
        /// Calculates and returns the effective winnings coefficient based on the symbol's table.
        /// </summary>
        /// <param name="table">Optional symbol's table override.</param>
        /// <returns>The effective winnings coefficient.</returns>
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

        /// <summary>
        /// Returns a random symbol from the specified list of symbols based on their <see cref="Symbol.Probability"/>.
        /// </summary>
        /// <param name="symbols">The list of symbols to use for randomizing.</param>
        /// <returns>The symbol that was chosen based on its chance.</returns>
        private static Symbol GetCharacter(IEnumerable<Symbol> symbols)
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
