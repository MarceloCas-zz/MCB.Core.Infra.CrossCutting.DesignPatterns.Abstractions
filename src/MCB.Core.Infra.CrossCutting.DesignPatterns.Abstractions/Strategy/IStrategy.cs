namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Strategy
{
    public interface IStrategy<TInput, TOutput>
    {
        TOutput Execute(TInput input);
    }
}
