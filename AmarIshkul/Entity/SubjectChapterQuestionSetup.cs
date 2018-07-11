using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.Entity
{
    public class SubjectChapterQuestionSetup
    {
        public int Id { get; set; }
        public virtual SubjectChapterWiseDetails SubjectChapterWiseDetails { get; set; }
        public int SubjectChapterWiseDetailsId { get; set; }

        public int NumberOfQuestion { get; set; }
        public float PerQuestionMark { get; set; }
        public float TotalMarks { get; set; }
        public float HighestMarks { get; set; }
    }
}