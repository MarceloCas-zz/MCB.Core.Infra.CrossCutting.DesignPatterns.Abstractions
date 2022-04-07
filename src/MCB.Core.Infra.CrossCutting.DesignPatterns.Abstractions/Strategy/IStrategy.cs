namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Strategy
{
    public interface IStrategy<in TInput, out TOutput>
    {
        TOutput Execute(TInput input);
    }
}
