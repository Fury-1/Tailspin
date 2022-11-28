using System;
using System.Collections.Generic;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public enum QuestionType
    {
        SimpleText,
        MultipleChoice,
        FiveStars
    }

    public partial class Question
    {
        public Question()
        {
            this.Type = QuestionType.SimpleText;
        }


        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid SurveyId { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public string PossibleAnswers { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
