using System;
using System.Collections.Generic;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public partial class SurveyContributor
    {
        public Guid SurveyId { get; set; }
        public Guid UserId { get; set; }
        public Guid TenantId { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
