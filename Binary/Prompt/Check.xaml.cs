using System.Windows;

namespace Binary.Prompt
{
    public partial class Check : Window
    {
        public bool Value { get; private set; } = false;

        public Check()
        {
            InitializeComponent();
            ToggleTheme();
        }

        public Check(string desc, bool prompt) : this(desc, prompt, false) { }

        public Check(string desc, bool prompt, bool initiallyChecked) : this()
        {
            CheckButtonCancel.IsEnabled = !prompt;
            CheckBoxSelection.Content = desc ?? string.Empty;
            CheckBoxSelection.IsChecked = initiallyChecked;
        }

        public Check(string desc, string promptName, bool prompt, bool initiallyChecked) : this()
        {
            CheckButtonCancel.IsEnabled = !prompt;
            CheckBoxSelection.Content = promptName ?? string.Empty;
            CheckBoxSelection.IsChecked = initiallyChecked;
            LabelDescription.Content = desc;
        }

        private void ToggleTheme()
        {
            // You can modify colors based on your theme preferences
            CheckButtonOK.Background = Theme.GetButtonBackground();
            CheckButtonOK.Foreground = Theme.GetButtonForeground();
            CheckButtonCancel.Background = Theme.GetButtonBackground();
            CheckButtonCancel.Foreground = Theme.GetButtonForeground();
            CheckBoxSelection.Foreground = Theme.GetLabelForeground();
        }

        private void CheckButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Value = CheckBoxSelection.IsChecked ?? false;
            Close();
        }

        private void CheckButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
