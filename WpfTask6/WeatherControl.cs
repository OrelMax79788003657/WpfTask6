using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTask6
{
    public class WeatherControl: DependencyObject
    {
        //propdp + tab
        public int temperature
        {
            get
            {
                return (int)GetValue(temperatureProperty);
            }
            set
            {
                if (-50 <= value && value <= 50)
                {
                    SetValue(temperatureProperty, value);
                }
            }
        }

        private static void temperatureChanged(DependencyObject e, DependencyPropertyChangedEventArgs args)
        {

        }
        private static object temperatureCoerce(DependencyObject d, object value)
        {
            int v = (int)value;
            return v;
        }
        //private static bool temperatureValidate(object value)
        //{
        //    int v = (int)value;
        //    if (v!=null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public static readonly DependencyProperty temperatureProperty =
            DependencyProperty.Register(
                nameof(temperature),  // string "temperature"
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(temperatureChanged),
                    new CoerceValueCallback(temperatureCoerce)//,
                                                              //new ValidateValueCallback(temperatureValidate)
                )
            );

        public string windDirection { get; set; }
        public int windSpeed { get; set; }
        public int precipValue { get; set; }
        public string[] daysSummary { get; set; }

        private string[] precips = { "Sunny", "Cloudy", "Rain", "Snow" };
        private string[] wDirs = { "W", "SW", "S", "SE", "E", "NE", "N", "NW" };

        public WeatherControl(int days)
        {
            Random r = new Random();

            temperature = r.Next(-50, 50);
            windDirection = wDirs[r.Next(0, 8)];
            windSpeed = r.Next(0, 30);
            precipValue = r.Next(0, 4);

            daysSummary = new string[days];
        }

        public void Modulation()
        {
            Random r = new Random();

            for (int i = 0; i < daysSummary.Length; i++)
            {
                temperature += r.Next(-5, 5);
                if (temperature < -50) temperature = -50;
                if (temperature > 50) temperature = 50;

                int windIndex = Array.IndexOf(wDirs, windDirection) + r.Next(-1, 2);
                if (windIndex < 0) windIndex = 7;
                if (windIndex > 7) windIndex = 0;
                windDirection = wDirs[windIndex];

                windSpeed = r.Next(0, 30);

                //{ "Sunny", "Cloudy", "Rain", "Snow" };
                if (r.Next(0, 2) == 0)
                {
                    precipValue = 0;
                }
                else
                {
                    precipValue = 1;
                }

                if (temperature < 0)
                {
                    if (r.Next(0, 2) == 0)
                    {
                        precipValue = 3;
                    }
                }
                if (temperature > 0)
                {
                    if (r.Next(0, 2) == 0)
                    {
                        precipValue = 2;
                    }
                }

                daysSummary[i] = $"Day #{i}:\nT: {temperature}\nWind: {windDirection}\nSpeed: {windSpeed}\nPrecipitation: {precips[precipValue]}";
            }
        }
    }
}
