
namespace Command.Message.Interface
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TQuery>
    {
        Task<IEnumerable<TResult>> Handle(TQuery query);
    }
}
