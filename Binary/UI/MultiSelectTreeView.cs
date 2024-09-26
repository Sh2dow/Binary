using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Controls;

using System.Windows.Input;

namespace Binary.UI;

public class MultiSelectTreeView : TreeView
{
    private List<TreeViewItemModel> selectedNodes = new List<TreeViewItemModel>();

    public List<TreeViewItemModel> SelectedNodes => selectedNodes;

    protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
    {
        TreeViewItem clickedNode = e.Source as TreeViewItem;
        if (clickedNode != null)
        {
            TreeViewItemModel nodeModel = clickedNode.DataContext as TreeViewItemModel;

            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                ToggleNodeSelection(nodeModel);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Shift && selectedNodes.Count > 0)
            {
                SelectNodeRange(selectedNodes.First(), nodeModel);
            }
            else
            {
                ClearSelection();
                AddNodeToSelection(nodeModel);
            }
        }

        base.OnPreviewMouseDown(e);
    }

    private void AddNodeToSelection(TreeViewItemModel node)
    {
        if (!selectedNodes.Contains(node))
        {
            selectedNodes.Add(node);
            // Add visual changes here (e.g., highlight selected node)
        }
    }

    private void RemoveNodeFromSelection(TreeViewItemModel node)
    {
        if (selectedNodes.Contains(node))
        {
            selectedNodes.Remove(node);
            // Remove visual changes here (e.g., un-highlight node)
        }
    }

    private void ToggleNodeSelection(TreeViewItemModel node)
    {
        if (selectedNodes.Contains(node))
        {
            RemoveNodeFromSelection(node);
        }
        else
        {
            AddNodeToSelection(node);
        }
    }

    private void SelectNodeRange(TreeViewItemModel startNode, TreeViewItemModel endNode)
    {
        // Clear previous selection before selecting a range
        ClearSelection();

        if (startNode.Parent == endNode.Parent)
        {
            var parent = startNode.Parent;
            int startIndex = parent.Children.IndexOf(startNode);
            int endIndex = parent.Children.IndexOf(endNode);

            for (int i = Math.Min(startIndex, endIndex); i <= Math.Max(startIndex, endIndex); i++)
            {
                AddNodeToSelection(parent.Children[i]);
            }
        }
    }

    private void ClearSelection()
    {
        selectedNodes.Clear();
        // Clear visual selection if needed
    }
}
