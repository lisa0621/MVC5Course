using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class NewProductVM
    {
        [Required]
        [StringLength(10)]
        public string ProductName { get; set; }

        [Required]
        [Range(1.0, 9999.9)]
        public Nullable<decimal> Price { get; set; }
    }
}