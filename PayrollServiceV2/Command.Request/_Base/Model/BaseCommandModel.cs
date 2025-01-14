namespace Command.Request._Base.Model
{
    public abstract class BaseCommandModel
    {
        public string CreatedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
    }
}
