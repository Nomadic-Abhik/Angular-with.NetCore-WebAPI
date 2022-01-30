using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Models
{
    public class ResultModel
    {
        public int? chapter_Id { get; set; }
        public string tittle { get; set; }
        public bool active { get; set; }
        public string departmentType { get; set; }
        public DateTime? publishedDatetime { get; set; }
         public string selCategory { get; set; }
        public List<CategoryModel> selectedCategory { get; set; }
       // public List<CategoryModel> allCategory { get; set; }

    }
}
