namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;

public interface IAdapter
{
    TTarget Adapt<TSource, TTarget>(TSource source);
    TTarget Adapt<TSource, TTarget>(TSource source, TTarget existingTarget);
}