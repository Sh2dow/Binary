using System.Windows;

namespace Binary.Prompt
{
    public partial class Combo : Window
    {
        public int Value { get; private set; } = 0;

        public Combo()
        {
            InitializeComponent();
            ToggleTheme();
        }

        public Combo(string[] options, string desc, bool prompt) : this()
        {
            ComboButtonCancel.IsEnabled = !prompt;
            DescriptionLabel.Content = desc ?? string.Empty;

            if (options != null)
            {
                ComboBoxSelection.ItemsSource = options;
                ComboBoxSelection.SelectedIndex = 0;
            }
        }

        private void ToggleTheme()
        {
            // Example theme management using WPF style resources or programmatic color assignments
            ComboButtonOK.Background = Theme.GetButtonBackground();
            ComboButtonOK.Foreground = Theme.GetButtonForeground();
            ComboButtonCancel.Background = Theme.GetButtonBackground();
            ComboButtonCancel.Foreground = Theme.GetButtonForeground();
            ComboBoxSelection.Background = Theme.GetComboBoxBackground();
            ComboBoxSelection.Foreground = Theme.GetComboBoxForeground();
            DescriptionLabel.Foreground = Theme.GetLabelForeground();
        }

        private void ComboButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Value = ComboBoxSelection.SelectedIndex;
            Close();
        }

        private void ComboButtonCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
