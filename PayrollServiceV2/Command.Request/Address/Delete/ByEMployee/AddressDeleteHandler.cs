using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Address.Delete.ByEMployee
{
    public sealed class AddressDeleteHandler : BaseHandler, ICommandHandler<AddressDeleteModel>
    {
        private readonly string _query;
        public AddressDeleteHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Address_Delete";
        }

        public async Task Handle(AddressDeleteModel command)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@EmployeeId", command.EmployeeId);

                await connection.QueryAsync(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
