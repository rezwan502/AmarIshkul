using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.ViewModel
{
    public class SubjectChapterQuestionSetupViewModel
    {
        public int Id { get; set; }
        public int ClasseId { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int SubjectChapterSetupId { get; set; }
        public int SubjectChapterWiseDetailsId { get; set; }

        public int NumberOfQuestion { get; set; }
        public float PerQuestionMark { get; set; }
        public float TotalMarks { get; set; }
        public float HighestMarks { get; set; }
    }
}