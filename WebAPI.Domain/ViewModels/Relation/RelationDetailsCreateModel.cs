using System;
using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.Profiles;

namespace WebAPI.Domain.ViewModels.Relation
{   
    /// <summary>
    /// View model to create a new model.
    /// </summary>
    public class RelationDetailsCreateModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Name field with basic validation.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "";
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(10)]
        public string TelephoneNumber { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string Street { get; set; }
        [Range(0, 999)]
        public int? StreetNumber { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }

        //Initializing required fields
        private int InvoiceDateGenerationOptions { get; set; } = 1;
        private int InvoiceGroupByOptions { get; set; } = 1;
        private bool PaymentViaAutomaticDebit { get; set; } = false;
        private bool IsMe { get; set; } = false;
        private bool IsTemporary { get; set; } = false;
        private bool IsDisabled { get; set; } = false;
        private DateTime CreatedAt { get; set; } = DateTime.Now;
        private string CreatedBy { get; set; } = Constants.userName;

    }
}
