using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TC2JsonEditor {
    public class VehicleItem {
        public string Brand { get; set; } = "?";
        public string Model { get; set; } = "?";
        public int Year { get; set; } = 1970;
        public string VehicleClass { get; set; } = "-";
        public int[] Tune { get; set; } = new int[14];

        public VehicleItem(string brand, string model, int year, string vehicleClass, int[] tune) {
            Brand = brand;
            Model = model;
            Year = year;
            VehicleClass = Vehicles.ValidClasses.Contains(vehicleClass) ? vehicleClass : "-";
            if(tune.Length == 14) Tune = tune;
        }

        public VehicleItem() { }

        public override string ToString() => $"{VehicleClass};{Brand};{Model};{Year}-{string.Join(';',Tune)}";
        public bool Matches(VehicleItem item) => item.ToString() == this.ToString();
    }
}
