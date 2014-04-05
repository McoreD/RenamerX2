using HelpersLib;
using IndexerLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenamerX
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = "RenamerX";
            ConfigUI();
        }

        public void ConfigUI()
        {
            comboBoxOperation.Items.Clear();
            comboBoxOperation.Items.AddRange(Helpers.GetEnumDescriptions<OperationType>());
            comboBoxOperation.SelectedIndex = ((int)Program.Config.OperationType).BetweenOrDefault(0, comboBoxOperation.Items.Count - 1);

            UpdateUI();
        }

        public void UpdateUI()
        {
            groupBoxInput.Text = string.Format("with {0} chars", textBoxInput.Text.Length);
        }

        public void SaveSettings()
        {
            Program.Config.OperationType = (OperationType)comboBoxOperation.SelectedIndex;
            Program.Config.Files = checkBoxFiles.Checked;
            Program.Config.Folders = checkBoxFolders.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Worker.Run(textBoxInput.Text);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            TextBox textBoxPath = new TextBox();
            using (FolderSelectDialog dlg = new FolderSelectDialog())
            {
                dlg.Title = "Browse for folder...";

                if (dlg.ShowDialog())
                {
                }
            }

            Helpers.BrowseFolder("Browse for folder...", textBoxPath);
        }

        private void listBoxFolders_DragDrop(object sender, DragEventArgs e)
        {
            Worker.Load(e.Data.GetData(DataFormats.FileDrop, false) as string[]);
            listBoxFolders.Items.AddRange(Worker.Folders.Select(x => x.FolderName).ToArray<string>());
        }

        private void listBoxFolders_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) ||
                e.Data.GetDataPresent(DataFormats.Bitmap, false) ||
                e.Data.GetDataPresent(DataFormats.Text, false))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxFolders.Items.Clear();
        }
    }
}