
using Command.Message.Interface;

namespace Command.Query.Certification.Model
{
    public class CertificationGetCommandModel : ICommand
    {
        public int EmployeeId { get; set; }
    }
}
