using Command.Message;
using Command.Message.Interface;
using Command.Query.Handler.Department.Get;
using Command.Request.Handler.Department.Delete;
using Command.Request.Handler.Department.Post;
using Command.Request.Handler.Department.Put;
using FluentValidation;
using Model.Validation.Department;
using Payroll.BL._Interfaces;

namespace Payroll.BL.Department
{
    public sealed class DepartmentBL : IDepartmentBL
    {
        private readonly Message _message;
        public  DepartmentBL(Message message)
        {
            _message = message;
        }

        public async Task DeleteDeparment(int id)
        {
            var result = await _message.Send(new DepartmentDeleteModel(id));
        }

        public async Task<IEnumerable<DepartmentGetModel>> GetDeparments()
        {
            var result = await _message.Send(new DepartmentGetModel());

            return result;
        }

        public async Task<IEnumerable<ICommand>> SaveDeparment(DepartmentPostModel model)
        {
            DepartmentPostModelValidator modelValidation = new DepartmentPostModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send(model);

            return result;
        }

        public async Task<IEnumerable<ICommand>> UpdateDeparment(DepartmentPutModel model)
        {
            DepartmentPutModelValidator modelValidation = new DepartmentPutModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send(model);

            return result;
        }
    }
}
