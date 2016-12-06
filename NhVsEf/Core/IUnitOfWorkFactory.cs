namespace Core
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}