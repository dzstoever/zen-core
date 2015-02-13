using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Zen.Examples.XmlControls
{
    public partial class XmlForm : Form
    {
        public static void Show(string xmlFilePath)
        {
            bool fileExists;
            var form = CreateXmlForm(xmlFilePath, out fileExists);
            if (fileExists) form.Show();
        }

        public static void ShowDialog(string xmlFilePath)
        {
            bool fileExists;
            var form = CreateXmlForm(xmlFilePath, out fileExists);
            if (fileExists) form.ShowDialog();
        }

        private static Form CreateXmlForm(string xmlFilePath, out bool fileExists)
        {
            fileExists = File.Exists(xmlFilePath);
            if (fileExists)
            {
                var fileInfo = new FileInfo(xmlFilePath);
                return new XmlForm(xmlFilePath) { Text = fileInfo.Name };
            }
            return new XmlForm() { Text = "File not found!" };
        }


        public string XmlFilePath 
        { 
            get { return _xmlTreeView.XmlFile; } 
            set 
            {
                FilePathGroupBox.Visible = true;
                FilePathLabel.Text = value;
                _xmlTreeView.XmlFile = value; 
            } 
        }

        public XmlTreeView XmlTreeView { get { return _xmlTreeView; } }
        XmlTreeView _xmlTreeView = new XmlTreeView();
        
        public XmlForm()
        {
            InitializeComponent();
            InitTreeView();
                    
        }
        public XmlForm(string xmlFilePath)
        {
            InitializeComponent();
            InitTreeView();
            XmlFilePath = xmlFilePath;
        }

        private void InitTreeView()
        {
            SuspendLayout();
            _xmlTreeView.Dock = DockStyle.Fill;
            panel1.Controls.Add(_xmlTreeView);
            ResumeLayout(false);
        }

        private void OpenContainingFolderButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(FilePathLabel.Text)) return;
            var fileInfo = new FileInfo(FilePathLabel.Text);
            if (fileInfo.Exists)
                Process.Start(fileInfo.Directory.FullName);
            else MessageBox.Show("Directory does not exist!");            
        }


    }
}
