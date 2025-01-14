using Command.Message.Interface;

namespace Command.Query.Gender
{
    public class GenderGetModel : IQuery
    {
        public int Id { get; set; }
        public string Gender { get; set; } = "";
        public string Code { get; set; } = "";
    }
}
