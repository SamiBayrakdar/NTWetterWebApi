using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTWetterWebApi.Core.Models
{


//    {"city":{"id":2929670,"name":"Erfurt","findname":"ERFURT","country":"DE","coord":{"lon":11.03333,"lat":50.98333},"zoom":5},
//"time":1554462391,
//"main":{ "temp":281.16,"pressure":1005,"humidity":93,"temp_min":279.82,"temp_max":282.59},
//"wind":{ "speed":1.5,"deg":110},
//"clouds":{ "all":90},
//"weather":[{"id":701,"main":"Mist","description":"mist","icon":"50d"}]}
    public class WetterResponseViewModel
    {
        public City city { get; set; }
        public Time time  { get; set; }

        public Main main { get; set; }

        public Wind wind { get; set; }

        public Clouds clouds { get; set; }
        public List<Weather> weather { get; set; }
    }
}
