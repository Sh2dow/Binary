using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Binary.UI;

public class MultiSelectTreeView : TreeView
{
    private List<TreeNode> selectedNodes = new List<TreeNode>();

    public List<TreeNode> SelectedNodes => selectedNodes;

    protected override void OnMouseDown(MouseEventArgs e)
    {
        TreeNode clickedNode = this.GetNodeAt(e.Location);

        if (clickedNode != null)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                // Ctrl-click to add/remove individual nodes
                ToggleNodeSelection(clickedNode);
            }
            else if (Control.ModifierKeys == Keys.Shift && selectedNodes.Count > 0)
            {
                // Shift-click to select a range of nodes within the same parent
                TreeNode firstNode = selectedNodes.First();
                if (clickedNode.Parent == firstNode.Parent)
                {
                    SelectNodeRange(firstNode, clickedNode);
                }
            }
            else
            {
                // Normal click selects only one node
                ClearSelection();
                AddNodeToSelection(clickedNode);
            }

            // Update the UI to show the selected node
            this.SelectedNode = clickedNode;
        }

        base.OnMouseDown(e);
    }

    private void AddNodeToSelection(TreeNode node)
    {
        if (!selectedNodes.Contains(node))
        {
            selectedNodes.Add(node);
            // Visual feedback: change node background color for selected nodes
            node.BackColor = Color.LightBlue;
        }
    }

    private void RemoveNodeFromSelection(TreeNode node)
    {
        if (selectedNodes.Contains(node))
        {
            selectedNodes.Remove(node);
            // Reset visual feedback
            node.BackColor = this.BackColor;
        }
    }

    private void ToggleNodeSelection(TreeNode node)
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

    private void SelectNodeRange(TreeNode startNode, TreeNode endNode)
    {
        if (startNode.Parent == endNode.Parent)
        {
            ClearSelection(); // Clear previous selection before selecting a range

            TreeNode parent = startNode.Parent;
            int startIndex = parent.Nodes.IndexOf(startNode);
            int endIndex = parent.Nodes.IndexOf(endNode);

            for (int i = Math.Min(startIndex, endIndex); i <= Math.Max(startIndex, endIndex); i++)
            {
                AddNodeToSelection(parent.Nodes[i]);
            }
        }
    }

    private void ClearSelection()
    {
        foreach (TreeNode node in selectedNodes)
        {
            node.BackColor = this.BackColor; // Reset background color
        }

        selectedNodes.Clear();
    }
}
