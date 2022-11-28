// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Tailspin.Surveys.Data.DataModels
{
    public class SurveyContributor
    {
        public Guid SurveyId { get; set; }
        public Guid UserId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }



        // Navigation properties
        public Survey Survey { get; set; }
        public User User { get; set; }
    }
}
