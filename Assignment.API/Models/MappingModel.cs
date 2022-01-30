using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.API.Models
{
    public class MappingModel
    {
        [Key]
        public int map_Id { get; set; }
        [Required]
        public int categoryId { get; set; }
        [Required]
        public int chapter_Id { get; set; }
        [Required]
        public DateTime creationTime { get; set; }

        public System.Nullable<int> creatorUserId { get; set; }
    }
}
