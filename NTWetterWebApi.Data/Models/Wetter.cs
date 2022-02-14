using System;
using System.Collections.Generic;

#nullable disable

namespace NTWetterWebApi.Data.Models
{
    public partial class Wetter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FindName { get; set; }
        public string Country { get; set; }
        public decimal Lon { get; set; }
        public decimal Lat { get; set; }
        public int Zoom { get; set; }
        public int Time { get; set; }
        public decimal Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public decimal TempMin { get; set; }
        public decimal TempMax { get; set; }
        public decimal Speed { get; set; }
        public int Deg { get; set; }
        public int Call { get; set; }
    }
}
