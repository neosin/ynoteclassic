﻿using System;
using System.IO;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace SS.Ynote.Classic.UI
{
    public partial class MacroExecDialog : Form
    {
        private readonly FastColoredTextBox fctb;

        public MacroExecDialog(FastColoredTextBox tb)
        {
            InitializeComponent();
            foreach (var item in Directory.GetFiles(Settings.SettingsDir + @"\Macros", "*.ymc"))
                cmbMacros.Items.Add(Path.GetFileNameWithoutExtension(item));
            cmbMacros.SelectedIndex = 0;
            fctb = tb;
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            var macro = Path.Combine(Settings.SettingsDir + @"\Macros", cmbMacros.Text + ".ymc");
            var i = 0;
            while (i < times.Value)
            {
                fctb.MacrosManager.ExecuteMacros(macro);
                i++;
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}