using Command.Message.Interface;

namespace Command.Query.Handler.Country
{
    public class CountryGetModel : IQuery<CountryGetModel>
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public CountryGetModel(int id, string name, string code)
        {
            (Id, Name, Code) = (id, name, code);
        }

        public CountryGetModel()
        {
        }
    }
}
