using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Zen.WinXL.XmlControls
{
    /// <summary>
    /// Summary description for XmlTreeView.
    /// </summary>
    [ToolboxBitmap(typeof (XmlTreeView), "Ux.WinForms.XmlControls.XmlTreeView.bmp")]
    public class XmlTreeView : UserControl
    {
        public const string MessageBoxTitle = "XmlTreeView";
        
        public XmlTreeView()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        private IXmlControl xmlControl;

        internal string filePath = string.Empty;
        internal string fileXml = string.Empty;
        private string content = string.Empty;
        private ContextMenu popUpMenu;
        private MenuItem copyMenuItem;
        private MenuItem pasteMenuItem;
        private MenuItem editMenuItem;
        private MenuItem deleteMenuItem;
        private MenuItem printMenuItem;
        private MenuItem saveMenuItem;
        private MenuItem searchMenuItem;        
        private PrintDialog printDialog1;        
        private SaveFileDialog saveFileDialog1;
        
                
        /// <summary>
        /// gets or sets XML-data in a string form.
        /// </summary>
        public string Xml
        {
            get
            {
                var result = string.Empty;

                if (Controls.Count > 0)
                {
                    result = ((IXmlControl) Controls[0]).Xml;
                }

                return result;
            }
            set
            {
                Controls.Clear();

                try
                {
                    DeregisterEvents(xmlControl);

                    xmlControl = new InnerXmlTreeView(this);
                    xmlControl.Xml = value;
                    content = xmlControl.Xml;

                    RegisterEvents(xmlControl);
                }
                catch
                {
                    Controls.Clear();

                    DeregisterEvents(xmlControl);

                    MessageBox.Show("Invalid XML-data !", MessageBoxTitle);
                    xmlControl = new InnerTextBox(this);
                    xmlControl.Xml = value;

                    RegisterEvents(xmlControl);
                }

                ((Control) xmlControl).ContextMenu = this.popUpMenu;

                Controls.Add((Control) xmlControl);
            }
        }

        /// <summary>
        /// gets or sets the fully qualified path to a file containing XML-data.
        /// </summary>
        public string XmlFile
        {
            get
            {
                if (fileXml != Xml)
                {
                    filePath = string.Empty;
                }

                return filePath;
            }

            set
            {
                if (null != value && value.Length > 0)
                {
                    using (var fs = new StreamReader(value))
                    {
                        fileXml = fs.ReadToEnd();
                        Xml = fileXml;
                        filePath = value;
                    }
                }
            }
        }

        [DefaultValue(true)]
        public bool LabelEdit
        {
            get { return deleteMenuItem.Enabled && editMenuItem.Enabled; }
            set { editMenuItem.Enabled = deleteMenuItem.Enabled = value; }
        }

        internal PrintDialog PrintDialog
        {
            get { return printDialog1; }
        }

        internal SaveFileDialog SaveDialog
        {
            get { return saveFileDialog1; }
        }

        
        private void RegisterEvents(IXmlControl control)
        {
            if (null != control)
            {
                this.printMenuItem.Click += control.Print;
                this.searchMenuItem.Click += control.Search;
                this.deleteMenuItem.Click += control.Delete;
                this.saveMenuItem.Click += control.Save;
                this.pasteMenuItem.Click += control.Paste;
                this.copyMenuItem.Click += control.Copy;
                this.editMenuItem.Click += control.Edit;
                this.printDialog1.Document = control.PrintDocument;
                this.printDialog1.Document.PrintPage += control.PrintPage;
            }
        }

        private void DeregisterEvents(IXmlControl control)
        {
            if (null != control)
            {
                this.printMenuItem.Click -= control.Print;
                this.searchMenuItem.Click -= control.Search;
                this.deleteMenuItem.Click -= control.Delete;
                this.saveMenuItem.Click -= control.Save;
                this.pasteMenuItem.Click -= control.Paste;
                this.copyMenuItem.Click -= control.Copy;
                this.editMenuItem.Click -= control.Edit;
                this.printDialog1.Document.PrintPage -= control.PrintPage;
            }
        }

        internal void form_Closing(object sender, CancelEventArgs e)
        {
            if (!content.Equals(Xml))
            {
                if (
                    MessageBox.Show("Save changes?", MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (var sw = new StreamWriter(saveFileDialog1.FileName))
                        {
                            sw.Write(Xml);
                        }
                    }
                }
            }
        }


        #region Designer support

        private readonly Container components = null;

        private void InitializeComponent()
        {
            this.popUpMenu = new System.Windows.Forms.ContextMenu();
            this.printMenuItem = new System.Windows.Forms.MenuItem();
            this.searchMenuItem = new System.Windows.Forms.MenuItem();
            this.deleteMenuItem = new System.Windows.Forms.MenuItem();
            this.saveMenuItem = new System.Windows.Forms.MenuItem();
            this.pasteMenuItem = new System.Windows.Forms.MenuItem();
            this.copyMenuItem = new System.Windows.Forms.MenuItem();
            this.editMenuItem = new System.Windows.Forms.MenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // popUpMenu
            // 
            this.popUpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[]
                                                  {
                                                      this.printMenuItem,
                                                      this.searchMenuItem,
                                                      this.deleteMenuItem,
                                                      this.saveMenuItem,
                                                      this.pasteMenuItem,
                                                      this.copyMenuItem,
                                                      this.editMenuItem
                                                  });
            // 
            // printMenuItem
            // 
            this.printMenuItem.Index = 0;
            this.printMenuItem.Text = "&Print";
            // 
            // searchMenuItem
            // 
            this.searchMenuItem.Index = 1;
            this.searchMenuItem.Text = "&Search";
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Index = 2;
            this.deleteMenuItem.Text = "&Delete";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Index = 3;
            this.saveMenuItem.Text = "S&ave As...";
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Index = 4;
            this.pasteMenuItem.Text = "Past&e";
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Index = 5;
            this.copyMenuItem.Text = "&Copy";
            // 
            // editMenuItem
            // 
            this.editMenuItem.Index = 6;
            this.editMenuItem.Text = "Ed&it";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML-Files|*.xml";

            this.Name = "XmlTreeView";
            this.Size = new System.Drawing.Size(150, 130);
            this.ResumeLayout(false);
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