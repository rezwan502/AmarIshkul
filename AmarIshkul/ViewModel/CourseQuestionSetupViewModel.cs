using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.ViewModel
{
    public enum Answer
    {
        First,
        Second,
        Third,
        Fourth
    }
    public class CourseQuestionSetupViewModel
    {
        public CourseQuestionSetupViewModel()
        {
            CourseQuestionSetupLists = new List<CourseQuestionSetupList>();
        }

        public DateTime Date { get; set; }
        public DateTime DeadLineDate { get; set; }
        public DateTime ExamStartTime { get; set; }
        public DateTime ExamEndTime { get; set; }
        public int NumberOfQuestion { get; set; }
        public float Marks { get; set; }
        public float Points { get; set; }

        public int CourseContentSetupId { get; set; }
        public int CourseExamSetupId { get; set; }

        public List<CourseQuestionSetupList> CourseQuestionSetupLists { get; set; }
    }

    public class CourseQuestionSetupList
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

    }
}