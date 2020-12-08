using System;
using System.Collections.Generic;

namespace WebAPI.ViewModel.RelationAddress
{
    public partial class RelationAddressViewModel
    {
        public Guid RelationId { get; set; }
        public Guid AddressTypeId { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string NumberSuffix { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Building { get; set; }
        public string PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public string CountryName { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        //public virtual AddressType AddressType { get; set; }
        //public virtual Country Country { get; set; }
        //public virtual Relation Relation { get; set; }
    }
}
