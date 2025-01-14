using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Address.Put
{
    public sealed class AddressPutHandler : BaseHandler, ICommandHandler<AddressPutModel>
    {
        private readonly string _query;

        public AddressPutHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Address_Update";
        }

        public async Task Handle(AddressPutModel command)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@AddressId", command.Id);
                queryParams.Add("@ZipCode", command.ZipCode);
                queryParams.Add("@City", command.City);
                queryParams.Add("@StateId", command.StateId);
                queryParams.Add("@CountryId", command.CountryId);
                queryParams.Add("@Street", command.Street);
                queryParams.Add("@EmployeeId", command.EmployeeId);

                await connection.ExecuteAsync(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
