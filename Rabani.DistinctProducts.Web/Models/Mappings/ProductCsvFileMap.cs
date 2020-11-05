using CsvHelper.Configuration;
using Rabani.DistinctProducts.Web.Mappings.Models;
using System.Globalization;

namespace Rabani.DistinctProducts.Web.Models.Mappings
{
    public sealed class ProductCsvFileMap : ClassMap<ChangeIdProductModel>
    {
        public ProductCsvFileMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.OldProductId).Name(nameof(ChangeIdProductModel.OldProductId));
            Map(m => m.NewProductId).Name(nameof(ChangeIdProductModel.NewProductId));
        }
    }
}