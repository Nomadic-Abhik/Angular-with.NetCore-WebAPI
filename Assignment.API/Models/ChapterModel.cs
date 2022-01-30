using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.API.Models
{
    public class ChapterModel
    {
        [Key]
        public int chapter_Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string tittle { get; set; }
        public bool active { get; set; }
        [Required]
        public DateTime creation_Time { get; set; }

        public System.Nullable<DateTime> lastmodificationTime { get; set; }

        public bool isDeleted { get; set; }

        public System.Nullable<DateTime> deletionTime { get; set; }
        public System.Nullable<DateTime> publishedDatetime { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string DepartmentType { get; set; }
    }
}
