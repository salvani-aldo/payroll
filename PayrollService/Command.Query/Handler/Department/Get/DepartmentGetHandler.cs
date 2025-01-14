using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Utility;

namespace Command.Query.Handler.Department.Get
{
    public sealed class DepartmentGetHandler : BaseHandler, IQueryHandler<DepartmentGetModel, DepartmentGetModel>
    {
        private string _query = "Department_Get";

        public DepartmentGetHandler(DapperContext dapperContext) : base(dapperContext) { }

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
