// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tailspin.Surveys.Data.DTOs
{
    public class SurveyDTO
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        public bool Published{ get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }

        [Display(Name = "Existing Title")]
        public string ExistingTitle { get; set; }

    }
}
