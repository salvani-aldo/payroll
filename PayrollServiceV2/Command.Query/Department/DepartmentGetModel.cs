
using Command.Message.Interface;

namespace Command.Query.Department
{
    public class DepartmentGetModel : ICommand, IQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public DepartmentGetModel(int id, string name, string code)
        {
            (Id, Name, Code) = (id, name, code);
        }

        public DepartmentGetModel()
        { }
    }
}
