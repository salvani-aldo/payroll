using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.Department;
using Command.Request.Department.Delete.ByEmployee;
using Command.Request.Department.Post.Model;
using Command.Request.Department.Put.Model;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using Model.Validation.Department;
using Service.BL._Base;
using Service.BL._Interface;

namespace Service.BL.Department
{
    public sealed class DepartmentBL : BaseBL, IDepartmentBL
    {
        private readonly string _cacheKey;
        public DepartmentBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
            _cacheKey = "departments";
        }

        public async Task<IEnumerable<IQuery>> Delete(int id)
        {
            DepartmentDeleteModel model = new DepartmentDeleteModel(id);

            DepartmentDeleteModelValidator modelValidation = new DepartmentDeleteModelValidator();
            modelValidation.ValidateAndThrow(model);

            IEnumerable<DepartmentDeleteModel> result = await _message.Send<DepartmentDeleteModel>(model);

            _cacheProvider.Remove(_cacheKey);

            return result;
        }

        public async Task<IEnumerable<IQuery>> Get()
        {
            IEnumerable<IQuery> modelResult = (IEnumerable<DepartmentGetModel>)_cacheProvider.Get(_cacheKey);
            if (modelResult == null || modelResult.Count() == 0)
            {
                modelResult = await _message.Send<DepartmentGetModel>(new DepartmentGetModel());
                _cacheProvider.Set(_cacheKey, modelResult, _memoryCacheEntryOptions);
            }

            return modelResult;
        }

        public async Task<IEnumerable<IQuery>> Save(DepartmentPostCommandModel model)
        {
            DepartmentPostModelValidator modelValidation = new DepartmentPostModelValidator();
            modelValidation.ValidateAndThrow(model);

            var result = await _message.Send<DepartmentPostQueryModel>(model);

            _cacheProvider.Remove(_cacheKey);

            return result;
        }

        public async Task<IEnumerable<IQuery>> Update(DepartmentPutCommandModel model)
        {
            DepartmentPutModelValidator validationRules = new DepartmentPutModelValidator();
            validationRules.ValidateAndThrow(model);

            var queryResult = await _message.Send<DepartmentPutQueryModel>(model);

            _cacheProvider.Remove(_cacheKey);

            return queryResult;
        }
    }
}
