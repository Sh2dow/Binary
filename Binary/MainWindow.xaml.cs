using System.Windows;

namespace Binary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event Handlers
        private void IntroPictureUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User Image Clicked!");
        }

        private void PictureBoxDiscord_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Opening Discord...");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://discord.com",
                UseShellExecute = true
            });
        }

        private void PictureBoxDocs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Opening Documentation...");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://yourdocslink.com",
                UseShellExecute = true
            });
        }

        private void PictureBoxGitHub_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Opening GitHub...");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com",
                UseShellExecute = true
            });
        }
    }
}
