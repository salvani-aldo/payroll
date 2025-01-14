using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.GenericRepository
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
