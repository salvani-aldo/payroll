
using Command.Message.Interface;

namespace Command.Request.Education.Post
{
    public class EducationPostCommandModel : ICommand
    {
        public string School { get; set; } = "";
        public int DegreeId { get; set; }
        public string Course { get; set; } = "";
        public int Year { get; set; }
        public int EmployeeId { get; set; }
    }
}
