using Command.Message;
using Command.Message.Interface;
using Command.Query.Address;
using Command.Query.Country;
using Command.Query.Degree;
using Command.Query.Department;
using Command.Query.Education;
using Command.Query.Employee;
using Command.Query.Gender;
using Command.Query.Position;
using Command.Query.State;
using Command.Query.Status;
using Command.Query.User.GetById;
using Command.Query.User.GetById.Model;
using Command.Request.Address.Delete.ByEMployee;
using Command.Request.Address.Delete.SecondAddress;
using Command.Request.Address.Post;
using Command.Request.Address.Post.Model;
using Command.Request.Address.Put;
using Command.Request.Department.Delete.ByEmployee;
using Command.Request.Department.Post;
using Command.Request.Department.Post.Model;
using Command.Request.Department.Put;
using Command.Request.Department.Put.Model;
using Command.Request.Education.Delete.ByEmployoeeId;
using Command.Request.Education.Delete.NonExistingId;
using Command.Request.Education.Post;
using Command.Request.Education.Post.Model;
using Command.Request.Education.Put;
using Command.Request.Emplooyee.Delete;
using Command.Request.Emplooyee.Post;
using Command.Request.Emplooyee.Post.Model;
using Command.Request.Emplooyee.Put;
using Command.Request.Position.Delete;
using Command.Request.Position.Post;
using Command.Request.Position.Post.Model;
using Command.Request.Position.Put;
using Command.Request.Position.Put.Model;
using Scrutor;
using System.Reflection;

namespace PayrollServiceV2.CommandRegistration
{
    public static class HandlerRegistration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //SCRUTOR
            var bl = Assembly.Load("Service.BL");
            var command = Assembly.Load("Command.Request");
            var query = Assembly.Load("Command.Query");
            var result = services.Scan(scan => scan.FromAssemblies(bl)
                .AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime()
                .FromAssemblyOf<Message>().AddClasses().AsSelf().WithScopedLifetime()
                .FromAssemblies(command)
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses().AsMatchingInterface()
                .FromAssemblies(query)
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses().AsMatchingInterface()
                );

            //services.AddScoped<Message>();
            //services.AddScoped<ICommandHandler<UserGetByNameCommandModel, UserGetByNameQueryModel>, UserGetByNameHandler>();
            //services.AddScoped<ICommandHandler<AddressDeleteSecondAddressModel>, AddressDeleteSecondAddressHandler>();
            //services.AddScoped<ICommandHandler<AddressGetModel, AddressGetModel>, AddressGetHandler>();
            //services.AddScoped<ICommandHandler<AddressDeleteModel>, AddressDeleteHandler>();
            //services.AddScoped<ICommandHandler<AddressPutModel>, AddressPutHandler>();
            //services.AddScoped<ICommandHandler<AddressPostCommandModel, AddressPostQueryModel>, AddressPostHandler>();
            //services.AddScoped<ICommandHandler<EmployeePutModel, EmployeePutModel>, EmployeePutHandler>();
            //services.AddScoped<ICommandHandler<EmployeeDeleteModel, EmployeeDeleteModel>, EmployeeDeleteHandler>();
            //services.AddScoped<ICommandHandler<EmployeeGetModel, EmployeeGetModel>, EmployeeGetHandler>();
            //services.AddScoped<ICommandHandler<EmployeePostCommandModel, EmployeePostQueryModel>, EmployeePostHandler>();
            //services.AddScoped<ICommandHandler<DepartmentPutCommandModel, DepartmentPutQueryModel>, DepartmentPutHandler>();
            //services.AddScoped<ICommandHandler<DepartmentDeleteModel, DepartmentDeleteModel>, DepartmentDeleteHandler>();
            //services.AddScoped<ICommandHandler<DepartmentGetModel, DepartmentGetModel>, DepartmentGetHandler>();
            //services.AddScoped<ICommandHandler<DepartmentPostCommandModel, DepartmentPostQueryModel>, DepartmentPostHandler>();
            //services.AddScoped<ICommandHandler<CountryGetModel, CountryGetModel>, CountryGetHandler>();
            //services.AddScoped<ICommandHandler<PositionDeleteModel, PositionDeleteModel>, PositionDeleteHandler>();
            //services.AddScoped<ICommandHandler<PositionPutCommandModel, PositionPutRequestModel>, PositionPutHandler>();
            //services.AddScoped<ICommandHandler<PositionPostCommandModel, PositionPostRequestModel>, PositionPostHandler>();
            //services.AddScoped<ICommandHandler<StateGetModel, StateGetModel>, StateGetHandler>();
            //services.AddScoped<ICommandHandler<EducationPostCommandModel, EducationPostQueryModel>, EducationPostHandler>();
            //services.AddScoped<ICommandHandler<EducationPutModel, EducationPutModel>, EducationPutHandler>();
            //services.AddScoped<ICommandHandler<EducationDeleteByNonExistingIdModel>, EducationDeleteByNonExistingIdHandler>();
            //services.AddScoped<ICommandHandler<EducationDeleteByEmployeeIdModel, EducationDeleteByEmployeeIdModel>, EducationDeleteByEmployeeIdHandler>();
            //services.AddScoped<IQueryHandler<PositionGetModel>, PositionGetHandler>();
            //services.AddScoped<IQueryHandler<GenderGetModel>, GenderGetHandler>();
            //services.AddScoped<IQueryHandler<StatusGetModel>, StatusGetHandler>();
            //services.AddScoped<IQueryHandler<DegreeGetModel>, DegreeGetHandler>();
            //services.AddScoped<IQueryHandler<EducationGetModel>, EducationGetHandler>();

        }
    }
}
