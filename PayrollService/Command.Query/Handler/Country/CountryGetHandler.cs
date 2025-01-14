using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Utility;

namespace Command.Query.Handler.Country
{
    public class CountryGetHandler : BaseHandler, IQueryHandler<CountryGetModel, CountryGetModel>
    {
        private string _query = "Country_Get";

        public CountryGetHandler(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CountryGetModel>> Handle(CountryGetModel query)
        {
            IEnumerable<CountryGetModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                model = await connection.QueryAsync<CountryGetModel>(_query);
            }

            return model;
        }
    }
}
