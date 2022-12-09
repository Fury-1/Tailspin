// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;
using Tailspin.Surveys.Data.DataModels;

namespace Tailspin.Surveys.Data.DTOs
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string Text { get; set; }

        public QuestionType Type { get; set; }

        [Display(Name = "Answer Choices")]
        public string PossibleAnswers { get; set; }
        public Guid SurveyId { get; set; }

    }
}
