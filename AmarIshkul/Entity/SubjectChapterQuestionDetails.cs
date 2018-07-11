using AmarIshkul.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.Entity
{
    public class SubjectChapterQuestionDetails
    {
        public int Id { get; set; }
        public virtual SubjectChapterQuestionSetup SubjectChapterQuestionSetup { get; set; }
        public int SubjectChapterQuestionSetupId { get; set; }

        public int QuestionNumber { get; set; }

        public string QuestionName { get; set; }
        public string AnswerName1 { get; set; }
        public bool IsAnswerName1 { get; set; }
        public string AnswerName2 { get; set; }
        public bool IsAnswerName2 { get; set; }
        public string AnswerName3 { get; set; }
        public bool IsAnswerName3 { get; set; }
        public string AnswerName4 { get; set; }
        public bool IsAnswerName4 { get; set; }

        public Answer Answer { get; set; }

    }
}