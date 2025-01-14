using Command.Message.Interface;


namespace Command.Request.Education.Delete.NonExistingId
{
    public class EducationDeleteByNonExistingIdModel : ICommand, IQuery
    {
        public IEnumerable<int> Ids { get; set; } = new List<int>();
    }
}
