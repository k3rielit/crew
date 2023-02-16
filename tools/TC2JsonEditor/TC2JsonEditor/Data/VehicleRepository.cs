using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TC2JsonEditor {
    public static class VehicleRepository {

        private const string JsonPath = @"vehicles.json";
        private const string GithubJsonPath = @"https://raw.githubusercontent.com/k3rielit/crew/main/data/vehicles.json";
        public static List<VehicleItem> Vehicles = new();

        public static void Load(string path = JsonPath) {
            if(!File.Exists(JsonPath)) return;
            try {
                Vehicles = JsonConvert.DeserializeObject<List<VehicleItem>>(File.ReadAllText(path), JsonHelper.Settings) ?? new();
            }
            catch(Exception ex) {
                MessageBox.Show($"Error at VehicleRepository.Load(): {ex.Message}", ex.GetType().ToString());
            }
        }

        public static void Save(string path = JsonPath) {
            try {
                File.WriteAllText(path, JsonConvert.SerializeObject(Vehicles, JsonHelper.Settings));
            }
            catch(Exception ex) {
                MessageBox.Show($"Error at VehicleRepository.Save(): {ex.Message}", ex.GetType().ToString());
            }
        }

        public static async Task Download(string url = GithubJsonPath) {
            try {
                using HttpClient client = new();
                string rawJson = await client.GetStringAsync(url);
                Vehicles = JsonConvert.DeserializeObject<List<VehicleItem>>(rawJson, JsonHelper.Settings) ?? new();
            }
            catch(Exception ex) {
                MessageBox.Show($"Error at VehicleRepository.Download(): {ex.Message}", ex.GetType().ToString());
            }
        }

        public static void Add(VehicleItem item) {
            foreach(VehicleItem existingItem in Vehicles) {
                if(existingItem.Matches(item)) return;
            }
            Vehicles.Add(item);
        }

        public static void Remove(VehicleItem item) {
            foreach(VehicleItem existingItem in Vehicles) {
                if(existingItem.Matches(item)) {
                    Vehicles.Remove(existingItem);
                    return;
                }
            }
        }

        public static void Remove(string vehicleString) {
            if(vehicleString == null) return;
            foreach(VehicleItem existingItem in Vehicles) {
                if(existingItem.ToString() == vehicleString) {
                    Vehicles.Remove(existingItem);
                    return;
                }
            }
        }
    }
}
