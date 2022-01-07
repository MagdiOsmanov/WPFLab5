using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFLab5
{
    class WeatherControl: DependencyObject
    {
        private string wind;
        private int windSpeed;
        public enum Preciption
        {
            Sunny = 0,
            Cloudy = 1,
            Rain = 2,
            Snow = 4,

        }
        public static readonly DependencyProperty TempreatureProperty;
        public double Tempreature
        {
            get => (double)GetValue(TempreatureProperty);
            set => SetValue(TempreatureProperty, value);
        }
        public string Wind
        {
            get => wind;
            set => wind=value;
        }
        public int WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            {
                if (value>=0)
                {
                    windSpeed = value;
                }
                else
                {
                    windSpeed = 0;
                }
            }
        }
        static WeatherControl()
        {
            TempreatureProperty = DependencyProperty.Register(
                nameof(Tempreature),
                typeof(double),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTempreature)),
                new ValidateValueCallback(ValidateTempreature));
        }

        private static bool ValidateTempreature(object value)
        {
            double value1 = (double)value;
            double v = value1;
            if (v >= -50 && v <= 50)
            {
                return true;
            }
            else
                return false;
        }

        private static object CoerceTempreature(DependencyObject d, object baseValue)
        {
            double v =(double) baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
                return 0;
        }
    }
}
