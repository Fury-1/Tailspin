using System;
using System.Collections.Generic;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public partial class Survey
    {
        public Survey()
        {
            ContributorRequests = new HashSet<ContributorRequest>();
            Questions = new HashSet<Question>();
            SurveyContributors = new HashSet<SurveyContributor>();
        }

        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Title { get; set; }
        public Guid OwnerId { get; set; }
        public bool Published { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<ContributorRequest> ContributorRequests { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<SurveyContributor> SurveyContributors { get; set; }
    }
}
