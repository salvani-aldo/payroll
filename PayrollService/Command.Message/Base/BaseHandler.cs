using Utility;

namespace Command.Message.Base
{
    public abstract class BaseHandler
    {
        public readonly DapperContext _dapperContext;

        public BaseHandler(DapperContext context)
        {
            _dapperContext = context;
        }
    }
}
