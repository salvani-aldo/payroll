using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.Gender;
using Microsoft.Extensions.Caching.Memory;
using Service.BL._Base;
using Service.BL._Interface;

namespace Service.BL.Gender
{
    public sealed class GenderBL : BaseBL, IGenderBL
    {
        private readonly string _cacheKey;
        public GenderBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
            _cacheKey = "gender";
        }

        public async Task<IEnumerable<IQuery>> Get()
        {
            IEnumerable<IQuery> cacheValue = (IEnumerable<GenderGetModel>)_cacheProvider.Get(_cacheKey);
            if (cacheValue == null || cacheValue.Count() == 0)
            {
                cacheValue = await _message.Send<GenderGetModel>();
                _cacheProvider.Set(_cacheKey, cacheValue);
            }

            return cacheValue;
        }
    }
}
