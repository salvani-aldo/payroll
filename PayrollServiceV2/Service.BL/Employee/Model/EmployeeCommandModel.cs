using Command.Request.Address.Post.Model;
using Command.Request.Education.Post;
using Command.Request.Emplooyee.Post.Model;

namespace Service.BL.Employee.Model
{
    public sealed class EmployeeCommandModel : EmployeePostCommandModel
    {
        public List<AddressPostCommandModel> Addresses { get; set; } = new List<AddressPostCommandModel>();
        public List<EducationPostCommandModel> Educations { get; set; } = new List<EducationPostCommandModel>();
    }
}
