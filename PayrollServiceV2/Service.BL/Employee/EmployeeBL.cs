using AutoMapper;
using Command.Message;
using Command.Message.Interface;
using Command.Query.Address;
using Command.Query.Education;
using Command.Query.Employee;
using Command.Request.Address.Delete.ByEMployee;
using Command.Request.Address.Delete.SecondAddress;
using Command.Request.Address.Post.Model;
using Command.Request.Education.Delete.ByEmployoeeId;
using Command.Request.Education.Delete.NonExistingId;
using Command.Request.Education.Post;
using Command.Request.Education.Post.Model;
using Command.Request.Education.Put;
using Command.Request.Emplooyee.Delete;
using Command.Request.Emplooyee.Post.Model;
using Command.Request.Emplooyee.Put;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using Model.Validation.Address;
using Model.Validation.Education;
using Model.Validation.Employee;
using Service.BL._Base;
using Service.BL._Interface;
using Service.BL.Employee.Model;
using System.Transactions;

namespace Service.BL.Employee
{
    public sealed class EmployeeBL : BaseBL, IEmployeeBL
    {
        public EmployeeBL(Message message, IMemoryCache cacheProvider, IMapper mapper) : base(message, cacheProvider, mapper)
        {
        }

        public async Task<IEnumerable<IQuery>> Delete(int id)
        {
            EmployeeDeleteModel model = new EmployeeDeleteModel(id);
            EmployeeDeleteModelValidator validationRules = new EmployeeDeleteModelValidator();
            validationRules.ValidateAndThrow(model);

            IEnumerable<EmployeeDeleteModel> employeeModel;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _message.Send(new AddressDeleteModel(model.Id));
                await _message.Send<EducationDeleteByEmployeeIdModel>(new EducationDeleteByEmployeeIdModel(model.Id));
                employeeModel = await _message.Send<EmployeeDeleteModel>(model);
                scope.Complete();
            }

            return employeeModel;
        }

        public async Task<IEnumerable<IQuery>> Get()
        {
            IEnumerable<EmployeeGetModel> employeeModel;
            IEnumerable<EmployeeQueryModel> employeeModels = new List<EmployeeQueryModel>();
            IEnumerable<AddressGetModel> addressModels = new List<AddressGetModel>();
            //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{
                employeeModel = await _message.Send<EmployeeGetModel>(new EmployeeGetModel());
                _mapper.Map(employeeModel, employeeModels);

                AddressGetModel addressModel = new AddressGetModel();
                var result = await _message.Send<AddressGetModel>(addressModel);
                _mapper.Map(result, addressModels);

                var educationList = await _message.Send<EducationGetModel>();

                MappedEmployeeAndAddress(employeeModels, addressModels, educationList);
            //}

            return employeeModels;
        }

        public async Task<IEnumerable<IQuery>> Save(EmployeeCommandModel model)
        {
            EmployeePostCommandModel employeePostCommandModel = new EmployeePostCommandModel();
            _mapper.Map(model, employeePostCommandModel);

            EmployeePostCommandModelValidator validationRules = new EmployeePostCommandModelValidator();
            validationRules.ValidateAndThrow(employeePostCommandModel);

            AddressPostModelValidator addressPostModelValidator = new AddressPostModelValidator();

            IEnumerable<EmployeePostQueryModel> employeeResult;
            List<AddressPostQueryModel> addressModel = new List<AddressPostQueryModel>();

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                employeeResult = await _message.Send<EmployeePostQueryModel>(employeePostCommandModel);
                var employeeId = employeeResult.First().Id;
                foreach (var address in model.Addresses.ToList())
                {
                    address.EmployeeId = employeeId;
                    addressPostModelValidator.ValidateAndThrow(address);

                    var addressResult = await _message.Send<AddressPostQueryModel>(address);

                    addressModel.Add(addressResult.First());
                }

                foreach (var education in model.Educations)
                {
                    education.EmployeeId = employeeId;

                    EducationPostModelValidator educationModelValidator = new EducationPostModelValidator();
                    educationModelValidator.ValidateAndThrow(education);


                    await _message.Send<EducationPostQueryModel>(education);
                }

                scope.Complete();
            }

            return employeeResult;
        }

        public async Task<EmployeePutCommandModel> Update(EmployeePutCommandModel model)
        {
            EmployeePutModel employeePutModel = new EmployeePutModel();
            _mapper.Map(model, employeePutModel);

            EmployeePutModeValidator validationRules = new EmployeePutModeValidator();
            validationRules.ValidateAndThrow(employeePutModel);

            AddressPutModelValidator addressValidationRules = new AddressPutModelValidator();
            AddressPostModelValidator addressPostModelValidator = new AddressPostModelValidator();
            AddressPostCommandModel addressPostCommandModel = new AddressPostCommandModel();
            EducationPutModelValidator educationValidationRules = new EducationPutModelValidator();
            EducationPostCommandModel educationPostCommandModel = new EducationPostCommandModel();

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var employeeResult = await _message.Send<EmployeePutModel>(employeePutModel);

                if (employeeResult.Count() == 0)
                {
                    return null;
                }

                if (model.Addresses.Count == 1 && model.Addresses[0].Id > 0)
                {
                    AddressDeleteSecondAddressModel addressDeleteSecondAddressModel = new AddressDeleteSecondAddressModel(employeePutModel.Id, model.Addresses[0].Id);
                    await _message.Send(addressDeleteSecondAddressModel);
                }

                if (model.Educations.Count == 1 && model.Educations[0].Id > 0)
                {
                    EducationDeleteByNonExistingIdModel educationDeleteByNonExistingIdModel = new EducationDeleteByNonExistingIdModel();
                    var ids = model.Educations.Select(i => i.Id).ToList();
                    educationDeleteByNonExistingIdModel.Ids = ids;
                    await _message.Send(educationDeleteByNonExistingIdModel);
                }

                foreach (var address in model.Addresses.ToList())
                {
                    if (address.Id != 0)
                    {
                        addressValidationRules.ValidateAndThrow(address);
                        await _message.Send(address);
                    }
                    else
                    {
                        _mapper.Map(address, addressPostCommandModel);
                        addressPostModelValidator.ValidateAndThrow(addressPostCommandModel);

                        var result = await _message.Send<AddressPostQueryModel>(addressPostCommandModel);
                        address.Id = result.First().Id;
                    }
                }

                foreach (var education in model.Educations)
                {
                    if (education.Id != 0)
                    {
                        educationValidationRules.ValidateAndThrow(education);
                        await _message.Send<EducationPutModel>(education);
                    }
                    else
                    {
                        _mapper.Map(education, educationPostCommandModel);
                        var educationResult = await _message.Send<EducationPostQueryModel>(educationPostCommandModel);
                        education.Id = educationResult.First().Id;
                    }
                }

                scope.Complete();
            }

            return model;
        }

        private void MappedEmployeeAndAddress(IEnumerable<EmployeeQueryModel> employeeModels, IEnumerable<AddressGetModel> addressModels, IEnumerable<EducationGetModel> educationModel)
        {
            IEnumerable<EducationGetModel> educationGetModels = new List<EducationGetModel>();
            employeeModels.ToList().ForEach(employeeModel =>
            {
                var addressResult = addressModels.Where(i => i.EmployeeId == employeeModel.Id).ToList();
                var educationResult = educationModel.Where(i => i.EmployeeId == employeeModel.Id).ToList();

                employeeModel.Addresses = addressResult.ToList();
                employeeModel.Educations = educationResult.ToList();
            });
        }
    }
}
