using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Emplooyee.Put
{
    public sealed class EmployeePutHandler : BaseHandler, ICommandHandler<EmployeePutModel, EmployeePutModel>
    {
        private readonly string _query;

        public EmployeePutHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Employee_Update";
        }

        public async Task<IEnumerable<EmployeePutModel>> Handle(EmployeePutModel command)
        {
            IEnumerable<EmployeePutModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@EmployeeId", command.Id);
                queryParams.Add("@FirstName", command.FirstName);
                queryParams.Add("@MiddleName", command.MiddleName);
                queryParams.Add("@LastName", command.LastName);
                queryParams.Add("@BirthDate", command.BirthDate);
                queryParams.Add("@PositionId", command.PositionId);
                queryParams.Add("@DepartmentId", command.DepartmentId);
                queryParams.Add("@UserId", command.UserId);
                queryParams.Add("@Email", command.Email);
                queryParams.Add("@Phone", command.Phone);
                queryParams.Add("@GenderId", command.GenderId);
                queryParams.Add("@StatusId", command.StatusId);

                model = await connection.QueryAsync<EmployeePutModel>(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }

            return model;
        }
    }
}
