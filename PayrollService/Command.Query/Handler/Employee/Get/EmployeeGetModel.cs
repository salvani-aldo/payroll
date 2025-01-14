using Command.Message.Interface;

namespace Command.Query.Handler.Employee.Get
{
    public class EmployeeGetModel : IQuery<EmployeeGetModel>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public int AddressId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }

        public EmployeeGetModel(int id, string firstName, string middleName, string lastName)
        {
            (Id, FirstName, MiddleName, LastName) = (id, firstName, middleName, lastName);
        }

        public EmployeeGetModel()
        {
        }
    }
}
