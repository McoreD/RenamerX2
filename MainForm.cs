using ShareX.HelpersLib;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenamerX
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (Program.Config.FileExtensions.Count == 0)
            {
                Program.Config.FileExtensions.Add("jpg");
                Program.Config.FileExtensions.Add("jpeg");
            }

            this.Text = "RenamerX";
            ConfigUI();

            Worker.ProgressChanged += Worker_ProgressChanged;
        }

        private void Worker_ProgressChanged(int current, int max)
        {
            this.InvokeSafe(() =>
            {
                groupBoxPaths.Text = $"Processing {current} of {max}";
            });
        }

        public void ConfigUI()
        {
            pgApp.SelectedObject = Program.Config;

            comboBoxOperation.Items.Clear();
            comboBoxOperation.Items.AddRange(Helpers.GetEnumDescriptions<OperationType>());
            comboBoxOperation.SelectedIndex = ((int)Program.Config.OperationType).BetweenOrDefault(0, comboBoxOperation.Items.Count - 1);

            UpdateUI();
        }

        public void UpdateUI()
        {
            groupBoxPaths.Text = $"Drag n drop files ({Worker.Files.Count}) / folders ({Worker.Folders.Count})";
            groupBoxInput.Enabled = comboBoxOperation.SelectedIndex == (int)OperationType.Replace;
            groupBoxInput.Text = string.Format("find ({0} chars)", textBoxFind.Text.Length);
            groupBoxOutput.Text = string.Format((comboBoxOperation.SelectedIndex == (int)OperationType.Replace ? "replace" : "with") + " ({0} chars)", textBoxReplaceWith.Text.Length);

            buttonOk.Enabled = listBox.Items.Count > 0 && (checkBoxFiles.Checked || checkBoxFolders.Checked) &&
                ((comboBoxOperation.SelectedIndex == (int)OperationType.Replace && textBoxFind.Text.Length > 0) ||
                (comboBoxOperation.SelectedIndex == (int)OperationType.Append && textBoxReplaceWith.Text.Length > 0) ||
                (comboBoxOperation.SelectedIndex == (int)OperationType.InsertAt && textBoxReplaceWith.Text.Length > 0) ||
                (comboBoxOperation.SelectedIndex == (int)OperationType.DeleteFilesLessThanResolution && Program.Config.Width > 0 && Program.Config.Height > 0) ||
                (comboBoxOperation.SelectedIndex == (int)OperationType.OrganizeFilesDateCreated && !string.IsNullOrEmpty(Program.Config.PhotosLocation) ||
                (comboBoxOperation.SelectedIndex == (int)OperationType.OrganizePhotos && !string.IsNullOrEmpty(Program.Config.PhotosLocation) ||
                (comboBoxOperation.SelectedIndex == (int)OperationType.RemoveEmptyFolders && checkBoxFolders.Checked) ||
                (comboBoxOperation.SelectedIndex == (int)OperationType.Prepend && textBoxReplaceWith.Text.Length > 0))));
        }

        public void SaveSettings()
        {
            Program.Config.OperationType = (OperationType)comboBoxOperation.SelectedIndex;
            Program.Files = checkBoxFiles.Checked;
            Program.Folders = checkBoxFolders.Checked;

            Program.Config.FindText = textBoxFind.Text;
            Program.Config.ReplaceWithText = textBoxReplaceWith.Text;
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
                buttonOk.Enabled = false;
                SaveSettings();

                Task.Run(() => Worker.Run(Program.Config)).ContinueWith(x =>
                {
                    listBox.Items.Clear();
                    UpdateUI();
                }, TaskScheduler.FromCurrentSynchronizationContext());
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

            UpdateUI();
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
            UpdateUI();
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

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}