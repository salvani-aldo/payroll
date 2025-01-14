using Command.Message.Interface;
using Command.Query.Handler.Employee.Get;
using Command.Request.Handler.Employee.Post;
using Command.Request.Handler.Employee.Put;

namespace Payroll.BL._Interfaces
{
    public interface IEmployeeBL
    {
        Task<IEnumerable<EmployeeGetModel>> GetEmployees();
        Task<IEnumerable<ICommand>> SaveEmployee(EmployeePostModel model);
        Task<IEnumerable<ICommand>> UpdateEmployee(EmployeePutModel model);
        Task DeleteEmployee(int id);
    }
}
