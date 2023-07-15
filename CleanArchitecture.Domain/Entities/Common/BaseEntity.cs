using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Common
{
    /// <summary>
    /// Common fields for ID and logging purpose
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id{ get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
