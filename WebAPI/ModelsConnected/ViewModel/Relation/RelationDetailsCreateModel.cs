using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ModelsConnected.ViewModel
{
    public class RelationDetailsCreateModel
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

        //Initializing required fields
        public int InvoiceDateGenerationOptions { get; set; } = 1;
        public int InvoiceGroupByOptions { get; set; } = 1;
        public bool PaymentViaAutomaticDebit { get; set; } = false;
        public bool IsMe { get; set; } = false;
        public bool IsTemporary { get; set; } = false;
        public bool IsDisabled { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Admin";

    }
}
