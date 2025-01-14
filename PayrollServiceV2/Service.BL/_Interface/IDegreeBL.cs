using Command.Message.Interface;

namespace Service.BL._Interface
{
    public interface IDegreeBL
    {
        Task<IEnumerable<IQuery>> Get();
    }
}
