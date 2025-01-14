using Command.Request.Address.Put;
using Command.Request.Education.Put;
using Command.Request.Emplooyee.Put;

namespace Service.BL.Employee.Model
{
    public sealed class EmployeePutCommandModel : EmployeePutModel
    {
        public List<AddressPutModel> Addresses { get; set; } = new List<AddressPutModel>();
        public List<EducationPutModel> Educations { get; set; } = new List<EducationPutModel>();
    }
}
