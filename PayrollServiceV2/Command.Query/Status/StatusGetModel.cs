using Command.Message.Interface;

namespace Command.Query.Status
{
    public class StatusGetModel : IQuery
    {
        public int Id { get; set; }
        public string Status { get; set; } = "";
        public string Code { get; set; } = "";
    }
}
