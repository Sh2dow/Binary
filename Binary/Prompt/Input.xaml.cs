using System;
using System.Windows;

namespace Binary.Prompt
{
    public partial class Input : Window
    {
        private const string InvalidMessage = "Invalid input";
        private const string InputMessage = "Input value";
        private readonly Predicate<string> _inputCheck;
        private readonly string _errorMessage;
        public string Value { get; private set; } = string.Empty;

        public Input() : this(InputMessage, null, InvalidMessage, null) { }

        public Input(string text) : this(text, null, InvalidMessage, null) { }

        public Input(string text, Predicate<string> inputCheck) : this(text, inputCheck, InvalidMessage, null) { }

        public Input(string text, Predicate<string> inputCheck, string error) : this(text, inputCheck, error, null) { }

        public Input(string text, Predicate<string> inputCheck, string error, string initial)
        {
            InitializeComponent();
            ToggleTheme();
            InputLabel.Content = text;
            _inputCheck = inputCheck;
            _errorMessage = error;
            InputTextBox.Text = initial ?? string.Empty;
        }

        private void ToggleTheme()
        {
            // Example theme management using WPF style resources or programmatic color assignments
            InputButtonOK.Background = Theme.GetButtonBackground();
            InputButtonOK.Foreground = Theme.GetButtonForeground();
            InputButtonCancel.Background = Theme.GetButtonBackground();
            InputButtonCancel.Foreground = Theme.GetButtonForeground();
            InputTextBox.Background = Theme.GetTextBoxBackground();
            InputTextBox.Foreground = Theme.GetTextBoxForeground();
            InputLabel.Foreground = Theme.GetLabelForeground();
        }

        private void InputButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (!(_inputCheck?.Invoke(InputTextBox.Text) ?? true))
            {
                MessageBox.Show(_errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Value = InputTextBox.Text;
            Close();
        }

        private void InputButtonCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
