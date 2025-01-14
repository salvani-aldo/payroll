using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using System.Text;
using Utility;

namespace Command.Request.Handler.Position.Put
{
    public sealed class PositionPutHandler : BaseHandler, ICommandHandler<PositionPutModel>
    {
        private string _query = "Position_Update";

        public PositionPutHandler(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PositionPutModel>> Handle(PositionPutModel command)
        {
            IEnumerable<PositionPutModel> positionPutModels = new List<PositionPutModel>();

            using (var connection = _dapperContext.CreateConnection())
            {
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append(_query).Append(" ")
                    .Append("@id=").Append(command.Id).Append(",")
                    .Append("@name='").Append(command.Name).Append("',")
                    .Append("@code='").Append(command.Code).Append("'");

                positionPutModels = await connection.QueryAsync<PositionPutModel>(queryBuilder.ToString());
            }

            return positionPutModels;
        }
    }
}
