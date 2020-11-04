using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Rabani.DistinctProducts.Web.Services
{
    public interface ICsvFileService
    {
        void CreateFile<T>(List<T> records, string fileName);
        IEnumerable<T> ReadFile<T, TMapProfile>(string fileName) where TMapProfile : ClassMap;
    }

    public class CsvFileService : ICsvFileService
    {
        private readonly string CSV_PATH;
        public CsvFileService(IWebHostEnvironment webHostEnvironment)
        {
            CSV_PATH = Path.Combine(webHostEnvironment.WebRootPath, "csv");
        }

        private void CheckCsvFolderToCreate(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public void CreateFile<T>(List<T> records, string fileName)
        {
            CheckCsvFolderToCreate(CSV_PATH);
            using var writer = new StreamWriter(Path.Combine(CSV_PATH, fileName));
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
        }
        
        public IEnumerable<T> ReadFile<T, TMapProfile>(string fileName) where TMapProfile : ClassMap
        {
            using var reader = new StreamReader(Path.Combine(CSV_PATH, fileName));
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.RegisterClassMap<TMapProfile>();
            return csv.GetRecords<T>();
        }
    }
}