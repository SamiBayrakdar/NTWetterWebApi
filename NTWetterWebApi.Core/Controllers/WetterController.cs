using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTWetterWebApi.Core.Models;
using NTWetterWebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTWetterWebApi.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WetterController : Controller

    {
        private readonly NTWetterContext _context;
        public WetterController(NTWetterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ApiResponse Get(String city)
        {
            var searchCity = city.ToUpper();

            {
                try
                {
                    WetterResponseViewModel model = new WetterResponseViewModel();   

                    var scity = _context.Wetters.FirstOrDefault(p => p.FindName == searchCity);

                    if (scity != null) {

                        City cmodel = new City();
                        cmodel.id = scity.Id;
                        cmodel.name = scity.Name;
                        cmodel.findname = scity.FindName;
                        cmodel.country = scity.Country;
                        cmodel.zoom = scity.Zoom;

                        Coord ccoord = new Coord();
                        ccoord.lat = Convert.ToDouble(scity.Lat);
                        ccoord.lon = Convert.ToDouble(scity.Lon);
                        cmodel.coord = ccoord;
                        model.city = cmodel;

                        Time ctime = new Time();
                        ctime.time = scity.Time;
                        model.time = ctime;


                        Main cmain = new Main();
                        cmain.temp = Convert.ToDouble(scity.Temp);
                        cmain.temp_min = Convert.ToDouble(scity.TempMin);
                        cmain.temp_max = Convert.ToDouble(scity.TempMax);
                        cmain.pressure = scity.Pressure;
                        cmain.humidity = scity.Humidity;
                        model.main = cmain;

                        Wind cwind = new Wind();
                        cwind.speed = Convert.ToDouble(scity.Speed);
                        cwind.deg = scity.Deg;
                        model.wind = cwind;

                        Clouds cclouds = new Clouds();
                        cclouds.all = scity.Call;
                        model.clouds = cclouds;



                        var sWeather = _context.WetterMappingWetterTypes.Where(c => c.WetterId == scity.Id).ToList();

                        List<Weather> weatherlist = new List<Weather>();

                        foreach (var item in sWeather)
                        {
                            var itemergebnis = _context.WetterTypes.FirstOrDefault(c => c.Id == item.WetterTypeId);
                            Weather mWeather = new Weather();

                            mWeather.id = itemergebnis.Id;
                            mWeather.main = itemergebnis.Main;
                            mWeather.description = itemergebnis.Description;
                            mWeather.icon = itemergebnis.Icon;

                            weatherlist.Add(mWeather);
                        }

                        model.weather = weatherlist;

                        return new ApiResponse { Code = 200, Message = "Success", Set = model };


                    }
                    else
                    {
                        return new ApiResponse { Code = 300, Message = "not fount", Set = model };

                    }

                   
                }
                catch (Exception exc)
                {
                    return new ApiResponse { Code = 500, Message = "Error", Set = exc };
                }

            }

        }

    }
}
