using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Utility;

namespace Command.Query.Handler.State
{
    public class StateGetHandler : BaseHandler, IQueryHandler<StateGetModel, StateGetModel>
    {
        private string _query = "State_Get";
        public StateGetHandler(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StateGetModel>> Handle(StateGetModel query)
        {
            IEnumerable<StateGetModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                model = await connection.QueryAsync<StateGetModel>(_query);
            }

            return model;
        }
    }
}
