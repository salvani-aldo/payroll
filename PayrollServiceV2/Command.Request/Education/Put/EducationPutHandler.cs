using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Education.Put
{
    public sealed class EducationPutHandler : BaseHandler, ICommandHandler<EducationPutModel, EducationPutModel>
    {
        private readonly string _query;
        public EducationPutHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Education_Put";
        }

        public async Task<IEnumerable<EducationPutModel>> Handle(EducationPutModel command)
        {
            IEnumerable<EducationPutModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@EducationId", command.Id);
                queryParams.Add("@School", command.School);
                queryParams.Add("@DegreeId", command.DegreeId);
                queryParams.Add("@Year", command.Year);
                queryParams.Add("@EmployeeId", command.EmployeeId);
                queryParams.Add("@Course", command.Course);

                model = await connection.QueryAsync<EducationPutModel>(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }

            return model;
        }
    }
}
