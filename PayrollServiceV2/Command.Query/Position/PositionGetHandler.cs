using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Query.Position
{
    public sealed class PositionGetHandler : BaseHandler, IQueryHandler<PositionGetModel>
    {
        private readonly string _query;

        public PositionGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Position_Get";
        }

        public async Task<IEnumerable<PositionGetModel>> Handle()
        {
            IEnumerable<PositionGetModel> positions;

            using (var connection = _dapperContext.CreateConnection())
            {
                positions = await connection.QueryAsync<PositionGetModel>(_query);
            }

            return positions;
        }
    }
}
