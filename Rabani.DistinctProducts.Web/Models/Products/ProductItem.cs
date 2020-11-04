using System.ComponentModel.DataAnnotations;

namespace Rabani.DistinctProducts.Web.Models.Products
{
    public class ProductItem
    {
        public int Id { get; set; }

        [Display(Name = "تصویر محصول")]
        public string ImageBase64 { get; set; }

        [Display(Name = "نام محصول")]
        public string ProductName { get; set; }

        [Display(Name = "کد محصول")]
        public string ProductCode { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Price { get; set; }

        [Display(Name = "موجودی")]
        public float Stock { get; set; }

        [Display(Name = "نوع تعداد")]
        public string QuantityType { get; set; }

        [Display(Name = "نوع محصول")]
        public string TypeName { get; set; }

        [Display(Name = "انتشار")]
        public bool IsPublish { get; set; }
    }
}
