using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.Entity
{
    public class SubjectChapterSetup
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}