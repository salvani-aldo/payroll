using Command.Message.Interface;
using System.ComponentModel.DataAnnotations;

namespace Command.Request.Handler.Employee.Post
{
    public sealed class EmployeePostModel : ICommand
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public int AddressId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }

        public EmployeePostModel(int id, string firstName, string middleName, string lastName, DateTime birthDate, int addressId, int departmentId, int positionId)
        {
            (Id, FirstName, MiddleName, LastName, BirthDate, AddressId, DepartmentId, PositionId) = (id, firstName, middleName, lastName, birthDate, addressId, departmentId, positionId);
        }
    }
}
