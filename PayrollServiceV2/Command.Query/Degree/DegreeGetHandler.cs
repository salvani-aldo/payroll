using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Query.Degree
{
    public sealed class DegreeGetHandler : BaseHandler, IQueryHandler<DegreeGetModel>
    {
        private readonly string _query;
        public DegreeGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext,mapper)
        {
            _query = "Degree_Get";
        }

        public async Task<IEnumerable<DegreeGetModel>> Handle()
        {
            IEnumerable<DegreeGetModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                model = await connection.QueryAsync<DegreeGetModel>(_query);
            }

            return model;
        }
    }
}
