using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using System.Text;
using Utility;

namespace Command.Request.Handler.Department.Post
{
    public class DepartmentPostHandler : BaseHandler, ICommandHandler<DepartmentPostModel>
    {
        private string _query = "Department_Save";

        public DepartmentPostHandler(DapperContext dapperContext) : base(dapperContext) { }

        public async Task<IEnumerable<DepartmentPostModel>> Handle(DepartmentPostModel command)
        {
            IEnumerable<DepartmentPostModel> departments;

            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new StringBuilder();
                parameters.Append(_query).Append(" ")
                        .Append("@name='").Append(command.Name).Append("',")
                        .Append("@code='").Append(command.Code).Append("'");
                departments = await connection.QueryAsync<DepartmentPostModel>(parameters.ToString());
            }

            return departments;
        }
    }
}
