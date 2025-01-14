using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Education.Delete.ById
{
    public sealed class EducationDeleteHandler : BaseHandler, ICommandHandler<EducationDeleteModel, EducationDeleteModel>
    {
        private readonly string _query;
        public EducationDeleteHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Education_Delete";
        }

        public async Task<IEnumerable<EducationDeleteModel>> Handle(EducationDeleteModel command)
        {
            IEnumerable<EducationDeleteModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                model = await connection.QueryAsync<EducationDeleteModel>(_query);
            }

            return model;
        }
    }
}
