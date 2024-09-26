using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Binary
{
    public class EditorViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TreeViewItemModel> TreeViewItems { get; set; }

        private TreeViewItemModel _selectedNode;
        public TreeViewItemModel SelectedNode
        {
            get { return this._selectedNode; }
            set
            {
                this._selectedNode = value;
                this.OnPropertyChanged(nameof(this.SelectedNode));
            }
        }

        public ICommand NewLauncherCommand { get; private set; }
        public ICommand LoadFilesCommand { get; private set; }
        public ICommand SaveFilesCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public EditorViewModel()
        {
            // Initialize commands and data
            this.NewLauncherCommand = new RelayCommand(this.NewLauncher);
            this.LoadFilesCommand = new RelayCommand(this.LoadFiles);
            this.SaveFilesCommand = new RelayCommand(this.SaveFiles);
            this.ExitCommand = new RelayCommand(this.ExitApplication);

            // Populate TreeViewItems as needed
        }

        private void NewLauncher(object parameter) { /* Logic for new launcher */ }
        private void LoadFiles(object parameter) { /* Logic for loading files */ }
        private void SaveFiles(object parameter) { /* Logic for saving files */ }
        private void ExitApplication(object parameter) { Application.Current.Shutdown(); }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
