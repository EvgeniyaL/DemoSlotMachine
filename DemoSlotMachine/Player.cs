namespace DemoSlotMachine
{
    public class Player
    {
        public Player(decimal deposit)
        {
            this.Deposit = deposit;
        }

        public decimal Deposit { get; private set; }

        public decimal Stake { get; set; }

        public void ClaculateBalance(decimal coefficient)
        {
            this.Deposit = this.Deposit - this.Stake + (this.Stake * coefficient);
            this.Stake *= coefficient;
        }
    }
}
