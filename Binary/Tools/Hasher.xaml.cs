using CoreExtensions.Native;
using Nikki.Utils;
using System;
using System.Windows;

namespace Binary.Tools
{
    public partial class Hasher : Window
    {
        public Hasher()
        {
            InitializeComponent();
            ToggleTheme();
        }

        private void ToggleTheme()
        {
            // Set the theme colors in WPF
            this.Background = Theme.GetBackgroundBrush();
            this.StringTextbox.Background = Theme.GetTextBoxBrush();
            this.BinHashTextbox.Background = Theme.GetTextBoxBrush();
            this.BinFileTextbox.Background = Theme.GetTextBoxBrush();
            this.VltHashTextbox.Background = Theme.GetTextBoxBrush();
            this.VltFileTextbox.Background = Theme.GetTextBoxBrush();
        }

        private void StringTextbox_TextChanged(object sender, EventArgs e)
        {
            string str = this.StringTextbox.Text;
            string _0x = "0x";
            bool state = Hashing.PauseHashSave;
            Hashing.PauseHashSave = true;

            // Bin memory hash
            uint result = str.BinHash();
            this.BinHashTextbox.Text = $"{_0x}{result:X8}";

            // Bin file hash
            result = result.Reverse();
            this.BinFileTextbox.Text = $"{_0x}{result:X8}";

            // Vlt memory hash
            result = str.VltHash();
            this.VltHashTextbox.Text = $"{_0x}{result:X8}";

            // Vlt file hash
            result = result.Reverse();
            this.VltFileTextbox.Text = $"{_0x}{result:X8}";

            Hashing.PauseHashSave = state;
        }

        private void CopyString_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.StringTextbox.Text))
            {
                Clipboard.SetText(this.StringTextbox.Text);
            }
        }

        private void CopyBinHash_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.BinHashTextbox.Text))
            {
                Clipboard.SetText(this.BinHashTextbox.Text);
            }
        }

        private void CopyBinFile_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.BinFileTextbox.Text))
            {
                Clipboard.SetText(this.BinFileTextbox.Text);
            }
        }

        private void CopyVltHash_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.VltHashTextbox.Text))
            {
                Clipboard.SetText(this.VltHashTextbox.Text);
            }
        }

        private void CopyVltFile_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.VltFileTextbox.Text))
            {
                Clipboard.SetText(this.VltFileTextbox.Text);
            }
        }
    }
}
