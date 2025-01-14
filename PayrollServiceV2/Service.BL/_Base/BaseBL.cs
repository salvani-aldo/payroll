using AutoMapper;
using Command.Message;
using Microsoft.Extensions.Caching.Memory;

namespace Service.BL._Base
{
    public abstract class BaseBL
    {
        protected readonly Message _message;
        protected readonly IMemoryCache _cacheProvider;
        protected readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;
        protected readonly IMapper _mapper;
        public BaseBL(Message message, IMemoryCache cacheProvider, IMapper mapper)
        {
            _message = message;
            _cacheProvider = cacheProvider;
            _mapper = mapper;

            _memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(60))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(60))
                .SetPriority(CacheItemPriority.Normal);
        }
    }
}
