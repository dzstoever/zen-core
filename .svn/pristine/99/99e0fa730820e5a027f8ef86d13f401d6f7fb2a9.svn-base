using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zen.Log
{
    /// <summary>
    /// This class will always return the static values from the Log4netConfigurator class
    /// but any changes will be stored in private variables here, Use for databinding, etc.
    /// </summary>
    public class Log4netConfiguratorModel
    {
        // this will actually change our logging config in a real-time situation
        // based on the dirty values we stored in our private variables
        public void ApplyChanges()
        {
            if (_consoleOnOff != null)
                Log4netConfigurator.AppendersOnOff[Appenders.Console] = _consoleOnOff.Value ? OnOff.On : OnOff.Off;
            if (_debugOnOff != null)
                Log4netConfigurator.AppendersOnOff[Appenders.Debug] = _debugOnOff.Value ? OnOff.On : OnOff.Off;
            if (_eventLogOnOff != null)
                Log4netConfigurator.AppendersOnOff[Appenders.EventLog] = _eventLogOnOff.Value ? OnOff.On : OnOff.Off;
            if (_fileOnOff != null)
                Log4netConfigurator.AppendersOnOff[Appenders.File] = _fileOnOff.Value ? OnOff.On : OnOff.Off;
            if (_rtbOnOff != null)
                Log4netConfigurator.AppendersOnOff[Appenders.Rtb] = _rtbOnOff.Value ? OnOff.On : OnOff.Off;
            if (_smtpOnOff != null)
                Log4netConfigurator.AppendersOnOff[Appenders.Smtp] = _smtpOnOff.Value ? OnOff.On : OnOff.Off;
            if (_sqlOnOff != null)
                Log4netConfigurator.AppendersOnOff[Appenders.Sql] = _sqlOnOff.Value ? OnOff.On : OnOff.Off;
            if (_traceOnOff != null)
                Log4netConfigurator.AppendersOnOff[Appenders.Trace] = _traceOnOff.Value ? OnOff.On : OnOff.Off;

            if (_rootLogLevel != null)
                Log4netConfigurator.RootLogLevel = _rootLogLevel.Value;
            if (_defaultPattern != null)
                Log4netConfigurator.DefaultPattern = _defaultPattern;
            if (_eventLogName != null)
                Log4netConfigurator.EventLogName = _eventLogName;

            if (_filePath != null)
                Log4netConfigurator.FilePath = _filePath;
            if (_fileMaxSizeKB != null)
                Log4netConfigurator.FileMaxSizeKB = _fileMaxSizeKB.Value.ToString();
            if (_fileMaxRollbacks != null)
                Log4netConfigurator.FileMaxRollbacks = _fileMaxRollbacks.Value.ToString();

            if (_smtpHost != null)
                Log4netConfigurator.SmtpHost = _smtpHost;
            if (_smtpEmailTo != null)
                Log4netConfigurator.SmtpEmailTo = _smtpEmailTo;
            if (_smtpEmailFrom != null)
                Log4netConfigurator.SmtpEmailFrom = _smtpEmailFrom;
            if (_smtpEmailSubject != null)
                Log4netConfigurator.SmtpEmailSubject = _smtpEmailSubject;

            if (_sqlCnnString != null)
                Log4netConfigurator.SqlCnnString = _sqlCnnString;
            if (_sqlProcName != null)
                Log4netConfigurator.SqlProcName = _sqlProcName;

            Aspects.GetLogger().Debug("Logging Configuration is about to change!");
            Log4netConfigurator.Configure(); //logging behavior should change NOW            
        }

        #region dirty values

        // we don't want values set in this class to change the static class values every time the setter is called
        // so we will hold dirty values here until the user choose to apply changes...
        // all values will be null unless they are dirty
        // getters will return the diry values only if they are not null, else they will return the static values
        private bool? _consoleOnOff;
        private bool? _debugOnOff;
        private bool? _eventLogOnOff;
        private bool? _fileOnOff;
        private bool? _rtbOnOff;
        private bool? _smtpOnOff;
        private bool? _sqlOnOff;
        private bool? _traceOnOff;
        private LogLevel? _rootLogLevel;
        private string _defaultPattern;
        private string _eventLogName;
        private string _filePath;
        private int? _fileMaxSizeKB;
        private int? _fileMaxRollbacks;
        private string _smtpHost;
        private string _smtpEmailTo;
        private string _smtpEmailFrom;
        private string _smtpEmailSubject;
        private string _sqlCnnString;
        private string _sqlProcName;
        #endregion


        public bool ConsoleOnOff
        {
            get { return _consoleOnOff ?? Log4netConfigurator.AppendersOnOff[Appenders.Console] == OnOff.On; }
            set { _consoleOnOff = value; }
        }
        public bool DebugOnOff
        {
            get { return _debugOnOff ?? Log4netConfigurator.AppendersOnOff[Appenders.Debug] == OnOff.On; }
            set { _debugOnOff = value; }
        }
        public bool EventLogOnOff
        {
            get { return _eventLogOnOff ?? Log4netConfigurator.AppendersOnOff[Appenders.EventLog] == OnOff.On; }
            set { _eventLogOnOff = value; }
        }
        public bool FileOnOff
        {
            get { return _fileOnOff ?? Log4netConfigurator.AppendersOnOff[Appenders.File] == OnOff.On; }
            set { _fileOnOff = value; }
        }
        public bool RtbOnOff
        {
            get { return _rtbOnOff ?? Log4netConfigurator.AppendersOnOff[Appenders.Rtb] == OnOff.On; }
            set { _rtbOnOff = value; }
        }
        public bool SmtpOnOff
        {
            get { return _smtpOnOff ?? Log4netConfigurator.AppendersOnOff[Appenders.Smtp] == OnOff.On; }
            set { _smtpOnOff = value; }
        }
        public bool SqlOnOff
        {
            get { return _sqlOnOff ?? Log4netConfigurator.AppendersOnOff[Appenders.Sql] == OnOff.On; }
            set { _sqlOnOff = value; }
        }
        public bool TraceOnOff
        {
            get { return _traceOnOff ?? Log4netConfigurator.AppendersOnOff[Appenders.Trace] == OnOff.On; }
            set { _traceOnOff = value; }
        }

        public LogLevel RootLogLevel
        {
            get { return _rootLogLevel ?? Log4netConfigurator.RootLogLevel; }
            set { _rootLogLevel = value; }
        }
        public string DefaultPattern
        {
            get { return _defaultPattern ?? Log4netConfigurator.DefaultPattern; }
            set { _defaultPattern = value; }
        }
        public string EventLogName
        {
            get { return _eventLogName ?? Log4netConfigurator.EventLogName; }
            set { _eventLogName = value; }
        }

        public string FilePath
        {
            get { return _filePath ?? Log4netConfigurator.FilePath; }
            set { _filePath = value; }
        }
        public int FileMaxSizeKB
        {
            get { return _fileMaxSizeKB ?? Convert.ToInt32(Log4netConfigurator.FileMaxSizeKB); }
            set { _fileMaxSizeKB = value; }
        }
        public int FileMaxRollbacks
        {
            get { return _fileMaxRollbacks ?? Convert.ToInt32(Log4netConfigurator.FileMaxRollbacks); }
            set { _fileMaxRollbacks = value; }
        }

        public string SmtpHost
        {
            get { return _smtpHost ?? Log4netConfigurator.SmtpHost; }
            set { _smtpHost = value; }
        }
        public string SmtpEmailTo
        {
            get { return _smtpEmailTo ?? Log4netConfigurator.SmtpEmailTo; }
            set { _smtpEmailTo = value; }
        }
        public string SmtpEmailFrom
        {
            get { return _smtpEmailFrom ?? Log4netConfigurator.SmtpEmailFrom; }
            set { _smtpEmailFrom = value; }
        }
        public string SmtpEmailSubject
        {
            get { return _smtpEmailSubject ?? Log4netConfigurator.SmtpEmailSubject; }
            set { _smtpEmailSubject = value; }
        }

        public string SqlCnnString
        {
            get { return _sqlCnnString ?? Log4netConfigurator.SqlCnnString; }
            set { _sqlCnnString = value; }
        }
        public string SqlProcName
        {
            get { return _sqlProcName ?? Log4netConfigurator.SqlProcName; }
            set { _sqlProcName = value; }
        }
    }
}
