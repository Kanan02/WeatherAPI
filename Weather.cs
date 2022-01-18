using System;
using System.Collections.Generic;
using System.Text;

namespace WeahterForecastData
{
    public class Weather
    {
        public Weather(float temp, float feelsLike, int pressure, int humidity)
        {
            Temp = temp;
            FeelsLike = feelsLike;
            Pressure = pressure;
            Humidity = humidity;
        }

        public Weather(float temp, float feelsLike, float tempMin, float tempMax, int pressure, int humidity)
        {
            Temp = temp;
            FeelsLike = feelsLike;
            TempMin = tempMin;
            TempMax = tempMax;
            Pressure = pressure;
            Humidity = humidity;
        }

        public float Temp { get; set; }
        public float FeelsLike { get; set; }
        public int Pressure { get; set; }//mbar
        public int Humidity { get; set; }//%
        public float? TempMin { get; set; } = null;
        public float? TempMax { get; set; } = null;

        public override string ToString()
        {
            if (TempMin!=null)
            {
                return $"Current temperature: {Temp}K\nFeels like: {FeelsLike}K\nMinimal: {TempMin}K\nMaximum: {TempMax}K\nPressure: {Pressure}mbar\nHumidity: {Humidity}%";

            }
            else
            {
                return $"Current temperature: {Temp}K\nFeels like: {FeelsLike}K\nPressure: {Pressure}mbar\nHumidity: {Humidity}%";
            }
        }

    }
}
