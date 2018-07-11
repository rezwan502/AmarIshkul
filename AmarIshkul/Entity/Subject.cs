using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AmarIshkul.Entity
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Class Class { get; set; }
        public int ClassId { get; set; }

        public virtual Group Group { get; set; }
        public int GroupId { get; set; }

        public int SerialNumber { get; set; }
        public bool IsActive { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }
        public string FileName { get; set; }

    }
}