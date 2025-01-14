using Command.Message.Interface;

namespace Command.Request.Address.Delete.ByEMployee
{
    public class AddressDeleteModel : ICommand
    {
        public int EmployeeId { get; set; }

        public AddressDeleteModel(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
