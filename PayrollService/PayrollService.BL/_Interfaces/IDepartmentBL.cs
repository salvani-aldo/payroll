using Command.Message.Interface;
using Command.Query.Handler.Department.Get;
using Command.Request.Handler.Department.Post;
using Command.Request.Handler.Department.Put;

namespace Payroll.BL._Interfaces
{
    public interface IDepartmentBL
    {
        Task<IEnumerable<DepartmentGetModel>> GetDeparments();
        Task<IEnumerable<ICommand>> SaveDeparment(DepartmentPostModel model);
        Task<IEnumerable<ICommand>> UpdateDeparment(DepartmentPutModel model);
        Task DeleteDeparment(int id);
    }
}
