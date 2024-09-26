using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Binary;

public class TreeViewItemModel
{
    public string Name { get; set; }
    public ObservableCollection<TreeViewItemModel> Children { get; set; }
    public TreeViewItemModel Parent { get; set; } // Add parent reference if needed for hierarchy operations
    public object Data { get; set; }  // Holds associated data for the node

    public TreeViewItemModel()
    {
        Children = new ObservableCollection<TreeViewItemModel>();
    }
}
