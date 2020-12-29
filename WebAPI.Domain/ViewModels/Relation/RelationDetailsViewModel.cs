
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.ViewModels.Relation
{
    /// <summary>
    /// View model to view model.
    /// </summary>
    public class RelationDetailsViewModel
    {
        public Guid Id { get; set; }
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
