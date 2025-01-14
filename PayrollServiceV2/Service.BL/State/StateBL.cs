using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.State;
using Microsoft.Extensions.Caching.Memory;
using Service.BL._Base;
using Service.BL._Interface;

namespace Service.BL.State
{
    public sealed class StateBL : BaseBL, IStateBL
    {
        private readonly string _cacheKey;
        public StateBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
            _cacheKey = "state";
        }

        public async Task<IEnumerable<IQuery>> GetStates()
        {
            IEnumerable<IQuery> modelResult = (IEnumerable<StateGetModel>)_cacheProvider.Get(_cacheKey);
            if (modelResult == null || modelResult.Count() == 0)
            {
                modelResult = await _message.Send<StateGetModel>(new StateGetModel());
                _cacheProvider.Set(_cacheKey, modelResult, _memoryCacheEntryOptions);
            }

            return modelResult;
        }
    }
}
