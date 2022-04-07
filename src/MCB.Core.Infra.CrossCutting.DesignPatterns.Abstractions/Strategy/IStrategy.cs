namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Strategy
{
    public interface IStrategy<TInput, out TOutput>
    {
        TOutput Execute(TInput input);
    }
}
