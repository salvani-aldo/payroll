using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Education.Delete.NonExistingId
{
    public sealed class EducationDeleteByNonExistingIdHandler : BaseHandler, ICommandHandler<EducationDeleteByNonExistingIdModel>
    {
        private readonly string _query;
        public EducationDeleteByNonExistingIdHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Education_DeleteNonExistingId";
        }

        public async Task Handle(EducationDeleteByNonExistingIdModel command)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var ids = string.Concat(command.Ids);
                var queryParams = new DynamicParameters();
                queryParams.Add("@ids", ids);

                await connection.QueryAsync(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
