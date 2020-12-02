using System;
using System.Collections.Generic;

//Scaffold-DbContext "Name=RelationDB" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

namespace Services.Models
{
    public partial class RelationViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
    }
}