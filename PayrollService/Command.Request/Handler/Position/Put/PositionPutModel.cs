using Command.Message.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Command.Request.Handler.Position.Put
{
    public class PositionPutModel : ICommand
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public PositionPutModel(int id, string name, string code)
        {
            (Id, Name, Code) = (id, name, code);
        }
    }
}
