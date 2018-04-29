namespace DemoSlotMachine
{
    /// <summary>
    /// Implements player-specific properties and methods.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with the
        /// specified starting deposit amount.
        /// </summary>
        /// <param name="deposit">The starting deposit amount.</param>
        public Player(decimal deposit)
        {
            this.Deposit = deposit;
        }

        /// <summary>Gets the player's current deposit amount.</summary>
        public decimal Deposit { get; private set; }

        /// <summary>Gets or sets the player's current stake amount.</summary>
        public decimal Stake { get; set; }

        /// <summary>
        /// Calculates the current player's deposit and leftover stake based on the
        /// specified winning's coefficient.
        /// </summary>
        /// <param name="coefficient">The winning's coefficient.</param>
        public void ClaculateBalance(decimal coefficient)
        {
            this.Deposit = this.Deposit - this.Stake + (this.Stake * coefficient);
            this.Stake *= coefficient;
        }
    }
}
