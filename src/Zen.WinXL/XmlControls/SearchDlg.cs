using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zen.WinXL.XmlControls
{
    /// <summary>
    /// Summary description for SearchDlg.
    /// </summary>
    internal class SearchDlg : Form
    {
        internal SearchDlg(IXmlControl iterator)
        {
            this.iterator = iterator;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            searchTextBox.Focus();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        
        
        private readonly IXmlControl iterator;
        private Button goBtn;
        private Button cancelBtn;
        private RadioButton caseInsensitiveRBtn;
        private RadioButton caseSensitiveRBtn;                
        private TextBox searchTextBox;
        private Label label1;


        private void goBtn_Click(object sender, EventArgs e)
        {
            iterator.Next();
            searchTextBox.Focus();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void caseSensitiveRBtn_CheckedChanged(object sender, EventArgs e)
        {
            iterator.StartSearch(searchTextBox.Text, caseSensitiveRBtn.Checked);
        }

        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                goBtn_Click(null, null);
            }
        }
        
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            iterator.StartSearch(searchTextBox.Text, caseSensitiveRBtn.Checked);
        }


        #region Designer support

        private readonly Container components = null;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchDlg));
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.caseSensitiveRBtn = new System.Windows.Forms.RadioButton();
            this.caseInsensitiveRBtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(24, 24);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(240, 20);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyUp);
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(48, 80);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 23);
            this.goBtn.TabIndex = 1;
            this.goBtn.Text = "Go !";
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(168, 80);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search for :";
            // 
            // caseSensitiveRBtn
            // 
            this.caseSensitiveRBtn.Location = new System.Drawing.Point(154, 48);
            this.caseSensitiveRBtn.Name = "caseSensitiveRBtn";
            this.caseSensitiveRBtn.Size = new System.Drawing.Size(104, 24);
            this.caseSensitiveRBtn.TabIndex = 4;
            this.caseSensitiveRBtn.Text = "case sensitive";
            this.caseSensitiveRBtn.CheckedChanged += new System.EventHandler(this.caseSensitiveRBtn_CheckedChanged);
            // 
            // caseInsensitiveRBtn
            // 
            this.caseInsensitiveRBtn.Checked = true;
            this.caseInsensitiveRBtn.Location = new System.Drawing.Point(30, 48);
            this.caseInsensitiveRBtn.Name = "caseInsensitiveRBtn";
            this.caseInsensitiveRBtn.Size = new System.Drawing.Size(104, 24);
            this.caseInsensitiveRBtn.TabIndex = 5;
            this.caseInsensitiveRBtn.TabStop = true;
            this.caseInsensitiveRBtn.Text = "case insensitive";
            // 
            // SearchDlg
            // 
            this.AcceptButton = this.goBtn;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(288, 118);
            this.Controls.Add(this.caseInsensitiveRBtn);
            this.Controls.Add(this.caseSensitiveRBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.searchTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(296, 152);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(296, 152);
            this.Name = "SearchDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}