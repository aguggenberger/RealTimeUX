using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RealTimeUX.Web.Models
{
    public class SubItem
    {
        [Key]
        public int subItemID { get; set;}

        [Required]
        public int taskId { get; set; }

        public string title { get; set; }

        public virtual Task Task { get; set; }
    }
}