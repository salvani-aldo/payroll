using Command.Message.Interface;
using Command.Query.Handler.Country;
using Command.Query.Handler.Department.Get;
using Command.Query.Handler.Employee.Get;
using Command.Query.Handler.Position.Get;
using Command.Query.Handler.State;

namespace PayrollService.Utility
{
    public static partial class HandlerRegistration
    {
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<EmployeeGetModel, EmployeeGetModel>, EmployeeGetHandler>();
            services.AddTransient<IQueryHandler<DepartmentGetModel, DepartmentGetModel>, DepartmentGetHandler>();
            services.AddTransient<IQueryHandler<PositionGetModel, PositionGetModel>, PositionGetHandler>();
            services.AddTransient<IQueryHandler<CountryGetModel, CountryGetModel>, CountryGetHandler>();
            services.AddTransient<IQueryHandler<StateGetModel, StateGetModel>, StateGetHandler>();
        }
    }
}
