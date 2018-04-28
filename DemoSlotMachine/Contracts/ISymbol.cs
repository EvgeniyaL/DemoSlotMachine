namespace DemoSlotMachine.Contracts
{
    public interface ISymbol
    {
        char Character { get; }

        decimal Coefficient { get; }

        double Probability { get; }

        bool IsWildcard { get; }
    }
}
