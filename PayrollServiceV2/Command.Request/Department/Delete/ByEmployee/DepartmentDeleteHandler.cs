using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using System.Text;
using Utility;

namespace Command.Request.Department.Delete.ByEmployee
{
    public sealed class DepartmentDeleteHandler : BaseHandler, ICommandHandler<DepartmentDeleteModel, DepartmentDeleteModel>
    {
        private readonly string _query;

        public DepartmentDeleteHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Department_Delete";
        }

        public async Task<IEnumerable<DepartmentDeleteModel>> Handle(DepartmentDeleteModel command)
        {
            IEnumerable<DepartmentDeleteModel> id;
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new StringBuilder();
                parameters.Append(_query).Append(" ")
                        .Append("@id=").Append(command.Id);
                id = await connection.QueryAsync<DepartmentDeleteModel>(parameters.ToString());
            }

            return id;
        }
    }
}
