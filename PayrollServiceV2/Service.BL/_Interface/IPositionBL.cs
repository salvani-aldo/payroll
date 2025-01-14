using Command.Message.Interface;
using Command.Request.Position.Post.Model;
using Command.Request.Position.Put.Model;

namespace Service.BL._Interface
{
    public interface IPositionBL
    {
        Task<IEnumerable<IQuery>> Get();
        Task<IEnumerable<IQuery>> Save(PositionPostCommandModel model);
        Task<IEnumerable<IQuery>> Update(PositionPutCommandModel model);
        Task<IEnumerable<IQuery>> Delete(int id);
    }
}
