namespace DemoSlotMachine
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Implements the main console application game logic.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Executes the game logic.
        /// </summary>
        /// <param name="args">Optional command line arguments.</param>
        public static void Main(string[] args)
        {
            var slotMachine = new SlotMachine(Configuration.RowCount, Configuration.ColCount);
            var player = new Player(deposit: GetPlayerInput("Please deposit money you would like to play with:"));
            do
            {
                player.Stake = GetPlayerStakeInput(player.Deposit);

                var table = slotMachine.PopulateTableWithSymbols(Configuration.Symbols);
                table.Render();

                decimal coefficient = slotMachine.CalculeGlobalCoefficient();
                player.ClaculateBalance(coefficient);
                player.RenderResults();
            }
            while (player.Deposit > 0);

            Console.WriteLine("The game. You have lost. Thanks for playing :)");
        }

        /// <summary>
        /// Returns a valid deposit or stake value from the player's console input.
        /// </summary>
        /// <param name="message">The message to display as a prompt.</param>
        /// <returns>The valid deposit or stake value.</returns>
        private static decimal GetPlayerInput(string message)
        {
            decimal amount = 0;
            Console.WriteLine(message);
            while (true)
            {
                if (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                    Console.WriteLine($"Please enter a valid value (use '{decimalSeparator}' for decimal point):");
                }
                else if (amount < 0)
                {
                    Console.WriteLine($"Please enter a positive value:");
                }
                else
                {
                    break;
                }
            }

            return amount;
        }

        /// <summary>
        /// Returns a valid stake value from the player's console input.
        /// </summary>
        /// <param name="deposit">
        /// The current player's deposit amount to validate against.
        /// </param>
        /// <returns>The valid stake value.</returns>
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

        /// <summary>
        /// Renders a symbols' table to the console output.
        /// </summary>
        /// <param name="table">The symbols' table.</param>
        private static void Render(this Symbol[][] table)
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

        /// <summary>
        /// Render's the player's current deposit and leftover stake to the console output.
        /// </summary>
        /// <param name="player">The player's object.</param>
        private static void RenderResults(this Player player)
        {
            Console.WriteLine($"You have won: {player.Stake:0.##}");
            Console.WriteLine($"Current balance is: {player.Deposit:0.##}");
            Console.WriteLine();
        }
    }
}
