using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Query.Education
{
    public sealed class EducationGetHandler : BaseHandler, IQueryHandler<EducationGetModel>
    {
        private readonly string _query;
        public EducationGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context,payrollContext, mapper)
        {
            _query = "Education_Get";
        }

        public async Task<IEnumerable<EducationGetModel>> Handle()
        {
            IEnumerable<EducationGetModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                model = await connection.QueryAsync<EducationGetModel>(_query);
            }

            return model;
        }
    }
}
