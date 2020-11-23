using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class ViewRelation
    {
        public ViewRelation()
        {
            ViewRelationAddress = new HashSet<RelationAddress>();
            ViewRelationCategory = new HashSet<RelationCategory>();
        }

        //(Id, Name, CreatedAt, CreatedBy, IsDisabled, IsTemporary, IsMe, PaymentViaAutomaticDebit, InvoiceDateGenerationOptions, InvoiceGroupByOptions
        //TelephoneNumber	Email	Country	City	Street	PostalCode	StreetNumber

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsTemporary { get; set; }
        public bool IsMe { get; set; }

        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public string DefaultStreet { get; set; }
        public string DefaultPostalCode { get; set; }
        public string DefaultCity { get; set; }
        public string DefaultCountry { get; set; }

        public bool PaymentViaAutomaticDebit { get; set; }
        public int InvoiceGroupByOptions { get; set; }
        public int InvoiceDateGenerationOptions { get; set; }

        public virtual ICollection<RelationAddress> ViewRelationAddress { get; set; }
        public virtual ICollection<RelationCategory> ViewRelationCategory { get; set; }
    }
}
