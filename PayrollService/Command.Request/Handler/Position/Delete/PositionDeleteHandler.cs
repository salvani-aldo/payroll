using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using System.Text;
using Utility;

namespace Command.Request.Handler.Position.Delete
{
    public sealed class PositionDeleteHandler : BaseHandler, ICommandHandler<PositionDeleteModel>
    {
        private string _query = "Position_Delete";

        public PositionDeleteHandler(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PositionDeleteModel>> Handle(PositionDeleteModel command)
        {
            List<PositionDeleteModel> positionDeleteModels = new List<PositionDeleteModel>();

            using (var connection = _dapperContext.CreateConnection())
            {
                StringBuilder queryStringBuilder = new StringBuilder();
                queryStringBuilder.Append(_query).Append(" ")
                    .Append("@id=").Append(command.Id.ToString());

                await connection.QueryAsync(queryStringBuilder.ToString());
            }
            
            positionDeleteModels.Add(command);

            return positionDeleteModels;
        }
    }
}
