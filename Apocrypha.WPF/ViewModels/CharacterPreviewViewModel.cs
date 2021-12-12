using Apocrypha.CommonObject.Models;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace Apocrypha.WPF.ViewModels
{
    public class CharacterPreviewViewModel : BaseViewModel
    {
        private readonly Random _random;

        private Character _character;
        public Character Character
        {
            get { return _character; }
            set { _character = value; OnPropertyChanged(nameof(Character)); }
        }
        public Color? LeftColor { get; set; }
        public Color? RightColor { get; set; }
        public LinearGradientBrush Background
        {
            get
            {
                var output = new LinearGradientBrush()
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(1, 2)
                };
                output.GradientStops.Add(new GradientStop(LeftColor.Value, 0));
                output.GradientStops.Add(new GradientStop(RightColor ?? GetComplementaryColor(LeftColor.Value), 0.75));

                return output;
            }
        }

        public CharacterPreviewViewModel(Random random)
        {
            Random rn = new Random();

            int colorInt = rn.Next(0, 72);

            LeftColor = LeftColor ?? GetColorFromStandardColorsByInt(colorInt);
            RightColor = RightColor ?? GetComplementaryColor(LeftColor.Value);
        }

        private Color GetComplementaryColor(Color color)
        {
            //https://www.quora.com/Whats-the-algorithm-for-obtaining-a-hexadecimal-colors-opposite-in-the-color-wheel
            byte r = (byte)((color.R + 180) % 360),
                g = (byte)((color.G + 180) % 360),
                b = (byte)((color.B + 180) % 360);

            return Color.FromArgb(255, r, g, b);
        }

        private Color GetColorFromStandardColorsByInt(int colorInt)
        {
            Type type = typeof(Brushes);
            PropertyInfo[] colors = type.GetProperties();
            BrushConverter brushConverter = new BrushConverter();

            return (Color)ColorConverter.ConvertFromString((brushConverter.ConvertFromString(colors[colorInt].Name) as Brush).ToString());
        }
    }
}
