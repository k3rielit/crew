using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC2JsonEditor {
    public static class Vehicles {
        public static readonly string[] ValidClasses = { "SR", "DF", "DR", "HC", "RR", "MX", "RX", "HT", "HO", "AB", "DD", "JS", "MT", "PC", "TC", "AR", "A" };
        public struct Classes {
            // Street Racing #ffe01e
            public const string StreetRacing = "SR";
            public const string Drift = "DF";
            public const string DragRacing = "DR";
            public const string HyperCar = "HC";
            // Offroad #fc8d21
            public const string RallyRaid = "RR";
            public const string MotoCross = "MX";
            public const string RallyCross = "RX";
            public const string HoverCraft = "HT";
            public const string Helicopter = "HO";
            // Freestyle #fc1965
            public const string AeroBatics = "AB";
            public const string DemolitionDerby = "DD";
            public const string JetSprint = "JS";
            public const string MonsterTruck = "MT";
            // Pro Racing #02d3fa
            public const string PowerBoat = "PB";
            public const string TouringCar = "TC";
            public const string AirRace = "AR";
            public const string AlphaGp = "A";
        }
    }
    
}
