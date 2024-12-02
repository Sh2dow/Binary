using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Binary.UI
{
	partial class TextureEditor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureEditor));
            TexEditorMenuStrip = new System.Windows.Forms.MenuStrip();
            TexEditorTexturesStrip = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorAddTextureItem = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorRemoveTextureItem = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorCopyTextureItem = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorReplaceTextureItem = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorExportTextureItem = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorOptionsStrip = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorExportAllItem = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorImportFromItem = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorFindReplaceItem = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorToolsStrip = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorHasherItem = new System.Windows.Forms.ToolStripMenuItem();
            TexEditorRaiderItem = new System.Windows.Forms.ToolStripMenuItem();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            TexEditorListView = new System.Windows.Forms.ListView();
            ColumnIndex = new System.Windows.Forms.ColumnHeader();
            ColumnKey = new System.Windows.Forms.ColumnHeader();
            ColumnCollectionName = new System.Windows.Forms.ColumnHeader();
            ColumnCompression = new System.Windows.Forms.ColumnHeader();
            TexEditorPropertyGrid = new System.Windows.Forms.PropertyGrid();
            panel1 = new System.Windows.Forms.Panel();
            TexEditorImage = new System.Windows.Forms.PictureBox();
            AddTextureDialog = new System.Windows.Forms.OpenFileDialog();
            ReplaceTextureDialog = new System.Windows.Forms.OpenFileDialog();
            ExportTextureDialog = new System.Windows.Forms.SaveFileDialog();
            TexEditorSearchBox = new System.Windows.Forms.TextBox();
            TexEditorMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TexEditorImage).BeginInit();
            SuspendLayout();
            // 
            // TexEditorMenuStrip
            // 
            TexEditorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TexEditorTexturesStrip, TexEditorOptionsStrip, TexEditorToolsStrip });
            TexEditorMenuStrip.Location = new System.Drawing.Point(0, 0);
            TexEditorMenuStrip.Name = "TexEditorMenuStrip";
            TexEditorMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            TexEditorMenuStrip.Size = new System.Drawing.Size(1485, 24);
            TexEditorMenuStrip.TabIndex = 0;
            TexEditorMenuStrip.Text = "StrEditorMenuStrip";
            // 
            // TexEditorTexturesStrip
            // 
            TexEditorTexturesStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TexEditorAddTextureItem, TexEditorRemoveTextureItem, TexEditorCopyTextureItem, TexEditorReplaceTextureItem, TexEditorExportTextureItem });
            TexEditorTexturesStrip.Name = "TexEditorTexturesStrip";
            TexEditorTexturesStrip.Size = new System.Drawing.Size(62, 20);
            TexEditorTexturesStrip.Text = "Textures";
            // 
            // TexEditorAddTextureItem
            // 
            TexEditorAddTextureItem.Name = "TexEditorAddTextureItem";
            TexEditorAddTextureItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A));
            TexEditorAddTextureItem.Size = new System.Drawing.Size(200, 22);
            TexEditorAddTextureItem.Text = "Add Texture";
            TexEditorAddTextureItem.Click += TexEditorAddTextureItem_Click;
            // 
            // TexEditorRemoveTextureItem
            // 
            TexEditorRemoveTextureItem.Name = "TexEditorRemoveTextureItem";
            TexEditorRemoveTextureItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            TexEditorRemoveTextureItem.Size = new System.Drawing.Size(200, 22);
            TexEditorRemoveTextureItem.Text = "Remove Texture";
            TexEditorRemoveTextureItem.Click += TexEditorRemoveTextureItem_Click;
            // 
            // TexEditorCopyTextureItem
            // 
            TexEditorCopyTextureItem.Name = "TexEditorCopyTextureItem";
            TexEditorCopyTextureItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C));
            TexEditorCopyTextureItem.Size = new System.Drawing.Size(200, 22);
            TexEditorCopyTextureItem.Text = "Copy Texture";
            TexEditorCopyTextureItem.Click += TexEditorCopyTextureItem_Click;
            // 
            // TexEditorReplaceTextureItem
            // 
            TexEditorReplaceTextureItem.Name = "TexEditorReplaceTextureItem";
            TexEditorReplaceTextureItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            TexEditorReplaceTextureItem.Size = new System.Drawing.Size(200, 22);
            TexEditorReplaceTextureItem.Text = "Replace Texture";
            TexEditorReplaceTextureItem.Click += TexEditorReplaceTextureItem_Click;
            // 
            // TexEditorExportTextureItem
            // 
            TexEditorExportTextureItem.Name = "TexEditorExportTextureItem";
            TexEditorExportTextureItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            TexEditorExportTextureItem.Size = new System.Drawing.Size(200, 22);
            TexEditorExportTextureItem.Text = "Export Texture";
            TexEditorExportTextureItem.Click += TexEditorExportTextureItem_Click;
            // 
            // TexEditorOptionsStrip
            // 
            TexEditorOptionsStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TexEditorExportAllItem, TexEditorImportFromItem, TexEditorFindReplaceItem });
            TexEditorOptionsStrip.Name = "TexEditorOptionsStrip";
            TexEditorOptionsStrip.Size = new System.Drawing.Size(61, 20);
            TexEditorOptionsStrip.Text = "Options";
            // 
            // TexEditorExportAllItem
            // 
            TexEditorExportAllItem.Name = "TexEditorExportAllItem";
            TexEditorExportAllItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.E));
            TexEditorExportAllItem.Size = new System.Drawing.Size(246, 22);
            TexEditorExportAllItem.Text = "Export All";
            TexEditorExportAllItem.Click += TexEditorExportAllItem_Click;
            // 
            // TexEditorImportFromItem
            // 
            TexEditorImportFromItem.Name = "TexEditorImportFromItem";
            TexEditorImportFromItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.I));
            TexEditorImportFromItem.Size = new System.Drawing.Size(246, 22);
            TexEditorImportFromItem.Text = "Import From Folder";
            TexEditorImportFromItem.Click += TexEditorImportFromItem_Click;
            // 
            // TexEditorFindReplaceItem
            // 
            TexEditorFindReplaceItem.Name = "TexEditorFindReplaceItem";
            TexEditorFindReplaceItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.R));
            TexEditorFindReplaceItem.Size = new System.Drawing.Size(246, 22);
            TexEditorFindReplaceItem.Text = "Find And Replace";
            TexEditorFindReplaceItem.Click += TexEditorFindReplaceItem_Click;
            // 
            // TexEditorToolsStrip
            // 
            TexEditorToolsStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TexEditorHasherItem, TexEditorRaiderItem });
            TexEditorToolsStrip.Name = "TexEditorToolsStrip";
            TexEditorToolsStrip.Size = new System.Drawing.Size(47, 20);
            TexEditorToolsStrip.Text = "Tools";
            // 
            // TexEditorHasherItem
            // 
            TexEditorHasherItem.Name = "TexEditorHasherItem";
            TexEditorHasherItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H));
            TexEditorHasherItem.Size = new System.Drawing.Size(150, 22);
            TexEditorHasherItem.Text = "Hasher";
            TexEditorHasherItem.Click += TexEditorHasherItem_Click;
            // 
            // TexEditorRaiderItem
            // 
            TexEditorRaiderItem.Name = "TexEditorRaiderItem";
            TexEditorRaiderItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R));
            TexEditorRaiderItem.Size = new System.Drawing.Size(150, 22);
            TexEditorRaiderItem.Text = "Raider";
            TexEditorRaiderItem.Click += TexEditorRaiderItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 24);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // 
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            splitContainer1.Panel1MinSize = 300;
            // 
            // 
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2MinSize = 524;
            splitContainer1.Size = new System.Drawing.Size(1485, 1096);
            splitContainer1.SplitterDistance = 532;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            splitContainer2.Panel1.Controls.Add(TexEditorListView);
            splitContainer2.Panel1MinSize = 200;
            // 
            // 
            // 
            splitContainer2.Panel2.Controls.Add(TexEditorPropertyGrid);
            splitContainer2.Panel2MinSize = 200;
            splitContainer2.Size = new System.Drawing.Size(532, 1096);
            splitContainer2.SplitterDistance = 692;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 0;
            // 
            // TexEditorListView
            // 
            TexEditorListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            TexEditorListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            TexEditorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ColumnIndex, ColumnKey, ColumnCollectionName, ColumnCompression });
            TexEditorListView.FullRowSelect = true;
            TexEditorListView.GridLines = true;
            TexEditorListView.Location = new System.Drawing.Point(12, 3);
            TexEditorListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TexEditorListView.MultiSelect = false;
            TexEditorListView.Name = "TexEditorListView";
            TexEditorListView.OwnerDraw = true;
            TexEditorListView.Size = new System.Drawing.Size(514, 694);
            TexEditorListView.TabIndex = 0;
            TexEditorListView.UseCompatibleStateImageBehavior = false;
            TexEditorListView.View = System.Windows.Forms.View.Details;
            TexEditorListView.ColumnClick += TexEditorListView_ColumnClick;
            TexEditorListView.ColumnWidthChanging += TexEditorListView_ColumnWidthChanging;
            TexEditorListView.DrawColumnHeader += TexEditorListView_DrawColumnHeader;
            TexEditorListView.DrawItem += TexEditorListView_DrawItem;
            TexEditorListView.SelectedIndexChanged += TexEditorListView_SelectedIndexChanged;
            // 
            // ColumnIndex
            // 
            ColumnIndex.Name = "ColumnIndex";
            ColumnIndex.Text = "Index";
            // 
            // ColumnKey
            // 
            ColumnKey.Name = "ColumnKey";
            ColumnKey.Text = "BinKey";
            ColumnKey.Width = 100;
            // 
            // ColumnCollectionName
            // 
            ColumnCollectionName.Name = "ColumnCollectionName";
            ColumnCollectionName.Text = "CollectionName";
            ColumnCollectionName.Width = 260;
            // 
            // ColumnCompression
            // 
            ColumnCompression.Name = "ColumnCompression";
            ColumnCompression.Text = "Format";
            ColumnCompression.Width = 70;
            // 
            // TexEditorPropertyGrid
            // 
            TexEditorPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            TexEditorPropertyGrid.HelpVisible = false;
            TexEditorPropertyGrid.Location = new System.Drawing.Point(14, 84);
            TexEditorPropertyGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TexEditorPropertyGrid.Name = "TexEditorPropertyGrid";
            TexEditorPropertyGrid.Size = new System.Drawing.Size(512, 282);
            TexEditorPropertyGrid.TabIndex = 0;
            TexEditorPropertyGrid.PropertyValueChanged += TexEditorPropertyGrid_PropertyValueChanged;
            // 
            // panel1
            // 
            panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(TexEditorImage);
            panel1.Location = new System.Drawing.Point(6, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(897, 1063);
            panel1.TabIndex = 1;
            // 
            // TexEditorImage
            // 
            TexEditorImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            TexEditorImage.Location = new System.Drawing.Point(0, 0);
            TexEditorImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TexEditorImage.Name = "TexEditorImage";
            TexEditorImage.Size = new System.Drawing.Size(560, 560);
            TexEditorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            TexEditorImage.TabIndex = 0;
            TexEditorImage.TabStop = false;
            // 
            // AddTextureDialog
            // 
            AddTextureDialog.Filter = "Direct Draw Surface Files|*.dds";
            AddTextureDialog.FileOk += AddTextureDialog_FileOk;
            // 
            // ReplaceTextureDialog
            // 
            ReplaceTextureDialog.Filter = "Direct Draw Surface Files|*.dds";
            ReplaceTextureDialog.FileOk += ReplaceTextureDialog_FileOk;
            // 
            // TexEditorSearchBox
            // 
            TexEditorSearchBox.Name = "TexEditorSearchBox";
            TexEditorSearchBox.Location = new System.Drawing.Point(366, 777);
            TexEditorSearchBox.Size = new System.Drawing.Size(166, 23);
            TexEditorSearchBox.TabIndex = 3;
            TexEditorSearchBox.Visible = false;
            TexEditorSearchBox.BackColor = System.Drawing.Color.LightBlue;
            TexEditorSearchBox.TextChanged += TexEditorSearchBox_TextChanged;
            // 
            // TextureEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1485, 1120);
            Controls.Add(splitContainer1);
            Controls.Add(TexEditorMenuStrip);
            Controls.Add(TexEditorSearchBox);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
            MainMenuStrip = TexEditorMenuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1164, 666);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Texture Editor";
            FormClosing += TextureEditor_FormClosing;
            TexEditorMenuStrip.ResumeLayout(false);
            TexEditorMenuStrip.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TexEditorImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

		private System.Windows.Forms.MenuStrip TexEditorMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem TexEditorTexturesStrip;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListView TexEditorListView;
		private System.Windows.Forms.PropertyGrid TexEditorPropertyGrid;
		private System.Windows.Forms.PictureBox TexEditorImage;
		private System.Windows.Forms.ToolStripMenuItem TexEditorAddTextureItem;
		private System.Windows.Forms.ToolStripMenuItem TexEditorRemoveTextureItem;
		private System.Windows.Forms.ToolStripMenuItem TexEditorCopyTextureItem;
		private System.Windows.Forms.ToolStripMenuItem TexEditorReplaceTextureItem;
		private System.Windows.Forms.ToolStripMenuItem TexEditorExportTextureItem;
		private System.Windows.Forms.ToolStripMenuItem TexEditorOptionsStrip;
		private System.Windows.Forms.ToolStripMenuItem TexEditorExportAllItem;
		private System.Windows.Forms.ToolStripMenuItem TexEditorImportFromItem;
		private System.Windows.Forms.ToolStripMenuItem TexEditorFindReplaceItem;
		private System.Windows.Forms.ToolStripMenuItem TexEditorToolsStrip;
		private System.Windows.Forms.ToolStripMenuItem TexEditorHasherItem;
		private System.Windows.Forms.ToolStripMenuItem TexEditorRaiderItem;
		private System.Windows.Forms.ColumnHeader ColumnIndex;
		private System.Windows.Forms.ColumnHeader ColumnKey;
		private System.Windows.Forms.ColumnHeader ColumnCollectionName;
		private System.Windows.Forms.ColumnHeader ColumnCompression;
		private System.Windows.Forms.OpenFileDialog AddTextureDialog;
		private System.Windows.Forms.OpenFileDialog ReplaceTextureDialog;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SaveFileDialog ExportTextureDialog;
        private List<ListViewItem> _originalItems;
        private System.Windows.Forms.TextBox TexEditorSearchBox;
	}
}
