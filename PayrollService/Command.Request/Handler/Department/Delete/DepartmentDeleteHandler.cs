
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using System.Text;
using Utility;

namespace Command.Request.Handler.Department.Delete
{
    public sealed class DepartmentDeleteHandler : BaseHandler, ICommandHandler<DepartmentDeleteModel>
    {
        private string _query = "Department_Delete";

        public DepartmentDeleteHandler(DapperContext dapperContext) : base(dapperContext) { }

        public async Task<IEnumerable<DepartmentDeleteModel>> Handle(DepartmentDeleteModel command)
        {
            IEnumerable<DepartmentDeleteModel> departments = new List<DepartmentDeleteModel>();

            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new StringBuilder();
                parameters.Append(_query).Append(" ")
                        .Append("@id=").Append(command.Id);
                await connection.QueryAsync<DepartmentDeleteModel>(parameters.ToString());
            }

            return departments;
        }
    }
}
