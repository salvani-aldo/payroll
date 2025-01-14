using Command.Message.Interface;

namespace Command.Query.Country
{
    public class CountryGetModel : ICommand, IQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
    }
}
