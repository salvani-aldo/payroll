using Command.Message.Interface;

namespace Command.Query.Address
{
    public class AddressGetModel : ICommand, IQuery
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
    }
}
