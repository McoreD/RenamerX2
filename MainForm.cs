using HelpersLib;
using IndexerLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            groupBoxInput.Enabled = comboBoxOperation.SelectedIndex == (int)OperationType.Replace;
            groupBoxInput.Text = string.Format("find ({0} chars)", textBoxInput.Text.Length);
            groupBoxOutput.Text = string.Format((comboBoxOperation.SelectedIndex == (int)OperationType.Replace ? "replace" : "with") + " ({0} chars)", textBoxOutput.Text.Length);

            buttonOk.Enabled = listBox.Items.Count > 0 && (checkBoxFiles.Checked || checkBoxFolders.Checked) &&
                (comboBoxOperation.SelectedIndex == (int)OperationType.Replace && textBoxInput.Text.Length > 0) ||
                (comboBoxOperation.SelectedIndex == (int)OperationType.Append && textBoxOutput.Text.Length > 0) ||
                (comboBoxOperation.SelectedIndex == (int)OperationType.Prepend && textBoxOutput.Text.Length > 0);
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

        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (checkBoxFiles.Checked || checkBoxFolders.Checked)
            {
                SaveSettings();
                Worker.Run(new WorkerConfig() { InputText = textBoxInput.Text, OutputText = textBoxOutput.Text });
                listBox.Items.Clear();
            }
            else
            {
                MessageBox.Show("Choose target; either files or folders or both.");
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (FolderSelectDialog dlg = new FolderSelectDialog())
            {
                dlg.Title = "Browse for folder...";

                if (dlg.ShowDialog())
                {
                    Worker.Load(new string[] { dlg.FileName });
                    listBox.Items.Add(dlg.FileName);
                }
            }
        }

        private void listBoxFolders_DragDrop(object sender, DragEventArgs e)
        {
            Worker.Load(e.Data.GetData(DataFormats.FileDrop, false) as string[]);
            listBox.Items.AddRange(Worker.Folders.Select(x => x.FolderName).ToArray<string>());
            listBox.Items.AddRange(Worker.Files.Select(x => Path.GetFileName(x.FullName)).ToArray<string>());
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
            listBox.Items.Clear();
            Worker.Clear();
        }

        private void comboBoxOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void checkBoxFiles_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void checkBoxFolders_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}