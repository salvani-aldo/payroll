using Command.Message.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Request.Handler.Department.Put
{
    public sealed class DepartmentPutModel : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public DepartmentPutModel(int id, string name, string code)
        {
            (Id, Name, Code) = (id, name, code);
        }
    }
}
