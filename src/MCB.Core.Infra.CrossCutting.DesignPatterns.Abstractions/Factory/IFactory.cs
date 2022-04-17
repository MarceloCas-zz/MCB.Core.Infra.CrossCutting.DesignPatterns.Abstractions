namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Factory
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
