﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp8.Models;

namespace MauiApp8.Converters
{
    internal class WeatherConditionToImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            WeatherType weatherCondition = (WeatherType)value!;

            return weatherCondition switch
            {
                Models.WeatherType.Sunny => ImageSource.FromFile("sunny.png"),
                Models.WeatherType.Cloudy => ImageSource.FromFile("cloud.png"),
                _ => ImageSource.FromFile("question.png")
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
