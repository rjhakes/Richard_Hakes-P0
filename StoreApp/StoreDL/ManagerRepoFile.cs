using System.Collections.Generic;
using StoreModels;
using System.IO;
using System.Text.Json;
using System;
namespace StoreDL
{
    public class ManagerRepoFile : IManagerRepository
    {
        private string jsonString;
        private string filePath = "./StoreDL/ManagerFiles.json";
        public Manager AddManager(Manager newManager)
        {
            List<Manager> managersFromFile = GetManagers();
            managersFromFile.Add(newManager);
            jsonString = JsonSerializer.Serialize(managersFromFile);
            File.WriteAllText(filePath, jsonString);
            return newManager;
        }

        public List<Manager> GetManagers()
        {
            try {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception) {
                return new List<Manager>();
            }
            return JsonSerializer.Deserialize<List<Manager>>(jsonString);
        }
    }
}