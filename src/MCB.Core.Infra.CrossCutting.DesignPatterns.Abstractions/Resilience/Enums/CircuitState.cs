namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Resilience.Enums
{
    public enum CircuitState
    {
        Closed = 1,
        HalfOpen = 2,
        Open = 3,
        Isolated = 4
    }
}
