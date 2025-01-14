namespace Command.Query._Base.Model
{
    public abstract class BaseModel
    {
        public DateTime Cteated { get; set; }
        public DateTime Updated { get; set; }
        public string CreatedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
    }
}
