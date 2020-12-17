using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.ViewModels.Relation
{
    /// <summary>
    /// View model to update model.
    /// </summary>
    public class RelationDetailsEditModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Name field with basic validation.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public string FullName { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? StreetNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
