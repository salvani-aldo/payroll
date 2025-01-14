using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Query.Department
{
    public sealed class DepartmentGetHandler : BaseHandler, ICommandHandler<DepartmentGetModel, DepartmentGetModel>
    {
        private string _query = "Department_Get";

        public DepartmentGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext,mapper)
        {
        }

        public async Task<IEnumerable<DepartmentGetModel>> Handle(DepartmentGetModel query)
        {
            IEnumerable<DepartmentGetModel> departments;

            using (var connection = _dapperContext.CreateConnection())
            {
                departments = await connection.QueryAsync<DepartmentGetModel>(_query);
            }

            return departments;
        }
    }
}
