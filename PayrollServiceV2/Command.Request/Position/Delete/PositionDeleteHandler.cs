using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Repository;
using System.Text;
using Utility;

namespace Command.Request.Position.Delete
{
    public sealed class PositionDeleteHandler : BaseHandler, ICommandHandler<PositionDeleteModel, PositionDeleteModel>
    {
        private readonly string _query;

        public PositionDeleteHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Position_Delete";
        }

        public async Task<IEnumerable<PositionDeleteModel>> Handle(PositionDeleteModel command)
        {
            IEnumerable<PositionDeleteModel> model;
            using (var connection = _dapperContext.CreateConnection())
            {
                StringBuilder queryStringBuilder = new StringBuilder();
                queryStringBuilder.Append(_query).Append(" ")
                    .Append("@id=").Append(command.Id.ToString());

                model = await connection.QueryAsync<PositionDeleteModel>(queryStringBuilder.ToString());
            }

            return model;
        }

        //public async Task Handle(PositionDeleteModel command)
        //{
        //    using (var connection = _dapperContext.CreateConnection())
        //    {
        //        StringBuilder queryStringBuilder = new StringBuilder();
        //        queryStringBuilder.Append(_query).Append(" ")
        //            .Append("@id=").Append(command.Id.ToString());

        //        await connection.QueryAsync(queryStringBuilder.ToString());
        //    }
        //}
    }
}
