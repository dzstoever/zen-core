using System;
using System.Drawing.Printing;

namespace Zen.Examples.XmlControls
{
    /// <summary>
    /// Summary description for IXmlControl.
    /// </summary>
    internal interface IXmlControl
    {
        PrintDocument PrintDocument { get; }
        string Xml { get; set; }

        void Copy(object sender, EventArgs e);
        void Paste(object sender, EventArgs e);
        void Edit(object sender, EventArgs e);
        void Delete(object sender, EventArgs e);
        void PrintPage(object sender, PrintPageEventArgs e);
        void Print(object sender, EventArgs e);        
        void Save(object sender, EventArgs e);
        void Search(object sender, EventArgs e);        
        void StartSearch(string criterion, bool caseSensitive);
        void Next();
    }
}