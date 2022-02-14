using System;
using System.Collections.Generic;

#nullable disable

namespace NTWetterWebApi.Data.Models
{
    public partial class WetterMappingWetterType
    {
        public int Id { get; set; }
        public int WetterId { get; set; }
        public int WetterTypeId { get; set; }
    }
}
