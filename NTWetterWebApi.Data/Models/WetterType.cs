using System;
using System.Collections.Generic;

#nullable disable

namespace NTWetterWebApi.Data.Models
{
    public partial class WetterType
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
