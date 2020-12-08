using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Models
{
    public partial class RelationCategory
    {
        public Guid RelationId { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Relation Relation { get; set; }
    }
}
