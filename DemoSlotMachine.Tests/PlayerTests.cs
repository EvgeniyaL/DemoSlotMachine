namespace DemoSlotMachine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void ClaculateBalanceShouldReturnZeroForStake()
        {
            var coefficient = 0;
            var deposit = 200;
            Player player = new Player(deposit);
            player.Stake = 10;
            deposit -= 10;
            player.ClaculateBalance(coefficient);
            Assert.AreEqual(expected: deposit, actual: player.Deposit);
            Assert.AreEqual(expected: player.Stake * coefficient, actual: player.Stake);
        }

        [TestMethod]
        public void ClaculateBalanceShouldIncreaceStakeAndDeposit()
        {
            var coefficient = 2;
            decimal deposit = 200;
            Player player = new Player(deposit);
            player.Stake = 10;
            deposit = deposit - player.Stake + (player.Stake * coefficient);
            player.ClaculateBalance(coefficient);
            Assert.AreEqual(expected: deposit, actual: player.Deposit);
            Assert.AreEqual(expected: player.Stake * coefficient, actual: player.Stake);
        }
    }
}