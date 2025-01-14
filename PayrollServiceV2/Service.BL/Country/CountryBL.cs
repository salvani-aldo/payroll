using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.Country;
using Microsoft.Extensions.Caching.Memory;
using Service.BL._Base;
using Service.BL._Interface;

namespace Service.BL.Country
{
    public sealed class CountryBL : BaseBL, ICountryBL
    {
        private readonly string _cacheKey;
        public CountryBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
            _cacheKey = "countries";
        }

        public async Task<IEnumerable<IQuery>> Get()
        {
            IEnumerable<IQuery> modelResult = (IEnumerable<IQuery>)_cacheProvider.Get(_cacheKey);
            if (modelResult == null || modelResult.Count() == 0)
            {
                modelResult = await _message.Send<CountryGetModel>(new CountryGetModel());
                _cacheProvider.Set(_cacheKey, modelResult, _memoryCacheEntryOptions);
            }

            return modelResult;
        }
    }
}
