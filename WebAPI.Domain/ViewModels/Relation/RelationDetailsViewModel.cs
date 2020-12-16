
using System;

namespace WebAPI.Domain.ViewModels.Relation
{
    public class RelationDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? StreetNumber { get; set; }
        public string PostalCode { get; set; }

        //public RelationAddressViewModel RelationAddressViewModel { get; set; }
    }
}
