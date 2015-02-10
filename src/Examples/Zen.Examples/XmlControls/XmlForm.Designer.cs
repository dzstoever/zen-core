namespace Zen.Examples.XmlControls
{
    partial class XmlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlForm));
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.FilePathGroupBox = new System.Windows.Forms.GroupBox();
            this.OpenContainingFolderButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FilePathGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilePathLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FilePathLabel.Location = new System.Drawing.Point(3, 16);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(458, 32);
            this.FilePathLabel.TabIndex = 0;
            this.FilePathLabel.Text = "FilePathLabel";
            // 
            // FilePathGroupBox
            // 
            this.FilePathGroupBox.Controls.Add(this.OpenContainingFolderButton);
            this.FilePathGroupBox.Controls.Add(this.FilePathLabel);
            this.FilePathGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilePathGroupBox.Location = new System.Drawing.Point(10, 10);
            this.FilePathGroupBox.Name = "FilePathGroupBox";
            this.FilePathGroupBox.Size = new System.Drawing.Size(464, 51);
            this.FilePathGroupBox.TabIndex = 1;
            this.FilePathGroupBox.TabStop = false;
            this.FilePathGroupBox.Text = "File Path";
            this.FilePathGroupBox.Visible = false;
            // 
            // OpenContainingFolderButton
            // 
            this.OpenContainingFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenContainingFolderButton.FlatAppearance.BorderSize = 0;
            this.OpenContainingFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenContainingFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenContainingFolderButton.Location = new System.Drawing.Point(338, 28);
            this.OpenContainingFolderButton.Name = "OpenContainingFolderButton";
            this.OpenContainingFolderButton.Size = new System.Drawing.Size(123, 20);
            this.OpenContainingFolderButton.TabIndex = 1;
            this.OpenContainingFolderButton.Text = "Open Containing Folder...";
            this.OpenContainingFolderButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OpenContainingFolderButton.UseVisualStyleBackColor = true;
            this.OpenContainingFolderButton.Click += new System.EventHandler(this.OpenContainingFolderButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 393);
            this.panel1.TabIndex = 2;
            // 
            // XmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 464);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FilePathGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XmlForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Xml Configuration";
            this.FilePathGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.GroupBox FilePathGroupBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OpenContainingFolderButton;
    }
}