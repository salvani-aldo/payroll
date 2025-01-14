using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Command.Request.Position.Post.Model;
using Dapper;
using Repository;
using System.Text;
using Utility;

namespace Command.Request.Position.Post
{
    public sealed class PositionPostHandler : BaseHandler, ICommandHandler<PositionPostCommandModel, PositionPostRequestModel>
    {
        private readonly string _query;

        public PositionPostHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Position_Save";
        }

        public async Task<IEnumerable<PositionPostRequestModel>> Handle(PositionPostCommandModel query)
        {
            IEnumerable<PositionPostRequestModel> positionPostModels = new List<PositionPostRequestModel>();
            using (var conntection = _dapperContext.CreateConnection())
            {
                var parameters = new StringBuilder();
                parameters.Append(_query).Append(" ")
                        .Append("@name='").Append(query.Name).Append("',")
                        .Append("@code='").Append(query.Code).Append("', ")
                        .Append("@userId='").Append(query.UserId).Append("', ")
                        .Append("@departmentId='").Append(query.DepartmentId).Append("'");

                positionPostModels = await conntection.QueryAsync<PositionPostRequestModel>(parameters.ToString());
            }

            return positionPostModels;
        }
    }
}
