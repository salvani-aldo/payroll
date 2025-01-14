
namespace QueryRequest.Command.Interface
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
