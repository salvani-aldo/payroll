using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.Degree;
using Microsoft.Extensions.Caching.Memory;
using Service.BL._Base;
using Service.BL._Interface;

namespace Service.BL.Degree
{
    public sealed class DegreeBL : BaseBL, IDegreeBL
    {
        private readonly string _cacheKey;
        public DegreeBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
            _cacheKey = "degree";
        }

        public async Task<IEnumerable<IQuery>> Get()
        {
            IEnumerable<IQuery> cacheValue = (IEnumerable<DegreeGetModel>)_cacheProvider.Get(_cacheKey);
            if (cacheValue == null)
            {
                cacheValue = await _message.Send<DegreeGetModel>();
                _cacheProvider.Set(_cacheKey, cacheValue);
            }

            return cacheValue;
        }
    }
}
