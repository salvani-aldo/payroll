using Command.Message;
using Command.Message.Interface;
using Command.Query.Handler.Employee.Get;
using Command.Request.Handler.Employee.Delete;
using Command.Request.Handler.Employee.Post;
using Command.Request.Handler.Employee.Put;
using FluentValidation;
using Model.Validation.Employee;
using Payroll.BL._Interfaces;

namespace Payroll.BL.Employee
{
    public sealed class EmployeeBL : IEmployeeBL
    {
        private readonly Message _message;


        public EmployeeBL(Message message)
        {
            _message = message;
        }

        public async Task DeleteEmployee(int id)
        {
            EmployeeDeleteModel deleteModel = new EmployeeDeleteModel(id);

            EmployeeDeleteModelValidator modelValidation = new EmployeeDeleteModelValidator();
            modelValidation.ValidateAndThrow(deleteModel);

            await _message.Send(deleteModel);
        }

        public async Task<IEnumerable<EmployeeGetModel>> GetEmployees()
        {
            var result = await _message.Send(new EmployeeGetModel());

            return result;
        }

        public async Task<IEnumerable<ICommand>> SaveEmployee(EmployeePostModel model)
        {
            EmployeePostModelValidator modelValidation = new EmployeePostModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send(model);

            return result;
        }

        public async Task<IEnumerable<ICommand>> UpdateEmployee(EmployeePutModel model)
        {
            EmployeePutModelValidator modelValidation = new EmployeePutModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send(model);

            return result;
        }
    }
}
