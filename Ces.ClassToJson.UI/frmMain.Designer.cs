namespace Ces.ClassToJson.UI
{
    partial class frmMain
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
            splitter1 = new Splitter();
            tvTypes = new TreeView();
            pnlMain = new Panel();
            txtJsonResult = new TextBox();
            pnlTop = new Panel();
            gbAssembly = new GroupBox();
            chkUseSamePath = new CheckBox();
            lblOutputPath = new Label();
            btnOutputPath = new Button();
            btnSelectFile = new Button();
            lblAssmeblyPath = new Label();
            gbConvert = new GroupBox();
            chkAddDataType = new CheckBox();
            txtNamespaceDelimiter = new TextBox();
            chkRemoveNamespaceDelimiter = new CheckBox();
            chkOverwrite = new CheckBox();
            btnConvertToJson = new Button();
            chkAllObjects = new CheckBox();
            splitContainer1 = new SplitContainer();
            btnCancel = new Button();
            btnClearSelection = new Button();
            btnExpandAll = new Button();
            pnlMain.SuspendLayout();
            pnlTop.SuspendLayout();
            gbAssembly.SuspendLayout();
            gbConvert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.BackColor = SystemColors.Control;
            splitter1.Location = new Point(441, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(5, 494);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // tvTypes
            // 
            tvTypes.BorderStyle = BorderStyle.None;
            tvTypes.CheckBoxes = true;
            tvTypes.Dock = DockStyle.Fill;
            tvTypes.HotTracking = true;
            tvTypes.Location = new Point(0, 0);
            tvTypes.Name = "tvTypes";
            tvTypes.Size = new Size(441, 437);
            tvTypes.TabIndex = 3;
            tvTypes.NodeMouseClick += tvTypes_NodeMouseClick;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(txtJsonResult);
            pnlMain.Controls.Add(pnlTop);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(446, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(427, 494);
            pnlMain.TabIndex = 6;
            // 
            // txtJsonResult
            // 
            txtJsonResult.Dock = DockStyle.Fill;
            txtJsonResult.Location = new Point(0, 330);
            txtJsonResult.Multiline = true;
            txtJsonResult.Name = "txtJsonResult";
            txtJsonResult.ScrollBars = ScrollBars.Both;
            txtJsonResult.Size = new Size(427, 164);
            txtJsonResult.TabIndex = 7;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(gbAssembly);
            pnlTop.Controls.Add(gbConvert);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(427, 330);
            pnlTop.TabIndex = 12;
            // 
            // gbAssembly
            // 
            gbAssembly.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbAssembly.Controls.Add(chkUseSamePath);
            gbAssembly.Controls.Add(lblOutputPath);
            gbAssembly.Controls.Add(btnOutputPath);
            gbAssembly.Controls.Add(btnSelectFile);
            gbAssembly.Controls.Add(lblAssmeblyPath);
            gbAssembly.Location = new Point(6, 12);
            gbAssembly.Name = "gbAssembly";
            gbAssembly.Size = new Size(411, 139);
            gbAssembly.TabIndex = 12;
            gbAssembly.TabStop = false;
            gbAssembly.Text = "Assembly";
            // 
            // chkUseSamePath
            // 
            chkUseSamePath.AutoSize = true;
            chkUseSamePath.Checked = true;
            chkUseSamePath.CheckState = CheckState.Checked;
            chkUseSamePath.Location = new Point(6, 114);
            chkUseSamePath.Name = "chkUseSamePath";
            chkUseSamePath.Size = new Size(272, 19);
            chkUseSamePath.TabIndex = 13;
            chkUseSamePath.Text = "Use same path (Load && Save in assembly path)";
            chkUseSamePath.UseVisualStyleBackColor = true;
            chkUseSamePath.CheckedChanged += chkUseSamePath_CheckedChanged;
            // 
            // lblOutputPath
            // 
            lblOutputPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOutputPath.AutoEllipsis = true;
            lblOutputPath.BackColor = SystemColors.Control;
            lblOutputPath.Cursor = Cursors.Hand;
            lblOutputPath.Font = new Font("Segoe UI", 8F);
            lblOutputPath.ForeColor = Color.FromArgb(0, 192, 0);
            lblOutputPath.Location = new Point(143, 73);
            lblOutputPath.Name = "lblOutputPath";
            lblOutputPath.Size = new Size(262, 30);
            lblOutputPath.TabIndex = 12;
            lblOutputPath.TextAlign = ContentAlignment.MiddleLeft;
            lblOutputPath.Click += lblOutputPath_Click;
            // 
            // btnOutputPath
            // 
            btnOutputPath.Enabled = false;
            btnOutputPath.Location = new Point(6, 68);
            btnOutputPath.Name = "btnOutputPath";
            btnOutputPath.Size = new Size(131, 40);
            btnOutputPath.TabIndex = 11;
            btnOutputPath.Text = "Output Path";
            btnOutputPath.UseVisualStyleBackColor = true;
            btnOutputPath.Click += btnSave_Click;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(6, 22);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(131, 40);
            btnSelectFile.TabIndex = 9;
            btnSelectFile.Text = "Select Assembly";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // lblAssmeblyPath
            // 
            lblAssmeblyPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAssmeblyPath.AutoEllipsis = true;
            lblAssmeblyPath.BackColor = SystemColors.Control;
            lblAssmeblyPath.Cursor = Cursors.Hand;
            lblAssmeblyPath.Font = new Font("Segoe UI", 8F);
            lblAssmeblyPath.ForeColor = Color.Blue;
            lblAssmeblyPath.Location = new Point(143, 27);
            lblAssmeblyPath.Name = "lblAssmeblyPath";
            lblAssmeblyPath.Size = new Size(262, 30);
            lblAssmeblyPath.TabIndex = 10;
            lblAssmeblyPath.TextAlign = ContentAlignment.MiddleLeft;
            lblAssmeblyPath.Click += lblAssmeblyPath_Click;
            // 
            // gbConvert
            // 
            gbConvert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbConvert.Controls.Add(chkAddDataType);
            gbConvert.Controls.Add(txtNamespaceDelimiter);
            gbConvert.Controls.Add(chkRemoveNamespaceDelimiter);
            gbConvert.Controls.Add(chkOverwrite);
            gbConvert.Controls.Add(btnConvertToJson);
            gbConvert.Controls.Add(chkAllObjects);
            gbConvert.Location = new Point(6, 157);
            gbConvert.Name = "gbConvert";
            gbConvert.Size = new Size(411, 168);
            gbConvert.TabIndex = 11;
            gbConvert.TabStop = false;
            gbConvert.Text = "Convert";
            // 
            // chkAddDataType
            // 
            chkAddDataType.AutoSize = true;
            chkAddDataType.Location = new Point(6, 97);
            chkAddDataType.Name = "chkAddDataType";
            chkAddDataType.Size = new Size(102, 19);
            chkAddDataType.TabIndex = 12;
            chkAddDataType.Text = "Add Data Type";
            chkAddDataType.UseVisualStyleBackColor = true;
            // 
            // txtNamespaceDelimiter
            // 
            txtNamespaceDelimiter.Enabled = false;
            txtNamespaceDelimiter.Location = new Point(197, 45);
            txtNamespaceDelimiter.MaxLength = 1;
            txtNamespaceDelimiter.Name = "txtNamespaceDelimiter";
            txtNamespaceDelimiter.Size = new Size(67, 23);
            txtNamespaceDelimiter.TabIndex = 11;
            txtNamespaceDelimiter.TextAlign = HorizontalAlignment.Center;
            // 
            // chkRemoveNamespaceDelimiter
            // 
            chkRemoveNamespaceDelimiter.AutoSize = true;
            chkRemoveNamespaceDelimiter.Location = new Point(6, 47);
            chkRemoveNamespaceDelimiter.Name = "chkRemoveNamespaceDelimiter";
            chkRemoveNamespaceDelimiter.Size = new Size(185, 19);
            chkRemoveNamespaceDelimiter.TabIndex = 10;
            chkRemoveNamespaceDelimiter.Text = "Remove Namespace Delimiter";
            chkRemoveNamespaceDelimiter.UseVisualStyleBackColor = true;
            chkRemoveNamespaceDelimiter.CheckedChanged += chkRemoveNamespaceDelimiter_CheckedChanged;
            // 
            // chkOverwrite
            // 
            chkOverwrite.AutoSize = true;
            chkOverwrite.Location = new Point(6, 72);
            chkOverwrite.Name = "chkOverwrite";
            chkOverwrite.Size = new Size(133, 19);
            chkOverwrite.TabIndex = 9;
            chkOverwrite.Text = "Overwrite if file exist";
            chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // btnConvertToJson
            // 
            btnConvertToJson.Location = new Point(6, 122);
            btnConvertToJson.Name = "btnConvertToJson";
            btnConvertToJson.Size = new Size(131, 40);
            btnConvertToJson.TabIndex = 6;
            btnConvertToJson.Text = "Convert To Json";
            btnConvertToJson.UseVisualStyleBackColor = true;
            btnConvertToJson.Click += btnConvertToJson_Click;
            // 
            // chkAllObjects
            // 
            chkAllObjects.AutoSize = true;
            chkAllObjects.Location = new Point(6, 22);
            chkAllObjects.Name = "chkAllObjects";
            chkAllObjects.Size = new Size(266, 19);
            chkAllObjects.TabIndex = 8;
            chkAllObjects.Text = "All Objects (Convert entire assembly to JSON)";
            chkAllObjects.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Left;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tvTypes);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnClearSelection);
            splitContainer1.Panel2.Controls.Add(btnExpandAll);
            splitContainer1.Size = new Size(441, 494);
            splitContainer1.SplitterDistance = 437;
            splitContainer1.TabIndex = 11;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.ForeColor = Color.Red;
            btnCancel.Location = new Point(372, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(63, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClearSelection
            // 
            btnClearSelection.Location = new Point(97, 6);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(109, 40);
            btnClearSelection.TabIndex = 6;
            btnClearSelection.Text = "Clear Selection";
            btnClearSelection.UseVisualStyleBackColor = true;
            btnClearSelection.Click += btnClearSelection_Click;
            // 
            // btnExpandAll
            // 
            btnExpandAll.Location = new Point(5, 6);
            btnExpandAll.Name = "btnExpandAll";
            btnExpandAll.Size = new Size(86, 40);
            btnExpandAll.TabIndex = 5;
            btnExpandAll.Text = "Expand All";
            btnExpandAll.UseVisualStyleBackColor = true;
            btnExpandAll.Click += btnExpandAll_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 494);
            Controls.Add(pnlMain);
            Controls.Add(splitter1);
            Controls.Add(splitContainer1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Class To Json";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlTop.ResumeLayout(false);
            gbAssembly.ResumeLayout(false);
            gbAssembly.PerformLayout();
            gbConvert.ResumeLayout(false);
            gbConvert.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Splitter splitter1;
        private TreeView tvTypes;
        private Panel pnlMain;
        private Button btnExpandAll;
        private Button btnConvertToJson;
        private TextBox txtJsonResult;
        private CheckBox chkAllObjects;
        private Button btnSelectFile;
        private SplitContainer splitContainer1;
        private Button btnClearSelection;
        private GroupBox gbConvert;
        private Panel pnlTop;
        private GroupBox gbAssembly;
        private Button btnOutputPath;
        private Label lblOutputPath;
        private Label lblAssmeblyPath;
        private CheckBox chkUseSamePath;
        private Button btnCancel;
        private CheckBox chkOverwrite;
        private TextBox txtNamespaceDelimiter;
        private CheckBox chkRemoveNamespaceDelimiter;
        private CheckBox chkAddDataType;
    }
}