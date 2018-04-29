namespace DemoSlotMachine.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SlotMachineTests
    {
        [TestMethod]
        public void PopulateTableWithSymbolsCheckProbability()
        {
            SlotMachine slotMachine = new SlotMachine(rowsCount: 1, colsCount: 10000);
            var table = slotMachine.PopulateTableWithSymbols(Configuration.Symbols);
            var grouping = table[0].ToLookup(x => x.Character);
            foreach (var item in Configuration.Symbols)
            {
                Symbol[] firstRow = table[0];
                double count = grouping[item.Character].Count();
                double probability = count / firstRow.Length;
                Assert.AreEqual(expected: item.Probability, actual: probability, delta: 0.01);
            }
        }

        [TestMethod]
        public void PopulateTableWithSymbolsProbabilitySumLessThanHundred()
        {
            SlotMachine slotMachine = new SlotMachine(Configuration.RowCount, Configuration.ColCount);
            var list = new List<Symbol>()
            {
                new Symbol(character: '$', coefficient: 1.5M, probability: 0.5)
            };
            Assert.ThrowsException<ProbabilityException>(() => slotMachine.PopulateTableWithSymbols(list));
        }

        [TestMethod]
        public void PopulateTableWithSymbolsProbabilitySumMoreThanHundred()
        {
            SlotMachine slotMachine = new SlotMachine(Configuration.RowCount, Configuration.ColCount);
            var list = new List<Symbol>()
            {
                new Symbol(character: '$', coefficient: 1.5M, probability: 1.5)
            };
            Assert.ThrowsException<ProbabilityException>(() => slotMachine.PopulateTableWithSymbols(list));
        }

        [TestMethod]
        public void CalculeGlobalCoefficientShouldReturnPositiveValue()
        {
            SlotMachine slotMachine = new SlotMachine(2, 3);

            var symbolA = new Symbol(character: 'A', coefficient: 0.4M, probability: 0.45);
            var symbolB = new Symbol(character: 'B', coefficient: 0.6M, probability: 0.35);
            var symbolWildcard = new Symbol(character: '*', coefficient: 0.0M, probability: 0.05);
            var table = new Symbol[][]
            {
                new Symbol[]
                {
                    symbolA,
                    symbolA,
                    symbolA,
                },
                new Symbol[]
                {
                    symbolB,
                    symbolWildcard,
                    symbolB,
                },
            };
            decimal expectedCoefficient = CoefficientsSum(table);
            decimal actualCoefficient = slotMachine.CalculeGlobalCoefficient(table);
            Assert.AreEqual(expectedCoefficient, actualCoefficient);
        }

        private static decimal CoefficientsSum(Symbol[][] table)
        {
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
    }
}