using System;
using System.Collections.Generic;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string ObjectId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTime Created { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
