
namespace Command.Message.Interface
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<IEnumerable<T>> Handle(T command);
    }
}
