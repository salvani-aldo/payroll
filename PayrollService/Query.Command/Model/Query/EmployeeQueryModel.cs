using QueryRequest.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRequest.Command.Model.Query
{
    public class EmployeeQueryModel : IQuery<EmployeeQueryModel>
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public EmployeeQueryModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public EmployeeQueryModel()
        {
        }
    }
}
