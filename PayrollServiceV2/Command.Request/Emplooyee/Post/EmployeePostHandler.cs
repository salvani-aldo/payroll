using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Command.Request.Emplooyee.Post.Model;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Emplooyee.Post
{
    public sealed class EmployeePostHandler : BaseHandler, ICommandHandler<EmployeePostCommandModel, EmployeePostQueryModel>
    {
        private readonly string _employeeQuery;
        public EmployeePostHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _employeeQuery = "Employee_Save";
        }

        public async Task<IEnumerable<EmployeePostQueryModel>> Handle(EmployeePostCommandModel query)
        {
            IEnumerable<EmployeePostQueryModel> model;

            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@FirstName", query.FirstName);
                queryParams.Add("@MiddleName", query.MiddleName);
                queryParams.Add("@LastName", query.LastName);
                queryParams.Add("@BirthDate", query.BirthDate);
                queryParams.Add("@DepartmentId", query.DepartmentId);
                queryParams.Add("@PositionId", query.PositionId);
                queryParams.Add("@UserId", query.UserId);
                queryParams.Add("@Email", query.Email);
                queryParams.Add("@Phone", query.Phone);
                queryParams.Add("@GenderId", query.GenderId);
                queryParams.Add("@StatusId", query.StatusId);

                model = await connection.QueryAsync<EmployeePostQueryModel>(_employeeQuery, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }

            return model;
        }
    }
}
