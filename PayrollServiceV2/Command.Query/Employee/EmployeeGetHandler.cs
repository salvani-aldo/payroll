using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Query.Employee
{
    public class EmployeeGetHandler : BaseHandler, ICommandHandler<EmployeeGetModel, EmployeeGetModel>
    {
        string _query = "Employee_Get";

        public EmployeeGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
        }

        public async Task<IEnumerable<EmployeeGetModel>> Handle(EmployeeGetModel query)
        {
            IEnumerable<EmployeeGetModel> model;

            using (var connection = _dapperContext.CreateConnection())
            {
                model = await connection.QueryAsync<EmployeeGetModel>(_query);
            }

            return model;
        }
    }
}
