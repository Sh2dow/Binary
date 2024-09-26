using System;
using System.Windows;
using System.Windows.Media;

namespace Binary.Tools
{
    public partial class Swatcher : Window
    {
        public Swatcher()
        {
            InitializeComponent();
            ToggleTheme();
        }

        #region Theme

        private void ToggleTheme()
        {
            this.Background = Theme.GetBackgroundBrush();
            this.GroupBoxRGB.Foreground = Theme.GetLabelTextBrush();
            this.GroupBoxSwatch.Foreground = Theme.GetLabelTextBrush();

            this.CopyBrightnessValue.Background = Theme.GetButtonBackgroundBrush();
            this.CopySaturationValue.Background = Theme.GetButtonBackgroundBrush();
            this.CopyPaintSwatchValue.Background = Theme.GetButtonBackgroundBrush();
        }

        #endregion

        private void RGBtoHSV(float red, float green, float blue)
        {
            float hue = 0; // PaintSwatch value
            float max = Math.Max(Math.Max(red, green), blue);
            float min = Math.Min(Math.Min(red, green), blue);
            float brightness = max;
            float saturation = max == 0 ? 0 : (max - min) / max;

            if (max != min)
            {
                if (max == red)
                {
                    hue = (green - blue) / (max - min);
                }
                else if (max == green)
                {
                    hue = 2f + (blue - red) / (max - min);
                }
                else
                {
                    hue = 4f + (red - green) / (max - min);
                }

                hue = hue * 60f;
                if (hue < 0)
                {
                    hue += 360f;
                }
            }

            TextBoxPaintSwatch.Text = hue.ToString("F0");
            TextBoxSaturation.Text = saturation.ToString("F2");
            TextBoxBrightness.Text = brightness.ToString("F2");
        }

        private void TrackBar_Red_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRGB();
        }

        private void TrackBar_Green_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRGB();
        }

        private void TrackBar_Blue_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRGB();
        }

        private void UpdateRGB()
        {
            float red = (float)TrackBar_Red.Value / 255;
            float green = (float)TrackBar_Green.Value / 255;
            float blue = (float)TrackBar_Blue.Value / 255;
            RGBtoHSV(red, green, blue);
        }

        private void CopyPaintSwatchValue_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TextBoxPaintSwatch.Text);
        }

        private void CopySaturationValue_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TextBoxSaturation.Text);
        }

        private void CopyBrightnessValue_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TextBoxBrightness.Text);
        }
    }
}
