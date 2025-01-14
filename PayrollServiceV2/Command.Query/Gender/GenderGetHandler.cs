using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Query.Gender
{
    public sealed class GenderGetHandler : BaseHandler, IQueryHandler<GenderGetModel>
    {
        private readonly string _query;
        public GenderGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Gender_Get";
        }

        public async Task<IEnumerable<GenderGetModel>> Handle()
        {
            IEnumerable<GenderGetModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                model = await connection.QueryAsync<GenderGetModel>(_query);
            }

            return model;
        }
    }
}
