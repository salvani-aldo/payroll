using Command.Message.Interface;

namespace Command.Request.Education.Post.Model
{
    public class EducationPostQueryModel : IQuery
    {
        public int Id { get; set; }
        public string School { get; set; } = "";
        public int DegreeId { get; set; }
        public string Course { get; set; } = "";
        public int Year { get; set; }
        public int EmployeeId { get; set; }
    }
}
