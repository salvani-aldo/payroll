using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Query.Status
{
    public sealed class StatusGetHandler : BaseHandler, IQueryHandler<StatusGetModel>
    {
        private readonly string _query;
        public StatusGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Status_Get";
        }

        public async Task<IEnumerable<StatusGetModel>> Handle()
        {
            IEnumerable<StatusGetModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                model = await connection.QueryAsync<StatusGetModel>(_query);
            }

            return model;
        }
    }
}
