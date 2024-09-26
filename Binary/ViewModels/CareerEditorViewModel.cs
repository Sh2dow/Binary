using Nikki.Support.Shared.Class;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Binary.ViewModels;

public class CareerEditorViewModel : INotifyPropertyChanged
{
    public ObservableCollection<TreeViewItemModel> TreeViewItems { get; set; }
    public TreeViewItemModel SelectedObject { get; set; }
    private GCareer Career { get; }
    private string _careerPath;

    public CareerEditorViewModel(GCareer career, string path)
    {
        this.Career = career;
        this._careerPath = path;
        this.LoadTreeView();
    }

    private void LoadTreeView()
    {
        // Logic to populate TreeViewItems based on GCareer data
    }

    public ICommand AddCollectionCommand => new RelayCommand(this.AddCollection);
    public ICommand RemoveCollectionCommand => new RelayCommand(this.RemoveCollection);
    public ICommand CopyCollectionCommand => new RelayCommand(this.CopyCollection);
    public ICommand ScriptCollectionCommand => new RelayCommand(this.ScriptCollection);

    private void AddCollection(object parameter)
    {
        // Logic for adding collection
    }

    private void RemoveCollection(object parameter)
    {
        // Logic for removing collection
    }

    private void CopyCollection(object parameter)
    {
        // Logic for copying collection
    }

    private void ScriptCollection(object parameter)
    {
        // Logic for scripting collection
    }

    public void SelectedItemChanged(TreeViewItemModel selectedItem)
    {
        this.SelectedObject = selectedItem;
        this.OnPropertyChanged(nameof(this.SelectedObject));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
