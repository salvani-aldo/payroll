using Command.Message.Base;
using Command.Message.Interface;
using Command.Request.Handler.Department.Put;
using Dapper;
using System.Text;
using Utility;

namespace Command.Request.Handler.Department.Put
{
    public class DepartmentPutHandler : BaseHandler, ICommandHandler<DepartmentPutModel>
    {
        private string _query = "Department_Update";

        public DepartmentPutHandler(DapperContext dapperContext) : base(dapperContext) { }

        public async Task<IEnumerable<DepartmentPutModel>> Handle(DepartmentPutModel command)
        {
            IEnumerable<DepartmentPutModel> departments;

            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new StringBuilder();
                parameters.Append(_query).Append(" ")
                    .Append("@id=").Append(command.Id).Append(",")
                    .Append("@name='").Append(command.Name).Append("',")
                    .Append("@code='").Append(command.Code).Append("'");
                departments = await connection.QueryAsync<DepartmentPutModel>(parameters.ToString());
            }

            return departments;
        }
    }
}
