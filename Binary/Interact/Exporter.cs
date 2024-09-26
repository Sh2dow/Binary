﻿using System;
using System.Windows;




namespace Binary.Interact
{
    public partial class Exporter : Window
    {
        public bool Serialized { get; private set; } = true;

        public Exporter() : this(true) { }

        public Exporter(bool allow_not_serialized)
        {
            this.InitializeComponent();
            this.ToggleTheme();

            string tip =
                "If enabled, collection is exported with full amount of information " +
                "about it, compressed and protected from user changing it. If disabled, collection " +
                "is exported plainly as it is used in the game.";
            this.ExporterToolTip.SetToolTip(this.ExportSerialized, tip);

            if (!allow_not_serialized)
            {
                this.ExportSerialized.Enabled = false;
            }
            else
            {
                this.Serialized = false;
            }
        }

        private void ToggleTheme()
        {
            this.BackColor = Theme.MainBackColor;
            this.ForeColor = Theme.MainForeColor;
            this.ExportSerialized.BackColor = Theme.MainBackColor;
            this.ExportSerialized.ForeColor = Theme.LabelTextColor;
            this.ExporterButton.BackColor = Theme.ButtonBackColor;
            this.ExporterButton.ForeColor = Theme.ButtonForeColor;
            this.ExporterButton.FlatAppearance.BorderColor = Theme.ButtonFlatColor;
        }

        private void ExporterButton_Click(object sender, EventArgs e)
        {
            this.Serialized = this.ExportSerialized.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
