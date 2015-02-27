using System;
using System.Windows.Forms;
using System.Xml;

namespace Zen.Examples.XmlControls
{
    /// <summary>
    /// Summary description for XmlTreeNode.
    /// </summary>
    internal class XmlTreeNode : TreeNode
    {
        internal XmlTreeNode(string text, XmlNode elem) : base(text)
        { this.elem = elem; }


        public new string Text
        {
            get { return base.Text; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    try
                    {
                        if (value != childrenXml)
                        {
                            var frag = elem.OwnerDocument.CreateDocumentFragment();
                            frag.InnerXml = value;
                            elem.ParentNode.ReplaceChild(frag, elem);
                            var innerView = (InnerXmlTreeView) TreeView;
                            innerView.Xml = innerView.Xml;
                        }
                    }
                    catch (XmlException xEx)
                    {
                        MessageBox.Show(xEx.Message, XmlTreeView.MessageBoxTitle);
                    }
                    finally
                    {
                        childrenXml = string.Empty;
                        hitEnd = false;
                    }
                }
            }
        }

        internal string SelfAndChildren
        { get { return childrenXml; } }
        private string childrenXml = string.Empty;

        internal XmlNode ConnectedXmlElement
        {
            get { return elem; }
        }
        private readonly XmlNode elem;

        private string indent = string.Empty;
        private bool hitStart;
        private bool hitEnd;                

        internal void RecurseSubNodes(TreeNode entryNode)
        {
            foreach (TreeNode node in entryNode.Nodes)
            {
                if (this.Equals(node))
                {
                    hitStart = true;
                }

                if (!hitEnd && hitStart)
                {
                    hitEnd = (node.Text.EndsWith("</" + elem.Name + ">") && hitStart) ||
                             (((XmlTreeNode) node).ConnectedXmlElement != null &&
                              ((XmlTreeNode) node).ConnectedXmlElement.NodeType == XmlNodeType.Comment);

                    childrenXml += indent + node.Text + Environment.NewLine;

                    if (node.Nodes.Count > 0)
                    {
                        indent += "    ";
                        RecurseSubNodes(node);
                    }
                }
            }

            if (indent.Length > 3)
            {
                indent = indent.Substring(0, indent.Length - 4);
            }
        }

    }
}