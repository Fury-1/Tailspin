using System;
using System.Collections.Generic;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            Surveys = new HashSet<Survey>();
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string IssuerValue { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
