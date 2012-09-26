using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RealTimeUX.Web.Models
{
    public class Category
    {
        [Key]
        public int categoryID { get; set; }

        public string title { get; set; }
    }
}
