using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Choless.Core.Tools
{
    public static class TestDataLoader
    {
        public const string TestDatabasePath = "Choless.Data/TestData";

        public static IEnumerable<T> LoadData<T>()
        {
            Directory.SetCurrentDirectory("/Users/stark/Documents/Projects/Choless");
            var path = Path.Combine(TestDatabasePath, $"{typeof(T).Name.ToLower()}.json");
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
                throw new FileNotFoundException(
                    message: $"Test data file {fileInfo.Name} for not found in {fileInfo.DirectoryName}",
                    fileName: fileInfo.FullName);

            return JsonConvert.DeserializeObject<IEnumerable<T>>(File.ReadAllText(fileInfo.FullName));
        }

        public static void SaveData<T>(T obj)
        {
            Directory.SetCurrentDirectory("/Users/stark/Documents/Projects/Choless");
            var path = Path.Combine(TestDatabasePath, $"{typeof(T).Name.ToLower()}.json");
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
                throw new FileNotFoundException(
                    message: $"Test data file {fileInfo.Name} for not found in {fileInfo.DirectoryName}",
                    fileName: fileInfo.FullName);
            var json = JsonConvert.SerializeObject(obj);
        }

        public static void SaveData<T>(IEnumerable<T> collection)
        {
            foreach (var obj in collection)
            {
                Directory.SetCurrentDirectory("/Users/stark/Documents/Projects/Choless");
                var path = Path.Combine(TestDatabasePath, $"{typeof(T).Name.ToLower()}.json");
                var fileInfo = new FileInfo(path);
                if (!fileInfo.Exists)
                    throw new FileNotFoundException(
                        message: $"Test data file {fileInfo.Name} for not found in {fileInfo.DirectoryName}",
                        fileName: fileInfo.FullName);
                
            }
        }
    }
}