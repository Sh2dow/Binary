using CoreExtensions.Native;
using CoreExtensions.Text;

using Nikki.Core;

using System;
using System.Windows;

namespace Binary.Tools
{
    public partial class Raider : Window
    {
        public Raider()
        {
            InitializeComponent();
            ToggleTheme();
        }

        private void ToggleTheme()
        {
            // Apply theme styling in WPF
            this.Background = Theme.GetBackgroundBrush();
            this.BinHashInput.Background = Theme.GetTextBoxBrush();
            this.BinFileInput.Background = Theme.GetTextBoxBrush();
            this.StringGuessed.Background = Theme.GetTextBoxBrush();
            this.CopyBinHash.Background = Theme.GetButtonBrush();
            this.CopyBinFile.Background = Theme.GetButtonBrush();
            this.CopyString.Background = Theme.GetButtonBrush();
        }

        private void ChooseSearchMode_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (ChooseSearchMode.SelectedIndex == 0)
            {
                BinHashInput.IsReadOnly = false;
                BinFileInput.IsReadOnly = true;
            }
            else
            {
                BinHashInput.IsReadOnly = true;
                BinFileInput.IsReadOnly = false;
            }
        }

        private void BinHashInput_TextChanged(object sender, RoutedEventArgs e)
        {
            string value = BinHashInput.Text.StartsWith("0x") ? BinHashInput.Text : $"0x{BinHashInput.Text}";
            if (!BinHashInput.IsReadOnly && value.IsHexString())
            {
                if (value.Length > 10)
                {
                    StringGuessed.Text = "N/A";
                    return;
                }

                uint key = Convert.ToUInt32(BinHashInput.Text, 16);
                BinFileInput.Text = $"0x{key.Reverse():X8}";

                StringGuessed.Text = Map.BinKeys.TryGetValue(key, out string result) ? result : "N/A";
            }
        }

        private void BinFileInput_TextChanged(object sender, RoutedEventArgs e)
        {
            string value = BinFileInput.Text.StartsWith("0x") ? BinFileInput.Text : $"0x{BinFileInput.Text}";
            if (!BinFileInput.IsReadOnly && value.IsHexString())
            {
                if (value.Length > 10)
                {
                    StringGuessed.Text = "N/A";
                    return;
                }

                uint key = Convert.ToUInt32(BinFileInput.Text, 16);
                key = key.Reverse();
                BinHashInput.Text = $"0x{key:X8}";

                StringGuessed.Text = Map.BinKeys.TryGetValue(key, out string result) ? result : "N/A";
            }
        }

        private void CopyBinHash_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(BinHashInput.Text))
            {
                Clipboard.SetText(BinHashInput.Text);
            }
        }

        private void CopyBinFile_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(BinFileInput.Text))
            {
                Clipboard.SetText(BinFileInput.Text);
            }
        }

        private void CopyString_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(StringGuessed.Text))
            {
                Clipboard.SetText(StringGuessed.Text);
            }
        }
    }
}
