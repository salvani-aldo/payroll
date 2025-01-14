using Command.Message.Interface;
using Command.Request.Department.Post.Model;
using Command.Request.Department.Put.Model;

namespace Service.BL._Interface
{
    public interface IDepartmentBL
    {
        Task<IEnumerable<IQuery>> Get();
        Task<IEnumerable<IQuery>> Save(DepartmentPostCommandModel model);
        Task<IEnumerable<IQuery>> Update(DepartmentPutCommandModel model);
        Task<IEnumerable<IQuery>> Delete(int id);
    }
}
