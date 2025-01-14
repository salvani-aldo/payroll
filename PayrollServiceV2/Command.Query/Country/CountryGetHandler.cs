using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Query.Country
{
    public sealed class CountryGetHandler : BaseHandler, ICommandHandler<CountryGetModel, CountryGetModel>
    {
        private string _query = "Country_Get";

        public CountryGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext,mapper)
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
