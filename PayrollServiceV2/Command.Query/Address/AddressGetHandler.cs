using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Repository;
using Utility;

namespace Command.Query.Address
{
    public sealed class AddressGetHandler : BaseHandler, ICommandHandler<AddressGetModel, AddressGetModel>
    {
        //private readonly string _query;

        public AddressGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            //_query = "Address_Get";
        }

        public async Task<IEnumerable<AddressGetModel>> Handle(AddressGetModel query)
        {
            IEnumerable<AddressGetModel> model = new List<AddressGetModel>();

            

            var result = await _payrollContext.Address.ToListAsync();
            _mapper.Map(result, model);

            //using (var connection = _dapperContext.CreateConnection())
            //{

            //    model = await connection.QueryAsync<AddressGetModel>(_query);
            //}

            return model;
        }
    }
}
