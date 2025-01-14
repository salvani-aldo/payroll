﻿using Command.Message.Interface;


namespace Command.Request.Education.Put
{
    public class EducationPutModel : ICommand, IQuery
    {
        public int Id { get; set; }
        public string School { get; set; } = "";
        public int DegreeId { get; set; }
        public int Year { get; set; }
        public int EmployeeId { get; set; }
        public string Course { get; set; } = "";
    }
}