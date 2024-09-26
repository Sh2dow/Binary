using Binary;
using Binary.ViewModels;
using Nikki.Support.Shared.Class;
using System.Windows;
using System.Windows.Controls;

namespace Binary
{
    public partial class CareerEditor : Window
    {
        public CareerEditor(GCareer career, string path)
        {
            InitializeComponent();
            DataContext = new CareerEditorViewModel(career, path);  // Binding to ViewModel
        }

        // Event Handler for TreeView Selection
        private void CareerTreeView_AfterSelect(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var viewModel = DataContext as CareerEditorViewModel;
            var selectedItem = e.NewValue as TreeViewItemModel;
            viewModel.SelectedItemChanged(selectedItem);
        }
    }
}
