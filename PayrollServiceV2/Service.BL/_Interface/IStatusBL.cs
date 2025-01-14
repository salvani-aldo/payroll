using Command.Message.Interface;

namespace Service.BL._Interface
{
    public interface IStatusBL
    {
        Task<IEnumerable<IQuery>> Get();
    }
}
