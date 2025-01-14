using System.Windows.Input;

namespace Request.Command
{
    public class Class1
    {
        public Class1()
        {
            CreateEmployee createEmployee = new CreateEmployee();
            createEmployee.Id = 1;
            createEmployee.Name = "test";
            //IDispatcher dispatcher;
            //dispatcher.send<CreateEmployee>(createEmployee);

        }
    }

    public interface ICommand
    {

    }

    public class CreateEmployee : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    public interface IDispatcher
    {
        void send<T>(T command) where T : ICommand;
    }

    public class Dispatcher : IDispatcher
    {
        public void send<T>(T command) where T : ICommand
        {
            //command.handle(command);
            throw new NotImplementedException();
        }
    }

    public interface ICommandHandler<T> where T : ICommand
    {
        void handle(T command);
    }

    public class CreateCustomerHandler : ICommandHandler<CreateEmployee>
    {
        public void handle(CreateEmployee command)
        {
            //db connections / command to save 
            throw new NotImplementedException();
        }
    }
}