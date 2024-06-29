
using ContactManagement.Api.Models;
using System.Text.Json;

namespace ContactManagement.Api.WebApiHelpers
{
    public static class ContactJsonHelper
    {
        private static readonly string JsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "ContactDataJson.json");
        public static IList<ContactModel> ReadFromJsonFile()
        {
            string jsonString = File.ReadAllText(JsonFilePath);
            var contactlist = JsonSerializer.Deserialize<IList<ContactModel>>(jsonString);
            return contactlist;
        }



        public static void WriteToJsonFile(IList<ContactModel> Contact)
        {
            string fileName = JsonFilePath;
            string jsonString = JsonSerializer.Serialize(Contact);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
