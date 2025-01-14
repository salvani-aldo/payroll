using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Education.Delete.ByEmployoeeId
{
    public sealed class EducationDeleteByEmployeeIdHandler : BaseHandler, ICommandHandler<EducationDeleteByEmployeeIdModel, EducationDeleteByEmployeeIdModel>
    {
        private readonly string _query;
        public EducationDeleteByEmployeeIdHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Education_DeleteByEmployeeId";
        }

        public async Task<IEnumerable<EducationDeleteByEmployeeIdModel>> Handle(EducationDeleteByEmployeeIdModel command)
        {
            IEnumerable<EducationDeleteByEmployeeIdModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@Id", command.Id);

                model = await connection.QueryAsync<EducationDeleteByEmployeeIdModel>(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }

            return model;
        }
    }
}
