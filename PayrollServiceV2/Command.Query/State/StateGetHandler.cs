using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Repository;
using Repository.Interfaces;
using Utility;

namespace Command.Query.State
{
    public sealed class StateGetHandler : BaseHandler, ICommandHandler<StateGetModel, StateGetModel>
    {
        //private string _query = "State_Get";

        private readonly PayrollContext _payrollContext;
        public StateGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _payrollContext = payrollContext;
        }

        public async Task<IEnumerable<StateGetModel>> Handle(StateGetModel query)
        {
            using (IUnitOfWork<Repository.Models.Employee> uow = new UnitOfWork<Repository.Models.Employee>(_payrollContext))
            {
                var v = uow.Repository().GetAll();
            }

            //IEnumerable<StateGetModel> model;
            //var result = _payrollContext.State.ToImmutableList();

            //EF.com


            //using (var connection = _dapperContext.CreateConnection())
            //{
            //    model = await connection.QueryAsync<StateGetModel>(_query);
            //}

            //return model;

            return new List<StateGetModel>();
        }
    }
}
