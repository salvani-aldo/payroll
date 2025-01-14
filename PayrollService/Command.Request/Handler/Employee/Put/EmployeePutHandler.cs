using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using System.Text;
using Utility;

namespace Command.Request.Handler.Employee.Put
{
    public sealed class EmployeePutHandler : BaseHandler, ICommandHandler<EmployeePutModel>
    {
        private string _query = "Employee_Update";
        public EmployeePutHandler(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeePutModel>> Handle(EmployeePutModel command)
        {
            IEnumerable<EmployeePutModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                StringBuilder parameterQuery = new StringBuilder();
                parameterQuery.Append(_query).Append(" ")
                    .Append("@employeeId=").Append(command.Id.ToString()).Append(",")
                    .Append("@firstName='").Append(command.FirstName).Append("',")
                    .Append("@middleName='").Append(command.MiddleName).Append("',")
                    .Append("@lastName='").Append(command.LastName).Append("',")
                    .Append("@birthDate='").Append(command.BirthDate.ToString()).Append("'");

                model = await connection.QueryAsync<EmployeePutModel>(parameterQuery.ToString());
            }

            return model;
        }
    }
}
