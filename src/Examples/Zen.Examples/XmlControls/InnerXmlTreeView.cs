using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Zen.Examples.XmlControls
{
    /// <summary>
    /// Summary description for InnerXmlTreeView.
    /// </summary>
    internal class InnerXmlTreeView : TreeView, IXmlControl
    {
        private static TreeNode CurrentNode;

        public InnerXmlTreeView(XmlTreeView container)
        {
            parent = container;
            AllowDrop = true;
            Dock = DockStyle.Fill;
            ImageIndex = -1;
            SelectedImageIndex = -1;
            Size = new Size(150, 130);
            TabIndex = 0;
            document = new XmlDocument();
            ShowLines = false;
        }

        private readonly XmlTreeView parent;        
        private readonly XmlDocument document;
        private readonly ArrayList foundList = new ArrayList(100);
        private TextBox editBox;        
        private XmlTreeNode editingNode;
        
        private int count;
        private bool closingHandlerAssigned;
        private bool caseSensitive;
        private bool foundNode;        
        private string indent = string.Empty;
        private string draggedFile = string.Empty;
        private string searchText;

        private readonly Font printFont = new Font("Arial", 10);
        private readonly ArrayList printedNodes = new ArrayList(1000);
        private readonly PrintDocument printDocument1 = new PrintDocument();        
        private PrintPageEventArgs eventArgs;
        private bool endOfPageReached;
        private float linesPerPage;
        private float leftMargin;
        private float topMargin;
        private float yPos;

        
        private void LoadXml(string xml)
        {
            SuspendLayout();
            document.LoadXml(xml);

            Nodes.Clear();

            if (xml.StartsWith("<?"))
            {
                Nodes.Add(new XmlTreeNode(xml.Substring(0, xml.IndexOf("?>") + 2), null));
            }

            RecurseAndAssignNodes(document.DocumentElement);

            ExpandAll();
            ResumeLayout(false);
        }

        private void RecurseAndAssignNodes(XmlNode elem)
        {
            var attrs = string.Empty;
            XmlTreeNode addedNode = null;

            if (elem.NodeType == XmlNodeType.Element)
            {
                foreach (XmlAttribute attr in elem.Attributes)
                {
                    attrs += " " + attr.Name + "=\"" + attr.Value + "\"";
                }
            }

            if (elem.Equals(document.DocumentElement))
            {
                addedNode = new XmlTreeNode("<" + elem.Name + attrs + ">", elem);
                Nodes.Add(addedNode);
                CurrentNode = addedNode;
                Nodes.Add(new XmlTreeNode("</" + elem.Name + ">", null));
            }
            else if (elem.HasChildNodes && elem.ChildNodes[0].NodeType == XmlNodeType.Text)
            {
                addedNode = new XmlTreeNode("<" + elem.Name + attrs + ">" + elem.InnerText + "</" + elem.Name + ">",
                                            elem);
                CurrentNode.Nodes.Add(addedNode);
                CurrentNode = addedNode;
            }
            else if (elem is XmlElement && ((XmlElement) elem).IsEmpty)
            {
                addedNode = new XmlTreeNode("<" + elem.Name + attrs + "/>", elem);
                CurrentNode.Nodes.Add(addedNode);
                CurrentNode = addedNode;
            }
            else
            {
                addedNode = new XmlTreeNode("<" + elem.Name + attrs + ">", elem);
                CurrentNode.Nodes.Add(addedNode);
                CurrentNode = addedNode;
                CurrentNode.Parent.Nodes.Add(new XmlTreeNode("</" + elem.Name + ">", null));
            }

            foreach (XmlNode child in elem.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element)
                {
                    RecurseAndAssignNodes(child);
                }
                else if (child.NodeType == XmlNodeType.Comment)
                {
                    CurrentNode.Nodes.Add(new XmlTreeNode(child.OuterXml, child));
                }
            }

            if (CurrentNode.Parent != null)
            {
                CurrentNode = CurrentNode.Parent;
            }
        }

        private void RecurseTreeNodes(TreeNodeCollection nodes)
        {
            if (!foundNode)
            {
                string nodeText = null;

                foreach (TreeNode node in nodes)
                {
                    if (foundNode)
                    {
                        break;
                    }

                    nodeText = caseSensitive ? node.Text : node.Text.ToUpper();

                    if (nodeText.IndexOf(searchText) > -1 && !foundList.Contains(node))
                    {
                        SelectedNode = node;
                        SelectedNode.BackColor = Color.Blue;
                        foundList.Add(node);
                        foundNode = true;
                        break;
                    }

                    if (node.Nodes.Count > 0)
                    {
                        RecurseTreeNodes(node.Nodes);
                    }
                }
            }
        }

        private void RecursePrintTreeNodes(TreeNodeCollection coll)
        {
            if (!endOfPageReached)
            {
                foreach (TreeNode node in coll)
                {
                    if (endOfPageReached)
                    {
                        break;
                    }

                    if (!printedNodes.Contains(node))
                    {
                        var textToDraw = indent + node.Text;
                        float textWidthPx = 0;

                        yPos = topMargin + (count*printFont.GetHeight());

                        if ((textWidthPx = eventArgs.Graphics.MeasureString(textToDraw, printFont).Width) >
                            eventArgs.MarginBounds.Width)
                        {
                            var startPos = 0;
                            var pixPerChar = textWidthPx/textToDraw.Length;
                            var maxCharsPerLine = (int) (eventArgs.MarginBounds.Width/pixPerChar);

                            while ((startPos + maxCharsPerLine) < textToDraw.Length)
                            {
                                eventArgs.Graphics.DrawString(textToDraw.Substring(startPos, maxCharsPerLine), printFont,
                                                              Brushes.Black, leftMargin, yPos, new StringFormat());
                                startPos += maxCharsPerLine;
                                yPos += printFont.GetHeight();
                                ++count;
                            }

                            eventArgs.Graphics.DrawString(textToDraw.Substring(startPos), printFont, Brushes.Black,
                                                          leftMargin, yPos, new StringFormat());
                        }
                        else
                        {
                            eventArgs.Graphics.DrawString(textToDraw, printFont, Brushes.Black, leftMargin, yPos,
                                                          new StringFormat());
                        }

                        ++count;
                        printedNodes.Add(node);
                    }

                    if (endOfPageReached = (count >= linesPerPage))
                    {
                        eventArgs.HasMorePages = true;
                        break;
                    }

                    if (node.Nodes.Count > 0)
                    {
                        indent += "    ";
                        RecursePrintTreeNodes(node.Nodes);
                    }
                }
            }

            if (indent.Length > 0)
            {
                indent = indent.Substring(0, indent.Length - 4);
            }
        }
        
        private void editBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                editBox.Leave -= editBox_Leave;
                editBox.KeyUp -= editBox_KeyUp;
                Controls.Remove(editBox);
                editBox.Dispose();
            }
        }
        
        private void editBox_Leave(object sender, EventArgs e)
        {
            if (Controls.Contains(editBox))
            {
                editBox.Leave -= editBox_Leave;
                editBox.KeyUp -= editBox_KeyUp;
                Controls.Remove(editBox);
                editingNode.Text = editBox.Text;
                editBox.Dispose();
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (SelectedNode.Parent != null && ((XmlTreeNode)SelectedNode).ConnectedXmlElement != null)
            {
                Edit(null, null);
            }
            else
            {
                MessageBox.Show("Sorry, cannot edit this node !", XmlTreeView.MessageBoxTitle);
            }
        }
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
                draggedFile = (string)((object[])e.Data.GetData(DataFormats.FileDrop))[0];
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
            get { return document.OuterXml; }
            set
            {
                if (value.Length > 0)
                {
                    LoadXml(value);
                }
            }
        }


        public void Copy(object sender, EventArgs e)
        {
            if (Nodes.Count > 0)
            {
                Clipboard.SetDataObject(Xml, true);
            }
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
            if (Nodes.Count > 0 && SelectedNode != null && parent.LabelEdit)
            {
                editingNode = (XmlTreeNode)SelectedNode;

                if (editingNode.ConnectedXmlElement != null)
                {
                    if (!closingHandlerAssigned)
                    {
                        var parentForm = FindForm();
                        parentForm.Closing += parent.form_Closing;
                        closingHandlerAssigned = true;
                    }

                    var height = editingNode.Bounds.Height;
                    var width = editingNode.Bounds.Width;
                    var left = editingNode.Bounds.Left;
                    var top = editingNode.Bounds.Top;

                    editingNode.ExpandAll();

                    if (editingNode.ConnectedXmlElement.HasChildNodes &&
                        editingNode.ConnectedXmlElement.FirstChild.NodeType != XmlNodeType.Text)
                    {
                        height = editingNode.NextNode.Bounds.Bottom - editingNode.Bounds.Top;
                        width = Width - left;
                    }

                    editBox = new TextBox();
                    editBox.Multiline = true;
                    editBox.BorderStyle = BorderStyle.FixedSingle;
                    editBox.ScrollBars = ScrollBars.Both;
                    editBox.Leave += editBox_Leave;
                    editBox.KeyUp += editBox_KeyUp;
                    editBox.SetBounds(left, top, width, height);
                    editingNode.RecurseSubNodes(editingNode.Parent);
                    editBox.Text = editingNode.SelfAndChildren;
                    Controls.Add(editBox);
                    editBox.Focus();
                }
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            if (Nodes.Count > 0 && null != SelectedNode && parent.LabelEdit)
            {
                var tmp = Xml;

                try
                {
                    var elemToRemove = ((XmlTreeNode)SelectedNode).ConnectedXmlElement;

                    if (null != elemToRemove)
                    {
                        elemToRemove.ParentNode.RemoveChild(elemToRemove);

                        if (SelectedNode.NextNode.Text.Equals("</" + elemToRemove.Name + ">"))
                        {
                            SelectedNode.NextNode.Remove();
                        }

                        SelectedNode.Remove();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete this node ! Rolling back...", XmlTreeView.MessageBoxTitle);
                    parent.Xml = tmp;
                }
            }
        }

        public void PrintPage(object sender, PrintPageEventArgs e)
        {
            yPos = 0;
            count = 0;
            endOfPageReached = false;
            eventArgs = e;
            eventArgs.HasMorePages = false;
            leftMargin = eventArgs.MarginBounds.Left;
            topMargin = eventArgs.MarginBounds.Top;
            linesPerPage = eventArgs.MarginBounds.Height / printFont.GetHeight(eventArgs.Graphics);

            // Iterate over the file, printing each line.
            RecursePrintTreeNodes(Nodes);
        }

        public void Print(object sender, EventArgs e)
        {
            if (Nodes.Count > 0 && parent.PrintDialog.ShowDialog() == DialogResult.OK)
            {
                printedNodes.Clear();
                printDocument1.Print();
            }
        }

        public void Save(object sender, EventArgs e)
        {
            if (Nodes.Count > 0 && parent.SaveDialog.ShowDialog() == DialogResult.OK)
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
            if (Nodes.Count > 0)
            {
                new SearchDlg(this).Show();
            }
        }

        public void StartSearch(string criterion, bool caseSensitive)
        {
            foundList.Clear();
            this.caseSensitive = caseSensitive;
            searchText = caseSensitive ? criterion : criterion.ToUpper();
        }

        public void Next()
        {
            SelectedNode.BackColor = Color.Empty;
            foundNode = false;

            RecurseTreeNodes(Nodes);

            if (!foundNode)
            {
                MessageBox.Show("End of tree reached !", XmlTreeView.MessageBoxTitle);
                foundList.Clear();
            }
        }
        
        #endregion
    }
}