namespace DemoSlotMachine
{
    using System;
    using System.Collections.Generic;
    using DemoSlotMachine.Contracts;

    public static class Program
    {
        private static IEnumerable<ISymbol> Symbols { get; } = new[]
        {
            new Symbol(character: 'A', coefficient: 0.4M, probability: 0.45),
            new Symbol(character: 'B', coefficient: 0.6M, probability: 0.35),
            new Symbol(character: 'P', coefficient: 0.8M, probability: 0.15),
            new Symbol(character: '*', coefficient: 0.0M, probability: 0.05),
        };

        public static void Main(string[] args)
        {
            var slotMachine = new SlotMachine(4, 3);
            var player = new Player(deposit: GetPlayerInput("Please deposit money you would like to play with:"));
            do
            {
                player.Stake = GetPlayerStakeInput(player.Deposit);

                var table = slotMachine.PopulateTableWithSymbols(Symbols);
                table.Render();

                decimal coefficient = slotMachine.CalculeGlobalCoefficient();
                player.ClaculateBalance(coefficient);
                player.RenderResults();
            }
            while (player.Deposit > 0);

            Console.WriteLine("The game. You have lost. Thanks for playing :)");
        }

        private static decimal GetPlayerInput(string message)
        {
            decimal amount;
            Console.WriteLine(message);
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter a valid value:");
            }

            return amount;
        }

        private static decimal GetPlayerStakeInput(decimal deposit)
        {
            decimal amount = 0;
            while (true)
            {
                amount = GetPlayerInput("Please enter stake amount:");

                if (amount <= deposit)
                {
                    return amount;
                }

                Console.WriteLine($"Stake exceeds your current deposit of {deposit}!");
            }
        }

        private static void Render(this ISymbol[][] table)
        {
            Console.WriteLine();
            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < table[i].Length; j++)
                {
                    Console.Write(table[i][j].Character);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void RenderResults(this Player player)
        {
            Console.WriteLine($"You have won: {player.Stake}");
            Console.WriteLine($"Current balance is: {player.Deposit}");
            Console.WriteLine();
        }
    }
}
