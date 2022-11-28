// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

namespace Tailspin.Surveys.Data.DataModels
{
    public class ContributorRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid SurveyId { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public Guid TenantId { get;set; }

        public virtual Survey Survey { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    }
}
