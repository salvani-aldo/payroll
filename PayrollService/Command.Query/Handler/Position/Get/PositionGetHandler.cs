using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Utility;

namespace Command.Query.Handler.Position.Get
{
    public sealed class PositionGetHandler : BaseHandler, IQueryHandler<PositionGetModel, PositionGetModel>
    {
        private string _query = "Position_Get";

        public PositionGetHandler(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PositionGetModel>> Handle(PositionGetModel query)
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
