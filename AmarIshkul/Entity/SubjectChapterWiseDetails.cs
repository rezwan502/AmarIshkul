using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.Entity
{
    public class SubjectChapterWiseDetails
    {
        public int Id { get; set; }
        public virtual SubjectChapterSetup SubjectchapterSetup { get; set; }
        public int SubjectchapterSetupId { get; set; }
        public string Title { get; set; }
        public string UrlLink { get; set; }
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}