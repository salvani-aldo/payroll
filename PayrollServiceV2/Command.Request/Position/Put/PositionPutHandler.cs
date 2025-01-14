using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Command.Request.Position.Put.Model;
using Dapper;
using Repository;
using System.Text;
using Utility;

namespace Command.Request.Position.Put
{
    public sealed class PositionPutHandler : BaseHandler, ICommandHandler<PositionPutCommandModel, PositionPutRequestModel>
    {
        private string _query = "Position_Update";

        public PositionPutHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
        }

        public async Task<IEnumerable<PositionPutRequestModel>> Handle(PositionPutCommandModel command)
        {
            IEnumerable<PositionPutRequestModel> positionPutModels = new List<PositionPutRequestModel>();

            using (var connection = _dapperContext.CreateConnection())
            {
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append(_query).Append(" ")
                    .Append("@id=").Append(command.Id).Append(",")
                    .Append("@name='").Append(command.Name).Append("',")
                    .Append("@code='").Append(command.Code).Append("', ")
                    .Append("@userId='").Append(command.UserId).Append("', ")
                    .Append("@departmentId='").Append(command.DepartmentId).Append("'");

                positionPutModels = await connection.QueryAsync<PositionPutRequestModel>(queryBuilder.ToString());
            }

            return positionPutModels;
        }
    }
}
