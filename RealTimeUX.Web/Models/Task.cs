using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealTimeUX.Web.Models
{
    public class Task
    {
        [Key]
        public int taskId { get; set; }

        [Required]
        public int categoryID { get; set; }

        //[Required] [MaxLength(140)] [MinLength(10)]
        public string title { get; set; }
        public bool completed { get; set; }
        public DateTime lastUpdated { get; set; }

        public virtual Category Category { get; set; }
        //public virtual ICollection<SubItem> Subitems { get; set; }
    }
}