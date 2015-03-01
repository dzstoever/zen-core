using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Zen.WinXL.XmlControls
{
    /// <summary>
    /// Summary description for InnerTextBox.
    /// </summary>
    internal class InnerTextBox : TextBox, IXmlControl
    {
        internal InnerTextBox(XmlTreeView container)
        {
            parent = container;
            ReadOnly = true;
            Multiline = true;
            Dock = DockStyle.Fill;
            ScrollBars = ScrollBars.Both;
        }

        private readonly XmlTreeView parent;
        private readonly Font printFont = new Font("Consolas", 8);
        private readonly PrintDocument printDocument1 = new PrintDocument();
        
        private bool caseSensitive;
        private bool closingHandlerAssigned;
        private string criterion;
        private string draggedFile = string.Empty;
        private float fontHeight;
        private float linesPerPage;
        private int printableWidth;
        private int startPos;
        private int xPos;

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            if (draggedFile.Length > 0)
            {
                using (var fs = new StreamReader(draggedFile))
                {
                    parent.fileXml = fs.ReadToEnd();
                    parent.Xml = parent.fileXml;
                    parent.filePath = draggedFile;
                }

                draggedFile = string.Empty;
            }
        }
        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                draggedFile = (string) ((object[]) e.Data.GetData(DataFormats.FileDrop))[0];
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.Control && e.KeyCode == Keys.C)
            {
                Copy(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                Paste(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                Search(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {
                Print(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save(null, null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                Delete(null, null);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                Edit(null, null);
            }
        }

        
        #region IXmlControl Members

        public PrintDocument PrintDocument
        {
            get { return printDocument1; }
        }

        public string Xml
        {
            get { return Text; }
            set { Text = value; }
        }


        public void Copy(object sender, EventArgs e)
        {
            Copy();
        }

        public void Paste(object sender, EventArgs e)
        {
            var dataObject = Clipboard.GetDataObject();

            if (dataObject.GetDataPresent(DataFormats.Text))
            {
                parent.Xml = (string)dataObject.GetData(DataFormats.Text);
            }
        }

        public void Edit(object sender, EventArgs e)
        {
            if (!closingHandlerAssigned)
            {
                var parentForm = FindForm();
                parentForm.Closing += parent.form_Closing;
                closingHandlerAssigned = true;
            }

            ReadOnly = false;
        }

        public void Delete(object sender, EventArgs e)
        {
            Text = Text.Remove(SelectionStart, SelectionLength);
        }

        public void PrintPage(object sender, PrintPageEventArgs e)
        {
            var linesPrinted = 0;
            float yPos = 0;
            var endOfPageReached = false;
            var textToDraw = string.Empty;

            if (fontHeight == 0.0)
            {
                // nothing initialized yet
                fontHeight = printFont.GetHeight(e.Graphics);
                linesPerPage = e.MarginBounds.Height / fontHeight;
                printableWidth = Text.Length /
                                 ((int)(e.Graphics.MeasureString(Text, printFont).Width / e.MarginBounds.Width));
            }

            do
            {
                if (xPos < Text.Length - 1)
                {
                    textToDraw = xPos + printableWidth < Text.Length - 1
                                     ? Text.Substring(xPos, printableWidth)
                                     : Text.Substring(xPos);
                    e.Graphics.DrawString(textToDraw, printFont, Brushes.Black, e.MarginBounds.Left, yPos,
                                          new StringFormat());
                    yPos += fontHeight;
                    xPos += printableWidth;
                    ++linesPrinted;
                }

                if (xPos >= Text.Length || linesPrinted >= linesPerPage)
                {
                    endOfPageReached = true;
                }
            } while (textToDraw.Length > 0 && !endOfPageReached);

            e.HasMorePages = (xPos < Text.Length - 1);
        }

        public void Print(object sender, EventArgs e)
        {
            if (Text.Length > 0 && parent.PrintDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        public void Save(object sender, EventArgs e)
        {
            if (Text.Length > 0 && parent.SaveDialog.ShowDialog() == DialogResult.OK)
            {
                using (var sw = new StreamWriter(parent.SaveDialog.FileName))
                {
                    sw.Write(Xml);
                    parent.fileXml = Xml;
                    parent.filePath = parent.SaveDialog.FileName;
                }
            }
        }

        public void Search(object sender, EventArgs e)
        {
            if (Text.Length > 0)
            {
                new SearchDlg(this).Show();
            }
        }

        public void StartSearch(string criterion, bool caseSensitive)
        {
            startPos = 0;
            this.caseSensitive = caseSensitive;
            this.criterion = caseSensitive ? criterion : criterion.ToUpper();
        }

        public void Next()
        {
            var foundPos = 0;
            SelectionLength = 0;
            var internalText = caseSensitive ? Text : Text.ToUpper();

            if (internalText.Length > 0)
            {
                if ((foundPos = internalText.IndexOf(criterion, startPos)) > -1)
                {
                    SelectionStart = foundPos;
                    SelectionLength = criterion.Length;
                    startPos = foundPos + criterion.Length;
                    Focus();
                }
                else
                {
                    MessageBox.Show("End of text reached !", XmlTreeView.MessageBoxTitle);
                    startPos = 0;
                }
            }
        }
        
        #endregion

    }
}