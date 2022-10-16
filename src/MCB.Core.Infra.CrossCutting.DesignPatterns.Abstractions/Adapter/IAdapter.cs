namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;

public interface IAdapter
{
    TTarget Adapt<TTarget>(object source);
    object Adapt(object source, object existingTarget);
    TTarget Adapt<TSource, TTarget>(TSource source);
    TTarget Adapt<TSource, TTarget>(TSource source, TTarget existingTarget);
}