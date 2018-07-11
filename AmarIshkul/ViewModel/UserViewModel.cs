using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmarIshkul.ViewModel
{
    //
    public class UserViewModel
    {
        public UserViewModel()
        {
            BookViewModel = new List<BookViewModel>();
        }
        public int TotalClassForBookViewModel { get; set; }
        public List<BookViewModel> BookViewModel { get; set; }
    }


    public class BookViewModel
    {
        public BookViewModel()
        {
            SubjectLists = new List<SubjectList>();
        }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public List<SubjectList> SubjectLists { get; set; }
    }


    public class SubjectList
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string FileName { get; set; }
    }
}