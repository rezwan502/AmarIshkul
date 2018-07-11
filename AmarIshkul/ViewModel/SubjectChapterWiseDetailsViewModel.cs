using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.ViewModel
{
    public class SubjectChapterWiseDetailsViewModel
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int SubjectChapterSetupId { get; set; }

        public string Title { get; set; }
        public string UrlLink { get; set; }
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}