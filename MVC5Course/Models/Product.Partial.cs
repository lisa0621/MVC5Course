namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    //[MetadataType(typeof(ProductMetaData))]
    //public partial class Product : IValidatableObject
    //{
    //    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        [AllowHtml]
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        //[限制欄位值必須出現兩個數字1Attribute]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }

        [UIHint("BooleanActive")]
        public Nullable<bool> Active { get; set; }
        [DisplayName("庫存數量")]
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
