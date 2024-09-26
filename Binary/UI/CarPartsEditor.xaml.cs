using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Nikki.Support.Shared.Class;
using Nikki.Support.Shared.Parts.CarParts;
using System.Windows.Input;

namespace Binary.UI
{
    public partial class CarPartsEditor : Window
    {
        private DBModelPart Model { get; }
        private readonly List<Window> _openWindows;

        public CarPartsEditor(DBModelPart model)
        {
            InitializeComponent();
            _openWindows = new List<Window>();
            Model = model;
            LoadTreeView();
        }

        private void LoadTreeView(string selected = null)
        {
            CarPartsTreeView.Items.Clear();
            foreach (var part in Model.ModelCarParts)
            {
                var partItem = new TreeViewItem { Header = part.PartName };
                foreach (var attribute in part.Attributes)
                {
                    var attrItem = new TreeViewItem { Header = attribute.ToString() };
                    partItem.Items.Add(attrItem);
                }
                CarPartsTreeView.Items.Add(partItem);
            }
        }

        private object GetSelectedObject(TreeViewItem node)
        {
            if (node.Parent == null)
                return Model.GetRealPart(CarPartsTreeView.Items.IndexOf(node));

            var parent = (TreeViewItem)node.Parent;
            return Model.GetRealPart(CarPartsTreeView.Items.IndexOf(parent))
                        .GetAttribute(parent.Items.IndexOf(node));
        }

        private void RecursiveNodeSelection(string path, ItemCollection nodes)
        {
            foreach (TreeViewItem node in nodes)
            {
                if (node.Header.ToString() == path)
                {
                    CarPartsTreeView.SelectedItem = node;
                    break;
                }
                RecursiveNodeSelection(path, node.Items);
            }
        }

        private void RecursiveTreeHighlights(string match, ItemCollection nodes)
        {
            foreach (TreeViewItem node in nodes)
            {
                if (node.Header.ToString().Contains(match))
                {
                    node.IsSelected = true;
                }
                RecursiveTreeHighlights(match, node.Items);
            }
        }

        private void ToggleMenuStripControls(TreeViewItem node)
        {
            // Enable/Disable menu controls based on node selection
            // For example: Enable buttons only if a specific node or part is selected
        }

        public ICommand AddPartCommand => new RelayCommand(AddPart);
        public ICommand RemovePartCommand => new RelayCommand(RemovePart);
        public ICommand CopyPartCommand => new RelayCommand(CopyPart);
        public ICommand MoveUpPartCommand => new RelayCommand(MoveUpPart);
        public ICommand MoveDownPartCommand => new RelayCommand(MoveDownPart);
        public ICommand MoveFirstPartCommand => new RelayCommand(MoveFirstPart);
        public ICommand MoveLastPartCommand => new RelayCommand(MoveLastPart);
        public ICommand ReversePartsCommand => new RelayCommand(ReverseParts);
        public ICommand SortPartsByNameCommand => new RelayCommand(SortPartsByName);
        public ICommand FindAndReplaceCommand => new RelayCommand(FindAndReplace);
        public ICommand AddAttributeCommand => new RelayCommand(AddAttribute);
        public ICommand RemoveAttributeCommand => new RelayCommand(RemoveAttribute);
        public ICommand MoveUpAttributeCommand => new RelayCommand(MoveUpAttribute);
        public ICommand MoveDownAttributeCommand => new RelayCommand(MoveDownAttribute);
        public ICommand ReverseAttributesCommand => new RelayCommand(ReverseAttributes);
        public ICommand SortAttributesByKeyCommand => new RelayCommand(SortAttributesByKey);
        public ICommand AddCustomAttributeCommand => new RelayCommand(AddCustomAttribute);
        public ICommand HasherCommand => new RelayCommand(Hasher);
        public ICommand RaiderCommand => new RelayCommand(Raider);

        private void AddPart()
        {
            Model.AddRealPart();
            LoadTreeView();
        }

        private void RemovePart()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var index = CarPartsTreeView.Items.IndexOf(selectedNode);
                Model.RemovePart(index);
                LoadTreeView();
            }
        }

        private void CopyPart()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var index = CarPartsTreeView.Items.IndexOf(selectedNode);
                Model.ClonePart(index);
                LoadTreeView();
            }
        }

        private void MoveUpPart()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var index = CarPartsTreeView.Items.IndexOf(selectedNode);
                if (index > 0)
                {
                    var part = Model.ModelCarParts[index];
                    Model.ModelCarParts.RemoveAt(index);
                    Model.ModelCarParts.Insert(index - 1, part);
                    LoadTreeView();
                }
            }
        }

        private void MoveDownPart()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var index = CarPartsTreeView.Items.IndexOf(selectedNode);
                if (index < Model.ModelCarParts.Count - 1)
                {
                    var part = Model.ModelCarParts[index];
                    Model.ModelCarParts.RemoveAt(index);
                    Model.ModelCarParts.Insert(index + 1, part);
                    LoadTreeView();
                }
            }
        }

        private void MoveFirstPart()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var index = CarPartsTreeView.Items.IndexOf(selectedNode);
                var part = Model.ModelCarParts[index];
                Model.ModelCarParts.RemoveAt(index);
                Model.ModelCarParts.Insert(0, part);
                LoadTreeView();
            }
        }

        private void MoveLastPart()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var index = CarPartsTreeView.Items.IndexOf(selectedNode);
                var part = Model.ModelCarParts[index];
                Model.ModelCarParts.RemoveAt(index);
                Model.ModelCarParts.Add(part);
                LoadTreeView();
            }
        }

        private void ReverseParts()
        {
            Model.ReverseParts();
            LoadTreeView();
        }

        private void SortPartsByName()
        {
            Model.SortByProperty(nameof(RealCarPart.PartName));
            LoadTreeView();
        }

        private void FindAndReplace()
        {
            // Find and replace logic here
        }

        private void AddAttribute()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var partIndex = CarPartsTreeView.Items.IndexOf(selectedNode);
                Model.AddAttribute(partIndex);  // Assuming there's a method in Model to add attribute
                LoadTreeView();
            }
        }

        private void RemoveAttribute()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var partIndex = CarPartsTreeView.Items.IndexOf(selectedNode);
                Model.RemoveAttribute(partIndex);  // Assuming method exists to remove an attribute
                LoadTreeView();
            }
        }

        private void MoveUpAttribute()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var partIndex = CarPartsTreeView.Items.IndexOf(selectedNode);
                Model.MoveAttributeUp(partIndex);  // Assuming this method moves the attribute up
                LoadTreeView();
            }
        }

        private void MoveDownAttribute()
        {
            var selectedNode = CarPartsTreeView.SelectedItem as TreeViewItem;
            if (selectedNode != null)
            {
                var partIndex = CarPartsTreeView.Items.IndexOf(selectedNode);
                Model.MoveAttributeDown(partIndex);  // Assuming this method moves the attribute down
                LoadTreeView();
            }
        }

        private void ReverseAttributes()
        {
            Model.ReverseAttributes();
            LoadTreeView();
        }

        private void SortAttributesByKey()
        {
            Model.SortAttributesByKey();
            LoadTreeView();
        }

        private void AddCustomAttribute()
        {
            // Add custom attribute logic, likely prompting the user for details
        }

        private void Hasher()
        {
            // Hasher tool logic
        }

        private void Raider()
        {
            // Raider tool logic
        }

        private void CarPartsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedNode = e.NewValue as TreeViewItem;
            if (selectedNode != null)
            {
                var selectedObject = GetSelectedObject(selectedNode);
                CarPartsPropertyGrid.SelectedObject = selectedObject;
            }
        }

        private void CarPartsTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // Logic to handle before selecting a TreeViewItem
            ToggleMenuStripControls(e.Node);
        }

        private void CarPartsTreeView_After(object sender, TreeViewEventArgs e)
        {
            // Logic for actions after selecting a node in the TreeView
            var selectedNode = e.Node;
            if (selectedNode != null)
            {
                ToggleMenuStripControls(selectedNode);
            }
        }

        private void CarPartsPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            // Logic for when a property value changes in the PropertyGrid
            // Typically, you would rebind the updated object back to the model or update the UI accordingly.
            var updatedObject = CarPartsPropertyGrid.SelectedObject;
            Model.UpdateCarPart(updatedObject); // Assuming Model has this method
        }

        private void CarPartsEditor_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Handle any necessary clean-up, prompt user for unsaved changes, etc., before closing the window.
            if (Model.HasUnsavedChanges)
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to save before exiting?", 
                    "Unsaved Changes", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    Model.SaveChanges();
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
