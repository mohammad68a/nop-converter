using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Rabani.DistinctProducts.Web.Services
{
    public interface ICsvFileService
    {
        void CreateFile<T>(List<T> records, string fileName);
        List<T> ReadFile<T, TMapProfile>(string fileName) where TMapProfile : ClassMap;
        string[] GetFileNamesInPath();
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
        
        public List<T> ReadFile<T, TMapProfile>(string fileName) where TMapProfile : ClassMap
        {
            var result = new List<T>();
            using (var reader = new StreamReader(Path.Combine(CSV_PATH, fileName)))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<TMapProfile>();
                    result = csv.GetRecords<T>().ToList();
                }
            }
            return result;
        }

        public string[] GetFileNamesInPath()
        {
            CheckCsvFolderToCreate(CSV_PATH);
            var result = new List<string>();
            foreach (var file in Directory.GetFiles(CSV_PATH, "*.csv"))
                result.Add(Path.GetFileName(file));
            return result.ToArray();
        }
    }
}