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
            btnReadObjects = new Button();
            splitter1 = new Splitter();
            tvTypes = new TreeView();
            btnGetProperties = new Button();
            splitContainer1 = new SplitContainer();
            lbProperties = new CheckedListBox();
            panel1 = new Panel();
            txtJsonResult = new TextBox();
            btnConvertToJson = new Button();
            btnExpandAll = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnReadObjects
            // 
            btnReadObjects.Location = new Point(6, 12);
            btnReadObjects.Name = "btnReadObjects";
            btnReadObjects.Size = new Size(131, 40);
            btnReadObjects.TabIndex = 0;
            btnReadObjects.Text = "Read Objects";
            btnReadObjects.UseVisualStyleBackColor = true;
            btnReadObjects.Click += btnReadObjects_Click;
            // 
            // splitter1
            // 
            splitter1.BackColor = SystemColors.ControlDark;
            splitter1.Location = new Point(464, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(5, 450);
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
            tvTypes.Size = new Size(464, 248);
            tvTypes.TabIndex = 3;
            // 
            // btnGetProperties
            // 
            btnGetProperties.Location = new Point(6, 58);
            btnGetProperties.Name = "btnGetProperties";
            btnGetProperties.Size = new Size(131, 40);
            btnGetProperties.TabIndex = 4;
            btnGetProperties.Text = "Get Properties";
            btnGetProperties.UseVisualStyleBackColor = true;
            btnGetProperties.Click += btnGetProperties_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Left;
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
            splitContainer1.Panel2.Controls.Add(lbProperties);
            splitContainer1.Size = new Size(464, 450);
            splitContainer1.SplitterDistance = 248;
            splitContainer1.TabIndex = 5;
            // 
            // lbProperties
            // 
            lbProperties.BorderStyle = BorderStyle.None;
            lbProperties.Dock = DockStyle.Fill;
            lbProperties.FormattingEnabled = true;
            lbProperties.Location = new Point(0, 0);
            lbProperties.Name = "lbProperties";
            lbProperties.Size = new Size(464, 198);
            lbProperties.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtJsonResult);
            panel1.Controls.Add(btnConvertToJson);
            panel1.Controls.Add(btnExpandAll);
            panel1.Controls.Add(btnReadObjects);
            panel1.Controls.Add(btnGetProperties);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(469, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 450);
            panel1.TabIndex = 6;
            // 
            // txtJsonResult
            // 
            txtJsonResult.Dock = DockStyle.Bottom;
            txtJsonResult.Location = new Point(0, 277);
            txtJsonResult.Multiline = true;
            txtJsonResult.Name = "txtJsonResult";
            txtJsonResult.ScrollBars = ScrollBars.Horizontal;
            txtJsonResult.Size = new Size(331, 173);
            txtJsonResult.TabIndex = 7;
            // 
            // btnConvertToJson
            // 
            btnConvertToJson.Location = new Point(6, 104);
            btnConvertToJson.Name = "btnConvertToJson";
            btnConvertToJson.Size = new Size(131, 40);
            btnConvertToJson.TabIndex = 6;
            btnConvertToJson.Text = "Convert To Json";
            btnConvertToJson.UseVisualStyleBackColor = true;
            btnConvertToJson.Click += btnConvertToJson_Click;
            // 
            // btnExpandAll
            // 
            btnExpandAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExpandAll.Location = new Point(233, 12);
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
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(splitter1);
            Controls.Add(splitContainer1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Class To Json";
            WindowState = FormWindowState.Maximized;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnReadObjects;
        private Splitter splitter1;
        private TreeView tvTypes;
        private Button btnGetProperties;
        private SplitContainer splitContainer1;
        private CheckedListBox lbProperties;
        private Panel panel1;
        private Button btnExpandAll;
        private Button btnConvertToJson;
        private TextBox txtJsonResult;
    }
}