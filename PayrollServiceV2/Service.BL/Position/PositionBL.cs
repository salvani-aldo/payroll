using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.Position;
using Command.Request.Position.Delete;
using Command.Request.Position.Post.Model;
using Command.Request.Position.Put.Model;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using Model.Validation.Position;
using Service.BL._Base;
using Service.BL._Interface;

namespace Service.BL.Position
{
    public sealed class PositionBL : BaseBL, IPositionBL
    {
        private readonly string _cacheKey;
        public PositionBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
            _cacheKey = "position";
        }

        public async Task<IEnumerable<IQuery>> Delete(int id)
        {
            PositionDeleteModel model = new PositionDeleteModel(id);

            PositionDeleteModelValidator modelValidation = new PositionDeleteModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send<PositionDeleteModel>(model);

            _cacheProvider.Remove(_cacheKey);

            return result;
        }

        public async Task<IEnumerable<IQuery>> Get()
        {
            IEnumerable<IQuery> cacheValue = (IEnumerable<PositionGetModel>)_cacheProvider.Get(_cacheKey);
            if (cacheValue == null)
            {
                cacheValue = await _message.Send<PositionGetModel>();
                _cacheProvider.Set(_cacheKey, cacheValue);
            }

            return cacheValue;
        }

        public async Task<IEnumerable<IQuery>> Save(PositionPostCommandModel model)
        {
            PositionPostModelValidator modelValidation = new PositionPostModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send<PositionPostRequestModel>(model);

            _cacheProvider.Remove(_cacheKey);

            return result;
        }

        public async Task<IEnumerable<IQuery>> Update(PositionPutCommandModel model)
        {
            PositionPutModelValidator modelValidation = new PositionPutModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send<PositionPutRequestModel>(model);

            _cacheProvider.Remove(_cacheKey);

            return result;
        }
    }
}
