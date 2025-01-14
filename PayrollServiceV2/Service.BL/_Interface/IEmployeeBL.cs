using Command.Message.Interface;
using Service.BL.Employee.Model;

namespace Service.BL._Interface
{
    public interface IEmployeeBL
    {
        Task<IEnumerable<IQuery>> Get();
        Task<IEnumerable<IQuery>> Save(EmployeeCommandModel model);
        Task<IEnumerable<IQuery>> Delete(int id);
        Task<EmployeePutCommandModel> Update(EmployeePutCommandModel model);
    }
}
