namespace Command.Message.Interface
{
    public interface ICommandHandler<TCommand, TQuery>
        where TCommand : ICommand
        where TQuery : IQuery
    {
        Task<IEnumerable<TQuery>> Handle(TCommand command);
    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}
