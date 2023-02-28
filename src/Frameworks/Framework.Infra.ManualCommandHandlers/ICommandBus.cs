namespace Framework.Infra.ManualCommandHandlers
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command);
    }
    
    public interface ICustomCommandBus
    {
        Task Dispatch<T>(T command);
    }
}