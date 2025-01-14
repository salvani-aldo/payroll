﻿using Command.Message.Interface;
using Command.Request._Base.Model;

namespace Command.Request.Address.Post.Model
{
    public class AddressPostQueryModel : BaseQueryModel, IQuery
    {
        public int Id { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int EmployeeId { get; set; }
    }
}
