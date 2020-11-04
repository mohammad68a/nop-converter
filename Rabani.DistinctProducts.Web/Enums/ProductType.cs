using System.ComponentModel.DataAnnotations;

namespace Rabani.DistinctProducts.Web.Enums
{
    /// <summary>
    /// Represents a product type
    /// </summary>
    public enum ProductType
    {
        [Display(Name = "ساده")]
        SimpleProduct = 5,

        [Display(Name = "گروهبندی")]
        GroupedProduct = 10,
    }
}