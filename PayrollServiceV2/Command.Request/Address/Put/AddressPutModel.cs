using Command.Message.Interface;

namespace Command.Request.Address.Put
{
    public class AddressPutModel : ICommand
    {
        public int Id { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int EmployeeId { get; set; }
    }
}
