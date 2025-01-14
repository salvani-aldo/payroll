using Command.Message.Interface;

namespace Service.BL._Interface
{
    public interface IStateBL
    {
        Task<IEnumerable<IQuery>> GetStates();
    }
}
