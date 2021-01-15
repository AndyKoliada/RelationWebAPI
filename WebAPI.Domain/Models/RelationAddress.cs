using System;
using WebAPI.Domain.Profiles;

namespace WebAPI.Domain.Models
{
    /// <summary>
    /// Represents fields in database table
    /// </summary>
    public partial class RelationAddress
    {
        public Guid RelationId { get; set; }
        public Guid AddressTypeId { get; set; } = new Guid(Constants.addressType);
        public string Street { get; set; }
        public int? Number { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public string CountryName { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual Country Country { get; set; }
        public virtual Relation Relation { get; set; }
    }
}
