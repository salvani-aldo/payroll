
using Command.Message.Interface;

namespace Service.BL._Interface
{
    public interface IUserBL
    {
        Task<IEnumerable<IQuery>> GetUser(string? user);
    }
}
