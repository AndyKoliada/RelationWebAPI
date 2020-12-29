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
    }
}
