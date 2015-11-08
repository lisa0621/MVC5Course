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
        [StringLength(20)]
        public string ProductName { get; set; }

        [Required]
        [Range(1.0, 9999.9)]
        public decimal ProductPrice { get; set; }
    }
}