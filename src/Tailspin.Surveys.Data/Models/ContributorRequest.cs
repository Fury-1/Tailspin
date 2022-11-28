using System;
using System.Collections.Generic;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public partial class ContributorRequest
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Created { get; set; }
        public Guid TenantId { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
