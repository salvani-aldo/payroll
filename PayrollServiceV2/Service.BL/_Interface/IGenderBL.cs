using Command.Message.Interface;

namespace Service.BL._Interface
{
    public interface IGenderBL
    {
        Task<IEnumerable<IQuery>> Get();
    }
}
