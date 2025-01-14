using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Command.Query.User.GetById.Model;
using Dapper;
using Repository;
using Utility;

namespace Command.Query.User.GetById
{
    public sealed class UserGetByNameHandler : BaseHandler, ICommandHandler<UserGetByNameCommandModel, UserGetByNameQueryModel>
    {
        private readonly string _query;
        public UserGetByNameHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "User_Get";
        }

        public async Task<IEnumerable<UserGetByNameQueryModel>> Handle(UserGetByNameCommandModel command)
        {
            IEnumerable<UserGetByNameQueryModel> model;

            using (var connection = _dapperContext.CreateConnection())
            {
                if (string.IsNullOrEmpty(command.Name))
                {
                    model = await connection.QueryAsync<UserGetByNameQueryModel>(_query);
                }
                else
                {
                    var queryParams = new DynamicParameters();
                    queryParams.Add("@Name", command.Name);
                    model = await connection.QueryAsync<UserGetByNameQueryModel>(_query, queryParams, commandType: System.Data.CommandType.StoredProcedure);
                }
            }

            return model;
        }
    }
}
