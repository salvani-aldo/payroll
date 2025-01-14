using Command.Message.Interface;
using Command.Request.Handler.Department.Delete;
using Command.Request.Handler.Department.Post;
using Command.Request.Handler.Department.Put;
using Command.Request.Handler.Employee.Delete;
using Command.Request.Handler.Employee.Post;
using Command.Request.Handler.Employee.Put;
using Command.Request.Handler.Position.Delete;
using Command.Request.Handler.Position.Post;
using Command.Request.Handler.Position.Put;

namespace PayrollService.Utility
{
    public static partial class HandlerRegistration
    {
        public static void AddRequestHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<DepartmentPostModel>, DepartmentPostHandler>();
            services.AddTransient<ICommandHandler<DepartmentPutModel>, DepartmentPutHandler>();
            services.AddTransient<ICommandHandler<DepartmentDeleteModel>, DepartmentDeleteHandler>();
            services.AddTransient<ICommandHandler<PositionPostModel>, PositionPostHandler>();
            services.AddTransient<ICommandHandler<PositionPutModel>, PositionPutHandler>();
            services.AddTransient<ICommandHandler<PositionDeleteModel>, PositionDeleteHandler>();
            services.AddTransient<ICommandHandler<EmployeePostModel>, EmployeePostHandler>();
            services.AddTransient<ICommandHandler<EmployeePutModel>, EmployeePutHandler>();
            services.AddTransient<ICommandHandler<EmployeeDeleteModel>, EmployeeDeleteHandler>();
        }
    }
}
