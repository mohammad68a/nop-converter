namespace Rabani.DistinctProducts.Web.Models
{
    public class ProductToConfirm
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CsvFileName { get; set; }
        public string ProductPageUrl { get; set; }
    }
}