using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Command.Request.Education.Post.Model;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Education.Post
{
    public sealed class EducationPostHandler : BaseHandler, ICommandHandler<EducationPostCommandModel, EducationPostQueryModel>
    {
        private readonly string _query;
        public EducationPostHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Education_Post";
        }

        public async Task<IEnumerable<EducationPostQueryModel>> Handle(EducationPostCommandModel command)
        {
            IEnumerable<EducationPostQueryModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@School", command.School);
                queryParams.Add("@DegreeId", command.DegreeId);
                queryParams.Add("@Year", command.Year);
                queryParams.Add("@EmployeeId", command.EmployeeId);
                queryParams.Add("@Course", command.Course);

                model = await connection.QueryAsync<EducationPostQueryModel>(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }

            return model;
        }
    }
}
