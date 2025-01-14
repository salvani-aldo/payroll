namespace Command.Request._Base.Model
{
    public class BaseQueryModel
    {
        public DateTime Cteated { get; set; }
        public DateTime Updated { get; set; }
        public string CreatedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
    }
}
