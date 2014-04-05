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
            this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
            this.checkBoxFolders = new System.Windows.Forms.CheckBox();
            this.checkBoxFiles = new System.Windows.Forms.CheckBox();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxPaths = new System.Windows.Forms.GroupBox();
            this.listBoxFolders = new System.Windows.Forms.ListBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
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
            this.comboBoxOperation.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOperation.TabIndex = 0;
            this.comboBoxOperation.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperation_SelectedIndexChanged);
            // 
            // groupBoxOperation
            // 
            this.groupBoxOperation.Controls.Add(this.comboBoxOperation);
            this.groupBoxOperation.Location = new System.Drawing.Point(8, 8);
            this.groupBoxOperation.Name = "groupBoxOperation";
            this.groupBoxOperation.Size = new System.Drawing.Size(144, 48);
            this.groupBoxOperation.TabIndex = 1;
            this.groupBoxOperation.TabStop = false;
            this.groupBoxOperation.Text = "I would like to";
            // 
            // groupBoxTargets
            // 
            this.groupBoxTargets.Controls.Add(this.checkBoxRecursive);
            this.groupBoxTargets.Controls.Add(this.checkBoxFolders);
            this.groupBoxTargets.Controls.Add(this.checkBoxFiles);
            this.groupBoxTargets.Location = new System.Drawing.Point(160, 8);
            this.groupBoxTargets.Name = "groupBoxTargets";
            this.groupBoxTargets.Size = new System.Drawing.Size(452, 48);
            this.groupBoxTargets.TabIndex = 2;
            this.groupBoxTargets.TabStop = false;
            this.groupBoxTargets.Text = "Target";
            // 
            // checkBoxRecursive
            // 
            this.checkBoxRecursive.AutoSize = true;
            this.checkBoxRecursive.Location = new System.Drawing.Point(262, 19);
            this.checkBoxRecursive.Name = "checkBoxRecursive";
            this.checkBoxRecursive.Size = new System.Drawing.Size(184, 17);
            this.checkBoxRecursive.TabIndex = 2;
            this.checkBoxRecursive.Text = "including subfolders and their files";
            this.checkBoxRecursive.UseVisualStyleBackColor = true;
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
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.textBoxOutput);
            this.groupBoxOutput.Location = new System.Drawing.Point(264, 288);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(245, 52);
            this.groupBoxOutput.TabIndex = 3;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "with";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(6, 19);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(226, 20);
            this.textBoxOutput.TabIndex = 0;
            this.textBoxOutput.TextChanged += new System.EventHandler(this.textBoxOutput_TextChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(544, 408);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Make it so";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBoxPaths
            // 
            this.groupBoxPaths.Controls.Add(this.listBoxFolders);
            this.groupBoxPaths.Location = new System.Drawing.Point(8, 64);
            this.groupBoxPaths.Name = "groupBoxPaths";
            this.groupBoxPaths.Size = new System.Drawing.Size(520, 215);
            this.groupBoxPaths.TabIndex = 5;
            this.groupBoxPaths.TabStop = false;
            this.groupBoxPaths.Text = "Drag n drop files/folders";
            // 
            // listBoxFolders
            // 
            this.listBoxFolders.AllowDrop = true;
            this.listBoxFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFolders.FormattingEnabled = true;
            this.listBoxFolders.Location = new System.Drawing.Point(3, 16);
            this.listBoxFolders.Name = "listBoxFolders";
            this.listBoxFolders.Size = new System.Drawing.Size(514, 196);
            this.listBoxFolders.TabIndex = 0;
            this.listBoxFolders.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxFolders_DragDrop);
            this.listBoxFolders.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxFolders_DragEnter);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(544, 143);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 6;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(544, 172);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBoxFind
            // 
            this.groupBoxInput.Controls.Add(this.textBoxInput);
            this.groupBoxInput.Location = new System.Drawing.Point(8, 288);
            this.groupBoxInput.Name = "groupBoxFind";
            this.groupBoxInput.Size = new System.Drawing.Size(245, 52);
            this.groupBoxInput.TabIndex = 4;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "find";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(6, 19);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(226, 20);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxOutput_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.groupBoxPaths);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxTargets);
            this.Controls.Add(this.groupBoxOperation);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
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

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOperation;
        private System.Windows.Forms.GroupBox groupBoxOperation;
        private System.Windows.Forms.GroupBox groupBoxTargets;
        private System.Windows.Forms.CheckBox checkBoxRecursive;
        private System.Windows.Forms.CheckBox checkBoxFolders;
        private System.Windows.Forms.CheckBox checkBoxFiles;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxPaths;
        private System.Windows.Forms.ListBox listBoxFolders;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.TextBox textBoxInput;
    }
}

