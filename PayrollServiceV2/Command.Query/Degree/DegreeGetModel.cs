using Command.Message.Interface;

namespace Command.Query.Degree
{
    public class DegreeGetModel : IQuery
    {
        public int Id { get; set; }
        public string Degree { get; set; } = "";
        public string Code { get; set; } = "";
    }
}
