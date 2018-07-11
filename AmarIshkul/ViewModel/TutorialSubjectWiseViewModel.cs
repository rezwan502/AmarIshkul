using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.ViewModel
{
    public class TutorialSubjectWiseViewModel
    {
        public TutorialSubjectWiseViewModel()
        {
            ChapterContentList = new List<ChapterContentList>();
        }
        public string SubjectName { get; set; }
        public int ChapterId { get; set; }
        public string ChapterName { get; set; }
        public List<ChapterContentList> ChapterContentList { get; set; }
    }
    public class ChapterContentList
    {
        public int ChapterContentId { get; set; }
        public string ChapterContentTitle { get; set; }

        public string UrlLink { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }


    }
}