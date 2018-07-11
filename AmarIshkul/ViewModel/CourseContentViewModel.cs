using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.ViewModel
{
    public class CourseContentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int CourseContentSetupId { get; set; }
    }
}