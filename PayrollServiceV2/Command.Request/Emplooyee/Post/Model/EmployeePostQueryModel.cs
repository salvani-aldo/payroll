using Command.Message.Interface;

namespace Command.Request.Emplooyee.Post.Model
{
    public class EmployeePostQueryModel : IQuery
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int GenderId { get; set; }
        public int StatusId { get; set; }
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}
