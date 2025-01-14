using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Utility;

namespace Command.Query.Handler.Employee.Get
{
    public class EmployeeGetHandler : BaseHandler, IQueryHandler<EmployeeGetModel, EmployeeGetModel>
    {
        string _query = "Employee_Get";

        public EmployeeGetHandler(DapperContext context) : base(context)
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
