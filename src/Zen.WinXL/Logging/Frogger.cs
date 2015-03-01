using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zen.Log;
using XmlForm = Zen.WinXL.XmlControls.XmlForm;

namespace Zen.WinXL.Logging
{

    public partial class Frogger : Form
    {
        public ILogger Logger { get; set; }

        public Frogger()
        {
            InitializeComponent();

            // Note: class level logger is null here, because this form is not registered with IoC
            Logger = Aspects.GetLoggerFactory().Create(typeof(Frogger));

            RtbLog.TextChanged += RtbLog_TextChanged;// this is just for the Frogger Emoticon
            RegisterRtbAppender("|0~0| Hello, I am a Logger.");
            Logger.Debug("My name is Frogger.");

            ConfiguratorSource.DataSource = new Log4netConfiguratorModel();                        
        }
        

        private void RegisterRtbAppender(string echoMessage)
        {            
            var rtbRegistered = RtbAppender.SetRichTextBox(RtbLog, "Rtb", Color.Black, new Font("Consolas", 10.25F));
            if (rtbRegistered) Logger.Debug(echoMessage);
            RtbLog.ForeColor = Color.LimeGreen;// pasting the emoticon causes the rtb forecolor to revert to black?            
        }
        
                
        private void buttonApply_Click(object sender, EventArgs e)
        {
            var current = (Log4netConfiguratorModel)ConfiguratorSource.Current;
            current.ApplyChanges();
            RegisterRtbAppender("|0~0| Configuration changed.");
            Logger.Debug("You better test some messages.");
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            ConfiguratorSource.DataSource = new Log4netConfiguratorModel();
        }

        private void buttonShowXml_Click(object sender, EventArgs e)
        {
            var xmlForm = new XmlForm();
            xmlForm.XmlTreeView.Xml = Log4netConfigurator.Log4NetXml; // LoggingCfg.Log4NetXml;
            xmlForm.Show();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            RtbLog.Clear();
        }
        
        private void buttonLog_Click(object sender, EventArgs e)
        {
            if (!checkDebug.Checked && !checkInfo.Checked && !checkWarn.Checked && !checkError.Checked && !checkFatal.Checked)
                RtbLog.AppendText("No message level selected." + Environment.NewLine);
            if (checkDebug.Checked && checkInfo.Checked && checkWarn.Checked && checkError.Checked && checkFatal.Checked)
                Log4netConfigurator.LogAllLevelMessages(Logger);
            else
            {
                if (checkDebug.Checked) Logger.Debug("debug message");
                if (checkInfo.Checked) Logger.Info("info message");
                if (checkWarn.Checked) Logger.Warn("warn message");
                if (checkError.Checked) Logger.Error("error message");
                if (checkFatal.Checked) Logger.Fatal("fatal message");                
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filePathTextBox.Text)) return;
            var fileInfo = new FileInfo(Log4netConfigurator.FilePath);
            if (fileInfo.Exists)
                Process.Start(fileInfo.FullName);
            else MessageBox.Show("File does not exist!");
        }

        private void buttonTurnLoggerOnOff_Click(object sender, EventArgs e)
        {
            var nameNamespace = textBox1.Text;
            //Log4netConfigurator.t
            Log4netConfigurator.TurnLoggerOff(nameNamespace);
        }

        private void checkBoxTurnLoggerOnOff_CheckedChanged(object sender, EventArgs e)
        {
            buttonTurnLoggerOnOff.Text = 
                "Turn Logger {0} By Name/Namespace".FormatWith(
                checkBoxTurnLoggerOnOff.Checked ? "On" : "Off");
        }


        #region Font Dialog

        private void ChangeFontMenuItem_Click(object sender, EventArgs e)
        {
            RtbFontDialog.ShowApply = true;
            var result = RtbFontDialog.ShowDialog(this);

            if (result == DialogResult.OK) ApplyFontResult();
        }

        private void RtbFontDialog_Apply(object sender, EventArgs e)
        {
            ApplyFontResult();
        }

        private void ApplyFontResult()
        {
            var font = new Font(
                RtbFontDialog.Font.FontFamily,
                RtbFontDialog.Font.Size,
                RtbFontDialog.Font.Style);
            RtbLog.ForeColor = Color.Orange;//if not we go black
            RtbLog.Font = font;
        }

        #endregion

        #region Emoticons
        
        Hashtable _emoticons;                        
        void RtbLog_TextChanged(object sender, EventArgs e)
        {
            if (_emoticons == null)
            {
                _emoticons = new Hashtable();
                //_emoticons.Add("|0~0|", Properties.Resources.zen_frog.ToBitmap());
                //_emoticons.Add("|:o)|", Zen.Examples.Properties.Resources.silverback.ToBitmap());
                //_emoticons.Add("|~~~|", Zen.Examples.Properties.Resources.pcs_logo.ToBitmap());                
                
            }
            var foreColor = RtbLog.ForeColor;
            foreach (string key in _emoticons.Keys)                
                while (RtbLog.Text.Contains(key))
                {
                    RtbLog.Select(RtbLog.Text.IndexOf(key), key.Length);
                    Clipboard.SetImage((Image)_emoticons[key]);
                    RtbLog.ReadOnly = false;
                    RtbLog.Paste();
                    RtbLog.ReadOnly = true;
                }

            RtbLog.ForeColor = foreColor;
        }
        
        #endregion        

        
    }
}
