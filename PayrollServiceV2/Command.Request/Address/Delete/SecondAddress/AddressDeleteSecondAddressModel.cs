

using Command.Message.Interface;

namespace Command.Request.Address.Delete.SecondAddress
{
    public class AddressDeleteSecondAddressModel : ICommand
    {
        public int EmployeeId { get; set; }
        public int FirstAddressId { get; set; }

        public AddressDeleteSecondAddressModel(int employeeId, int firstAddressId)
        {
            EmployeeId = employeeId;
            FirstAddressId = firstAddressId;
        }
    }
}
