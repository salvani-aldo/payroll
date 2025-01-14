using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Address.Delete.SecondAddress
{
    public sealed class AddressDeleteSecondAddressHandler : BaseHandler, ICommandHandler<AddressDeleteSecondAddressModel>
    {
        private readonly string _query;

        public AddressDeleteSecondAddressHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Address_DeleteSecondAddress";
        }

        public async Task Handle(AddressDeleteSecondAddressModel command)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@EmployeeId", command.EmployeeId);
                queryParams.Add("@FirstAddressId", command.FirstAddressId);

                await connection.QueryAsync(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
