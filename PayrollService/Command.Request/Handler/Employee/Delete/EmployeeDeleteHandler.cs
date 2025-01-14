using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using System.Text;
using Utility;

namespace Command.Request.Handler.Employee.Delete
{
    public sealed class EmployeeDeleteHandler : BaseHandler, ICommandHandler<EmployeeDeleteModel>
    {
        private string _query = "Employee_Delete";

        public EmployeeDeleteHandler(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeDeleteModel>> Handle(EmployeeDeleteModel command)
        {
            IEnumerable<EmployeeDeleteModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                StringBuilder parameterQuery = new StringBuilder();
                parameterQuery.Append(_query).Append(" ")
                    .Append("@employeeId=").Append(command.Id.ToString());

                model = await connection.QueryAsync<EmployeeDeleteModel>(parameterQuery.ToString());
            }

            return model;
        }
    }
}
