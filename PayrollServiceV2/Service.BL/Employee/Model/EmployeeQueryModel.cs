using Command.Query.Address;
using Command.Query.Education;
using Command.Request.Emplooyee.Post.Model;

namespace Service.BL.Employee.Model
{
    public sealed class EmployeeQueryModel : EmployeePostQueryModel
    {
        public List<AddressGetModel> Addresses { get; set; } = new List<AddressGetModel>();
        public List<EducationGetModel> Educations { get; set; } = new List<EducationGetModel>();
    }
}
