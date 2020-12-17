using System;
using WebAPI.Domain.Profiles;

namespace WebAPI.Domain.Models
{
    public partial class Relation
    {
        public int InvoiceDateGenerationOptions { get; set; } = 1;
        public int InvoiceGroupByOptions { get; set; } = 1;
        public bool PaymentViaAutomaticDebit { get; set; } = false;
        public bool IsMe { get; set; } = false;
        public bool IsTemporary { get; set; } = false;
        public bool IsDisabled { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = Constants.userName;
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string FullName { get; set; }
        public string DefaultStreet { get; set; }
        public string DefaultPostalCode { get; set; }
        public string DefaultCity { get; set; }
        public string DefaultCountry { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public virtual RelationAddress RelationAddress { get; set; }
        public virtual RelationCategory RelationCategory { get; set; }
    }
}
