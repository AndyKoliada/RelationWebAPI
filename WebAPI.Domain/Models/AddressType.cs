using System;
using System.Collections.Generic;

namespace WebAPI.Domain.Models
{
    public partial class AddressType
    {
        public AddressType()
        {
            RelationAddress = new HashSet<RelationAddress>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDisabled { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RelationAddress> RelationAddress { get; set; }
    }
}
