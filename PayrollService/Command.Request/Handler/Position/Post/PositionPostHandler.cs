using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using System.Text;
using Utility;

namespace Command.Request.Handler.Position.Post
{
    public sealed class PositionPostHandler : BaseHandler, ICommandHandler<PositionPostModel>
    {
        private string _query = "Position_Save";

        public PositionPostHandler(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PositionPostModel>> Handle(PositionPostModel command)
        {
            IEnumerable<PositionPostModel> positionPostModels = new List<PositionPostModel>();
            using (var conntection = _dapperContext.CreateConnection())
            {
                var parameters = new StringBuilder();
                parameters.Append(_query).Append(" ")
                        .Append("@name='").Append(command.Name).Append("',")
                        .Append("@code='").Append(command.Code).Append("'");

                positionPostModels = await conntection.QueryAsync<PositionPostModel>(parameters.ToString());
            }

            return positionPostModels;
        }
    }
}
