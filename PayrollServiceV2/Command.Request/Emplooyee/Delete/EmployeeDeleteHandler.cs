using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Emplooyee.Delete
{
    public sealed class EmployeeDeleteHandler : BaseHandler, ICommandHandler<EmployeeDeleteModel, EmployeeDeleteModel>
    {
        private readonly string _query;

        public EmployeeDeleteHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Employee_Delete";
        }

        public async Task<IEnumerable<EmployeeDeleteModel>> Handle(EmployeeDeleteModel command)
        {
            IEnumerable<EmployeeDeleteModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@employeeId", command.Id);

                model = await connection.QueryAsync<EmployeeDeleteModel>(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }

            return model;
        }
    }
}
