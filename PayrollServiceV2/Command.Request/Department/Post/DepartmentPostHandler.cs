using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Command.Request.Department.Post.Model;
using Dapper;
using Repository;
using System.Text;
using Utility;

namespace Command.Request.Department.Post
{
    public sealed class DepartmentPostHandler : BaseHandler, ICommandHandler<DepartmentPostCommandModel, DepartmentPostQueryModel>
    {
        private string _query = "Department_Save";

        public DepartmentPostHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
        }

        public async Task<IEnumerable<DepartmentPostQueryModel>> Handle(DepartmentPostCommandModel query)
        {
            IEnumerable<DepartmentPostQueryModel> departments;

            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new StringBuilder();
                parameters.Append(_query).Append(" ")
                        .Append("@name='").Append(query.Name).Append("',")
                        .Append("@code='").Append(query.Code).Append("', ")
                        .Append("@usderId='").Append(query.UserId).Append("'");
                departments = await connection.QueryAsync<DepartmentPostQueryModel>(parameters.ToString());
            }

            return departments;
        }
    }
}
