using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AmarIshkul.ViewModel.ViewModelTest;

namespace AmarIshkul.ViewModel
{
    public class SubjectChapterQuestionDetailsViewModel
    {
        public SubjectChapterQuestionDetailsViewModel()
        {
            SubjectChapterQuestionDetailsList = new List<SubjectChapterQuestionDetailsList>();
        }

        public int ClassId { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int SubjectChapterSetupId { get; set; }
        public int SubjectChapterWiseDetailsId { get; set; }

        public DateTime Date { get; set; }
        public int NumberOfQuestion { get; set; }
        public float Points { get; set; }


        public List<SubjectChapterQuestionDetailsList> SubjectChapterQuestionDetailsList { get; set; }
    }

    public class SubjectChapterQuestionDetailsList
    {
        public int Id { get; set; }
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

        public List<QuizAnswersVM> QuestionAnswerList { get; set; }

    }

    public class QuestionAnswerList
    {
        public string QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string AnswerQ { get; set; }
    }

}