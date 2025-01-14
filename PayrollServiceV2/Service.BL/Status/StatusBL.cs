using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.Status;
using Microsoft.Extensions.Caching.Memory;
using Service.BL._Base;
using Service.BL._Interface;

namespace Service.BL.Status
{
    public sealed class StatusBL : BaseBL, IStatusBL
    {
        private readonly string _cacheKey;
        public StatusBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
            _cacheKey = "status";
        }

        public async Task<IEnumerable<IQuery>> Get()
        {
            IEnumerable<IQuery> modelResult = (IEnumerable<StatusGetModel>)_cacheProvider.Get(_cacheKey);
            if (modelResult == null)
            {
                modelResult = await _message.Send<StatusGetModel>();
                _cacheProvider.Set(_cacheKey, modelResult);
            }

            return modelResult;
        }
    }
}
