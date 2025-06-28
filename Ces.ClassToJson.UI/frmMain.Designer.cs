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
            lbTypes = new CheckedListBox();
            SuspendLayout();
            // 
            // btnReadObjects
            // 
            btnReadObjects.Location = new Point(347, 48);
            btnReadObjects.Name = "btnReadObjects";
            btnReadObjects.Size = new Size(155, 23);
            btnReadObjects.TabIndex = 0;
            btnReadObjects.Text = "Read Objects";
            btnReadObjects.UseVisualStyleBackColor = true;
            btnReadObjects.Click += btnReadObjects_Click;
            // 
            // lbTypes
            // 
            lbTypes.FormattingEnabled = true;
            lbTypes.Location = new Point(12, 24);
            lbTypes.Name = "lbTypes";
            lbTypes.Size = new Size(281, 364);
            lbTypes.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbTypes);
            Controls.Add(btnReadObjects);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Class To Json";
            ResumeLayout(false);
        }

        #endregion

        private Button btnReadObjects;
        private CheckedListBox lbTypes;
    }
}