using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Command.Request.Address.Post.Model;
using Dapper;
using Repository;
using Utility;

namespace Command.Request.Address.Post
{
    public sealed class AddressPostHandler : BaseHandler, ICommandHandler<AddressPostCommandModel, AddressPostQueryModel>
    {
        private string _query = "Address_Save";

        public AddressPostHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
        }

        public async Task<IEnumerable<AddressPostQueryModel>> Handle(AddressPostCommandModel query)
        {
            IEnumerable<AddressPostQueryModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@ZipCode", query.ZipCode);
                queryParams.Add("@City", query.City);
                queryParams.Add("@StateId", query.StateId);
                queryParams.Add("@CountryId", query.CountryId);
                queryParams.Add("@Street", query.Street);
                queryParams.Add("@EmployeeId", query.EmployeeId);

                model = await connection.QueryAsync<AddressPostQueryModel>(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
            }

            return model;
        }
    }
}
