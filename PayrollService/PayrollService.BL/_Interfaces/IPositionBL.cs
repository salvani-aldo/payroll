using Command.Message.Interface;
using Command.Query.Handler.Position.Get;
using Command.Request.Handler.Position.Post;
using Command.Request.Handler.Position.Put;

namespace Payroll.BL._Interfaces
{
    public interface IPositionBL
    {
        Task<IEnumerable<PositionGetModel>> GetPositions();
        Task<IEnumerable<ICommand>> SavePosition(PositionPostModel model);
        Task<IEnumerable<ICommand>> UpdatePosition(PositionPutModel model);
        Task DeletePosition(int id);
    }
}
