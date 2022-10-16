namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;

public interface IAdapter
{
    object Adapt(Type target, object source);
    object Adapt(Type target, object source, object existingTarget);

    TTarget Adapt<TTarget>(object source);
    TTarget Adapt<TTarget>(object source, TTarget existingTarget);

    object Adapt(object source, object target);

    TTarget Adapt<TSource, TTarget>(TSource source);
    TTarget Adapt<TSource, TTarget>(TSource source, TTarget existingTarget);
}