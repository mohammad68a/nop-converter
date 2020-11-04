using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Rabani.DistinctProducts.Web.Mappings.Models;

namespace Rabani.DistinctProducts.Web.Mappings
{
    public class ProductOrderMap : ClassMap<ChangeIdProductModel>
    {
        public ProductOrderMap()
        {
            Map(x => x.OldProductId).Name(nameof(ChangeIdProductModel.OldProductId)).TypeConverter<Int32Converter>();
            Map(x => x.NewProductId).Name(nameof(ChangeIdProductModel.NewProductId)).TypeConverter<Int32Converter>();
        }
    }
}