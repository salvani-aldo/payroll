using Command.Message.Interface;
using Command.Request.Address.Post.Model;

namespace Service.BL._Interface
{
    public interface IAddressBL
    {
        Task<IEnumerable<IQuery>> Save(AddressPostCommandModel model);
        Task Delete(int id);
    }
}
