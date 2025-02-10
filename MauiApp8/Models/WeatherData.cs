using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp8.Models
{
    public readonly record struct WeatherData(int Temperature,
                                           int Precipitation,
                                           int Humidity,
                                           int Wind,
                                           WeatherType Condition);
}
