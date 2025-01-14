using Command.Message.Interface;

namespace Command.Query.Certification.Model
{
    public class CertificationGetQueryModel : IQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Organization { get; set; } = "";
        public DateOnly IssueDate { get; set; }
        public DateOnly Expiration { get; set; }
        public string Url { get; set; } = "";
        public int EmployeeId { get; set; }
    }
}
