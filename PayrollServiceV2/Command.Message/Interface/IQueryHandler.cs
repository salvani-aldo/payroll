namespace Command.Message.Interface
{
    public interface IQueryHandler<TQuery> where TQuery : IQuery
    {
        Task<IEnumerable<TQuery>> Handle();
    }
}
