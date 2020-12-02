using System;
using System.Collections.Generic;

//Scaffold-DbContext "Name=RelationDB" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

namespace Services.Models
{
    public partial class Relation
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsTemporary { get; set; }
        public bool IsMe { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string DefaultStreet { get; set; }
        public string DefaultPostalCode { get; set; }
        public string DefaultCity { get; set; }
        public string DefaultCountry { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public bool PaymentViaAutomaticDebit { get; set; }
        public int InvoiceDateGenerationOptions { get; set; }
        public int InvoiceGroupByOptions { get; set; }
    }
}