using Command.Message.Base;
using Command.Message.Interface;
using Utility;
using Dapper;
using System.Text;

namespace Command.Request.Handler.Employee.Post
{
    public sealed class EmployeePostHandler : BaseHandler, ICommandHandler<EmployeePostModel>
    {
        private string _query = "Employee_Save";

        public EmployeePostHandler(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeePostModel>> Handle(EmployeePostModel command)
        {
            IEnumerable<EmployeePostModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                StringBuilder queryParameter = new StringBuilder();
                queryParameter.Append(_query).Append(" ")
                    .Append("@firstName='").Append(command.FirstName).Append("',")
                    .Append("@middleName='").Append(command.MiddleName).Append("',")
                    .Append("@lastName='").Append(command.LastName).Append("',")
                    .Append("@birthDate='").Append(command.BirthDate.ToString()).Append("'");

                model = await connection.QueryAsync<EmployeePostModel>(queryParameter.ToString());
            }

            return model;
        }
    }
}
