using AutoMapper;
using Repository;
using Utility;

namespace Command.Message.Base
{
    public class BaseHandler
    {
        public readonly DapperContext _dapperContext;
        public readonly IMapper _mapper;
        public readonly PayrollContext _payrollContext;

        public BaseHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper)
        {
            _dapperContext = context;
            _mapper = mapper;
            _payrollContext = payrollContext;
        }
    }
}
