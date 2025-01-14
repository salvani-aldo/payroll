//using AutoMapper;
//using Command.Query.Address;
//using Command.Query.Employee;
//using Command.Request.Address.Post.Model;
//using Command.Request.Address.Put;
//using Command.Request.Education.Post;
//using Command.Request.Education.Put;
//using Command.Request.Emplooyee.Post.Model;
//using Command.Request.Emplooyee.Put;
//using Service.BL.Employee.Model;

//namespace Utility
//{
//    public class AutoMapperProfile : Profile
//    {
//        public AutoMapperProfile()
//        {
//            CreateMap<EmployeeGetModel, EmployeeQueryModel>().ReverseMap();
//            CreateMap<EmployeePutModel, EmployeePutCommandModel>().ReverseMap();
//            CreateMap<EmployeePostCommandModel, EmployeePostCommandModel>().ReverseMap();
//            CreateMap<AddressGetModel, AddressPostQueryModel>().ReverseMap();
//            CreateMap<AddressPostCommandModel, AddressPutModel>().ReverseMap();
//            CreateMap<EducationPostCommandModel, EducationPutModel>().ReverseMap();

//        }
//    }
//}
