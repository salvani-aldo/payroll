using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Command.Request.Department.Put.Model;
using Dapper;
using Repository;
using System.Text;
using Utility;

namespace Command.Request.Department.Put
{
    public sealed class DepartmentPutHandler : BaseHandler, ICommandHandler<DepartmentPutCommandModel, DepartmentPutQueryModel>
    {
        private string _query = "Department_Update";

        public DepartmentPutHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
        }

        public async Task<IEnumerable<DepartmentPutQueryModel>> Handle(DepartmentPutCommandModel command)
        {
            IEnumerable<DepartmentPutQueryModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                var parameters = new StringBuilder();
                parameters.Append(_query).Append(" ")
                    .Append("@id=").Append(command.Id).Append(",")
                    .Append("@name='").Append(command.Name).Append("',")
                    .Append("@code='").Append(command.Code).Append("', ")
                    .Append("@userId='").Append(command.UserId).Append("'");
                model = await connection.QueryAsync<DepartmentPutQueryModel>(parameters.ToString());
            }

            return model;
        }
    }
}
