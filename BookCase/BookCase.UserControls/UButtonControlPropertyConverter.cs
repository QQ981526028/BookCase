using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BookCase.UserControls
{
    public class UButtonControlPropertyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var button = value as UButtonControl;
            if (button != null && parameter != null)
            {
                switch (parameter.ToString())
                {
                    case "MouseOverBackground":
                        return button.MouseOverBackground.HasValue ? new SolidColorBrush(button.MouseOverBackground.Value) : button.Background;
                    case "MouseOverBorderBrush":
                        return button.MouseOverBorderBrush.HasValue ? new SolidColorBrush(button.MouseOverBorderBrush.Value) : button.BorderBrush;
                    case "MouseOverForeground":
                        return button.MouseOverForeground.HasValue ? new SolidColorBrush(button.MouseOverForeground.Value) : button.Foreground;
                    case "MouseOverThickness":
                        return button.MouseOverThickness.HasValue ? button.MouseOverThickness.Value : button.BorderThickness;

                    case "PressedBackground":
                        return button.PressedBackground.HasValue ? new SolidColorBrush(button.PressedBackground.Value) :
                           button.MouseOverBackground.HasValue ? new SolidColorBrush(button.MouseOverBackground.Value) : button.Background;
                    case "PressedBorderBrush":
                        return button.PressedBorderBrush.HasValue ? new SolidColorBrush(button.PressedBorderBrush.Value) :
                            button.MouseOverBorderBrush.HasValue ? new SolidColorBrush(button.MouseOverBorderBrush.Value) : button.BorderBrush;
                    case "PressedForeground":
                        return button.PressedForeground.HasValue ? new SolidColorBrush(button.PressedForeground.Value) :
                            button.MouseOverForeground.HasValue ? new SolidColorBrush(button.MouseOverForeground.Value) : button.Foreground;
                    case "PressedThickness":
                        return button.PressedThickness.HasValue ? button.PressedThickness.Value :
                            button.MouseOverThickness.HasValue ? button.MouseOverThickness.Value : button.BorderThickness;

                    case "DisabledBackground":
                        return button.DisabledBackground.HasValue ? new SolidColorBrush(button.DisabledBackground.Value) : button.Background;
                    case "DisabledBorderBrush":
                        return button.DisabledBorderBrush.HasValue ? new SolidColorBrush(button.DisabledBorderBrush.Value) : button.BorderBrush;
                    case "DisabledForeground":
                        return button.DisabledForeground.HasValue ? new SolidColorBrush(button.DisabledForeground.Value) : button.Foreground;
                    case "DisabledThickness":
                        return button.DisabledThickness.HasValue ? button.DisabledThickness.Value : button.BorderThickness;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
