using Command.Message.Interface;

namespace Command.Query.Handler.Department.Get
{
    public class DepartmentGetModel : IQuery<DepartmentGetModel>
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public DepartmentGetModel(int id, string name, string code)
        {
            (Id, Name, Code) = (id, name, code);
        }

        public DepartmentGetModel()
        {

        }
    }
}
