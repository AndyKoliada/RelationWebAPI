using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class RelationCategory
    {
        public Guid RelationId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
