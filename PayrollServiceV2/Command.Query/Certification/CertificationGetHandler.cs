using AutoMapper;
using Command.Message.Base;
using Command.Message.Interface;
using Command.Query.Certification.Model;
using Repository;
using Utility;

namespace Command.Query.Certification
{
    public sealed class CertificationGetHandler : BaseHandler, ICommandHandler<CertificationGetCommandModel, CertificationGetQueryModel>
    {
        private readonly string _query;
        public CertificationGetHandler(DapperContext context, PayrollContext payrollContext, IMapper mapper) : base(context, payrollContext, mapper)
        {
            _query = "Certification_GetByEmployeeId";
        }

        public Task<IEnumerable<CertificationGetQueryModel>> Handle(CertificationGetCommandModel command)
        {
            using (var connection = _dapperContext.CreateConnection())
            {

            }

            throw new NotImplementedException();
        }
    }
}
