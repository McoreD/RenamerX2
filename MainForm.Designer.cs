namespace RenamerX
{
    partial class MainForm
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
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.groupBoxOperation = new System.Windows.Forms.GroupBox();
            this.groupBoxTargets = new System.Windows.Forms.GroupBox();
            this.checkBoxFolders = new System.Windows.Forms.CheckBox();
            this.checkBoxFiles = new System.Windows.Forms.CheckBox();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.textBoxReplaceWith = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxPaths = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.pgApp = new System.Windows.Forms.PropertyGrid();
            this.groupBoxOperation.SuspendLayout();
            this.groupBoxTargets.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxPaths.SuspendLayout();
            this.groupBoxInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.Location = new System.Drawing.Point(6, 19);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(290, 21);
            this.comboBoxOperation.TabIndex = 0;
            this.comboBoxOperation.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperation_SelectedIndexChanged);
            // 
            // groupBoxOperation
            // 
            this.groupBoxOperation.Controls.Add(this.comboBoxOperation);
            this.groupBoxOperation.Location = new System.Drawing.Point(8, 8);
            this.groupBoxOperation.Name = "groupBoxOperation";
            this.groupBoxOperation.Size = new System.Drawing.Size(312, 48);
            this.groupBoxOperation.TabIndex = 0;
            this.groupBoxOperation.TabStop = false;
            this.groupBoxOperation.Text = "I would like to";
            // 
            // groupBoxTargets
            // 
            this.groupBoxTargets.Controls.Add(this.checkBoxFolders);
            this.groupBoxTargets.Controls.Add(this.checkBoxFiles);
            this.groupBoxTargets.Location = new System.Drawing.Point(344, 8);
            this.groupBoxTargets.Name = "groupBoxTargets";
            this.groupBoxTargets.Size = new System.Drawing.Size(272, 48);
            this.groupBoxTargets.TabIndex = 1;
            this.groupBoxTargets.TabStop = false;
            this.groupBoxTargets.Text = "Target";
            // 
            // checkBoxFolders
            // 
            this.checkBoxFolders.AutoSize = true;
            this.checkBoxFolders.Location = new System.Drawing.Point(67, 19);
            this.checkBoxFolders.Name = "checkBoxFolders";
            this.checkBoxFolders.Size = new System.Drawing.Size(60, 17);
            this.checkBoxFolders.TabIndex = 1;
            this.checkBoxFolders.Text = "Folders";
            this.checkBoxFolders.UseVisualStyleBackColor = true;
            this.checkBoxFolders.CheckedChanged += new System.EventHandler(this.checkBoxFolders_CheckedChanged);
            // 
            // checkBoxFiles
            // 
            this.checkBoxFiles.AutoSize = true;
            this.checkBoxFiles.Location = new System.Drawing.Point(6, 19);
            this.checkBoxFiles.Name = "checkBoxFiles";
            this.checkBoxFiles.Size = new System.Drawing.Size(47, 17);
            this.checkBoxFiles.TabIndex = 0;
            this.checkBoxFiles.Text = "Files";
            this.checkBoxFiles.UseVisualStyleBackColor = true;
            this.checkBoxFiles.CheckedChanged += new System.EventHandler(this.checkBoxFiles_CheckedChanged);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.textBoxReplaceWith);
            this.groupBoxOutput.Location = new System.Drawing.Point(168, 64);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(149, 48);
            this.groupBoxOutput.TabIndex = 3;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "with";
            // 
            // textBoxReplaceWith
            // 
            this.textBoxReplaceWith.Location = new System.Drawing.Point(6, 19);
            this.textBoxReplaceWith.Name = "textBoxReplaceWith";
            this.textBoxReplaceWith.Size = new System.Drawing.Size(130, 20);
            this.textBoxReplaceWith.TabIndex = 0;
            this.textBoxReplaceWith.TextChanged += new System.EventHandler(this.textBoxOutput_TextChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.AutoSize = true;
            this.buttonOk.Enabled = false;
            this.buttonOk.Image = global::RenamerX.Properties.Resources.MakeItSo;
            this.buttonOk.Location = new System.Drawing.Point(347, 320);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(273, 196);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBoxPaths
            // 
            this.groupBoxPaths.Controls.Add(this.listBox);
            this.groupBoxPaths.Location = new System.Drawing.Point(344, 64);
            this.groupBoxPaths.Name = "groupBoxPaths";
            this.groupBoxPaths.Size = new System.Drawing.Size(273, 208);
            this.groupBoxPaths.TabIndex = 4;
            this.groupBoxPaths.TabStop = false;
            this.groupBoxPaths.Text = "Drag n drop files/folders";
            // 
            // listBox
            // 
            this.listBox.AllowDrop = true;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(3, 16);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(267, 189);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxFolders_DragDrop);
            this.listBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxFolders_DragEnter);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(347, 288);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 6;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(545, 288);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.textBoxFind);
            this.groupBoxInput.Location = new System.Drawing.Point(8, 64);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(152, 48);
            this.groupBoxInput.TabIndex = 2;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "find";
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(6, 19);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(138, 20);
            this.textBoxFind.TabIndex = 0;
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBoxOutput_TextChanged);
            // 
            // pgApp
            // 
            this.pgApp.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pgApp.Location = new System.Drawing.Point(8, 124);
            this.pgApp.Name = "pgApp";
            this.pgApp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgApp.Size = new System.Drawing.Size(312, 388);
            this.pgApp.TabIndex = 5;
            this.pgApp.ToolbarVisible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 527);
            this.Controls.Add(this.pgApp);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.groupBoxPaths);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxTargets);
            this.Controls.Add(this.groupBoxOperation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 320);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBoxOperation.ResumeLayout(false);
            this.groupBoxTargets.ResumeLayout(false);
            this.groupBoxTargets.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.groupBoxPaths.ResumeLayout(false);
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOperation;
        private System.Windows.Forms.GroupBox groupBoxOperation;
        private System.Windows.Forms.GroupBox groupBoxTargets;
        private System.Windows.Forms.CheckBox checkBoxFolders;
        private System.Windows.Forms.CheckBox checkBoxFiles;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.TextBox textBoxReplaceWith;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxPaths;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.PropertyGrid pgApp;
    }
}

