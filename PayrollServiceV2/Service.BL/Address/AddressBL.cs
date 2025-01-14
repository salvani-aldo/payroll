//using AutoMapper;
//using Command.Message;
//using Command.Message.Interface;
//using Command.Request.Address.Post;
//using FluentValidation;
//using Microsoft.Extensions.Caching.Memory;
//using Model.Validation.Country;
//using Service.BL._Base;
//using Service.BL._Interface;

//namespace Service.BL.Address
//{
//    public sealed class AddressBL : BaseBL, IAddressBL
//    {
//        public AddressBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
//        {
//        }

//        public Task Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IEnumerable<IQuery>> Save(AddressPostCommandModel model)
//        {
//            AddressPostModelValidator validationRules = new AddressPostModelValidator();
//            validationRules.ValidateAndThrow(model);

//            var result = await _message.Send<AddressPostQueryModel>(model);

//            return result;
//        }
//    }
//}
