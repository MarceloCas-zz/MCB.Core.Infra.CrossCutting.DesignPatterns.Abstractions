namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Adapter;

public interface IAdapter
{
    object Adapt(Type targetType, object source);
    object Adapt(Type targetType, object source, Type sourceType);

    object Adapt(Type targetType, object source, object existingTarget);
    object Adapt(Type targetType, Type sourceType, object source, object existingTarget);

    object Adapt(object source, object target);

    TTarget Adapt<TTarget>(object source);
    TTarget Adapt<TTarget>(object source, TTarget existingTarget);

    TTarget Adapt<TSource, TTarget>(TSource source);
    TTarget Adapt<TSource, TTarget>(TSource source, TTarget existingTarget);
}