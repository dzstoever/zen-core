using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Util;
using Zen.Util.Domain;
using Zen.Util.Reader;
using Zen.Util.TextFormatter;

namespace Zen.Utility
{
    public partial class ApplicationUx : Form
    {
        private static string AddSlashToFolderPath(string folderPath)
        {
            if (!folderPath.EndsWith(Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture)))
                folderPath += Path.DirectorySeparatorChar;
            return folderPath;
        }


        private ApplicationSettings _applicationSettings;
        private ConnectionSetting _currentConnection;
        private IMetadataReader _metadataReader;
        private IList<Column> _gridData;
        private IList<Table> _tables;
        private Table _currentTable;
        readonly IList<int> _cachedTableListSelection;
        readonly BackgroundWorker _worker;


        public ApplicationUx()
        {
            InitializeComponent();
            
            Closing += ApplicationClosing;            
            ownersComboBox.SelectedIndexChanged += OwnersSelectedIndexChanged;
            tablesListBox.SelectedIndexChanged += TablesListSelectedIndexChanged;
            connectionNameComboBox.SelectedIndexChanged += ConnectionNameSelectedIndexChanged;
            connectionButton.Click += ConnectionButtonClicked;
            dbTableDetailsGridView.DataError += OnDataError;            
            dbTableDetailsGridView.CurrentCellDirtyStateChanged += OnTableDetailsCellDirty;
            
            sequencesComboBox.Enabled = false;
            TableFilterTextBox.Enabled = false;
            _cachedTableListSelection = new List<int>();
            _worker = new BackgroundWorker { WorkerSupportsCancellation = true };
        }

        
        protected override void OnLoad(EventArgs e)
        {
            BindData();
            LoadApplicationSettings();
            RefreshAvailableToolsList();
        }

        void BindData()
        {
            columnName.DataPropertyName = "Name";
            isPrimaryKey.DataPropertyName = "IsPrimaryKey";
            isForeignKey.DataPropertyName = "IsForeignKey";
            isUniqueKey.DataPropertyName = "IsUnique";
            isNullable.DataPropertyName = "IsNullable";
            columnDataType.DataPropertyName = "DataType";
            cSharpType.DataPropertyName = "MappedDataType";
            cSharpType.DataSource = new DotNetTypes();
        }

        void LoadApplicationSettings()
        {
            // todo: load and activate every IUtility from the saved settings
            // foreach(var utilitySetting in _applicationSettings.UtilitySettings)

            _applicationSettings = ApplicationSettings.Load();            
            if (_applicationSettings == null)
            {
                LoadApplicationSettingsDefault();
                return;
            }
            
            // Display all previous connections
            connectionNameComboBox.DataSource = _applicationSettings.ConnectionSettings;
            connectionNameComboBox.DisplayMember = "Name";
            
            // Set the last used connection
            var lastUsedConnection = _applicationSettings.ConnectionSettings.FirstOrDefault(
                    connection => connection.Id == _applicationSettings.LastUsedConnection);
            _currentConnection = lastUsedConnection ?? _applicationSettings.ConnectionSettings.FirstOrDefault();
            connectionNameComboBox.SelectedItem = _currentConnection;
            
            // Load field list prefixes, if any
            if (_applicationSettings.FieldPrefixRemovalList == null)
                _applicationSettings.FieldPrefixRemovalList = new List<string>();
            else
                foreach (var prefix in _applicationSettings.FieldPrefixRemovalList) fieldPrefixListBox.Items.Add(prefix);
            removeFieldPrefixButton.Enabled = false;

            // Set Ux control properties based on settings
            SetUxApplicationSettingsChecked();
            SetUxApplicationSettingsText();            
            SetUxCodeControlFormatting();
        }

        void LoadApplicationSettingsDefault()
        {
            // Default application settings
            autoPropertyOption.Checked = true;
            pascalCasedOption.Checked = true;
            cSharpOption.Checked = true;
            byCodeMappingOption.Checked = true;
            includeForeignKeysCheckBox.Checked = true;
            nameAsForeignTableCheckBox.Checked = true;
            includeHasManyCheckBox.Checked = false;
            useLazyLoadingCheckBox.Checked = true;
            comboBoxForeignCollection.Text = "ISet";
            CaptureApplicationSettings();
        }

        void SetUxApplicationSettingsChecked()
        {
            cSharpOption.Checked = _applicationSettings.Language == Language.CSharp;
            vbOption.Checked = _applicationSettings.Language == Language.VB;
            noValidationOption.Checked = _applicationSettings.ValidationStyle == ValidationStyle.None;
            nhibernateValidationOption.Checked = _applicationSettings.ValidationStyle == ValidationStyle.Nhibernate;
            dataAnnotationsOption.Checked = _applicationSettings.ValidationStyle == ValidationStyle.Microsoft;

            prefixedOption.Checked = !string.IsNullOrEmpty(_applicationSettings.Prefix);
            autoPropertyOption.Checked = _applicationSettings.IsAutoProperty;
            enableInflectionsCheckBox.Checked = _applicationSettings.EnableInflections;
            wcfDataContractCheckBox.Checked = _applicationSettings.GenerateWcfContracts;
            partialClassesCheckBox.Checked = _applicationSettings.GeneratePartialClasses;
            useLazyLoadingCheckBox.Checked = _applicationSettings.UseLazy;
            includeLengthAndScaleCheckBox.Checked = _applicationSettings.IncludeLengthAndScale;
            includeForeignKeysCheckBox.Checked = _applicationSettings.IncludeForeignKeys;
            nameAsForeignTableCheckBox.Checked = _applicationSettings.NameFkAsForeignTable;
            includeHasManyCheckBox.Checked = _applicationSettings.IncludeHasMany;
            fluentMappingOption.Checked = _applicationSettings.IsFluent;
            entityFrameworkOption.Checked = _applicationSettings.IsEntityFramework;
            castleMappingOption.Checked = _applicationSettings.IsCastle;
            byCodeMappingOption.Checked = _applicationSettings.IsByCode;
            generateInFoldersCheckBox.Checked = _applicationSettings.GenerateInFolders;

            camelCasedOption.Checked = (_applicationSettings.FieldNamingConvention == FieldNamingConvention.CamelCase);
            pascalCasedOption.Checked = (_applicationSettings.FieldNamingConvention == FieldNamingConvention.PascalCase);
            sameAsDatabaseOption.Checked = (_applicationSettings.FieldNamingConvention == FieldNamingConvention.SameAsDatabase);
            sameAsDatabaseOption.Checked = (!prefixedOption.Checked &&
                                           !pascalCasedOption.Checked &&
                                           !camelCasedOption.Checked);
        }

        void SetUxApplicationSettingsText()
        {
            nameSpaceTextBox.Text = _applicationSettings.DomainNameSpace;
            namespaceMapTextBox.Text = _applicationSettings.MapNameSpace;
            assemblyNameTextBox.Text = _applicationSettings.AssemblyName;
            mappingFolderTextBox.Text = _applicationSettings.MapFolderPath;
            domainFolderTextBox.Text = _applicationSettings.DomainFolderPath;
            inheritenceTextBox.Text = _applicationSettings.InheritenceAndInterfaces;
            prefixTextBox.Text = _applicationSettings.Prefix;
            classNamePrefixTextBox.Text = _applicationSettings.ClassNamePrefix;
            comboBoxForeignCollection.Text = _applicationSettings.ForeignEntityCollectionType;
        }

        void SetUxCodeControlFormatting()
        {
            // Domain Code Formatting
            switch (_applicationSettings.Language)
            {
                case Language.CSharp:
                    domainCodeFastColoredTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
                    break;
                case Language.VB:
                    domainCodeFastColoredTextBox.Language = FastColoredTextBoxNS.Language.VB;
                    break;
            }

            // Map Code Formatting
            if (_applicationSettings.Language == Language.CSharp & _applicationSettings.IsByCode || _applicationSettings.IsFluent || 
                _applicationSettings.IsNhFluent || _applicationSettings.IsCastle || _applicationSettings.IsEntityFramework)
                mapCodeFastColoredTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            else if (_applicationSettings.Language == Language.VB & _applicationSettings.IsByCode || _applicationSettings.IsFluent || 
                _applicationSettings.IsNhFluent || _applicationSettings.IsCastle || _applicationSettings.IsEntityFramework)
                mapCodeFastColoredTextBox.Language = FastColoredTextBoxNS.Language.VB;
            else
                mapCodeFastColoredTextBox.Language = FastColoredTextBoxNS.Language.HTML;            
        }

        void CaptureApplicationSettings()
        {
            if (_applicationSettings == null)
            {
                _applicationSettings = new ApplicationSettings();
            }
            _applicationSettings.DomainNameSpace = nameSpaceTextBox.Text;
            _applicationSettings.MapNameSpace = namespaceMapTextBox.Text;
            _applicationSettings.AssemblyName = assemblyNameTextBox.Text;
            _applicationSettings.Language = cSharpOption.Checked ? Language.CSharp : Language.VB;

            var validationStyle = ValidationStyle.None;
            if (dataAnnotationsOption.Checked) validationStyle = ValidationStyle.Microsoft;
            if (nhibernateValidationOption.Checked) validationStyle = ValidationStyle.Nhibernate;

            _applicationSettings.ValidationStyle = validationStyle;
            _applicationSettings.IsFluent = fluentMappingOption.Checked;
            _applicationSettings.IsEntityFramework = entityFrameworkOption.Checked;
            _applicationSettings.IsAutoProperty = autoPropertyOption.Checked;
            _applicationSettings.MapFolderPath = mappingFolderTextBox.Text;
            _applicationSettings.DomainFolderPath = domainFolderTextBox.Text;
            _applicationSettings.InheritenceAndInterfaces = inheritenceTextBox.Text;
            _applicationSettings.ForeignEntityCollectionType = comboBoxForeignCollection.Text;
            _applicationSettings.FieldPrefixRemovalList = _applicationSettings.FieldPrefixRemovalList;
            _applicationSettings.FieldNamingConvention = FieldNamingConventionSelected;
            _applicationSettings.Prefix = prefixTextBox.Text;
            _applicationSettings.IsCastle = IsCastle;
            _applicationSettings.ClassNamePrefix = classNamePrefixTextBox.Text;
            _applicationSettings.EnableInflections = enableInflectionsCheckBox.Checked;
            _applicationSettings.GeneratePartialClasses = partialClassesCheckBox.Checked;
            _applicationSettings.GenerateWcfContracts = wcfDataContractCheckBox.Checked;
            _applicationSettings.GenerateInFolders = generateInFoldersCheckBox.Checked;
            _applicationSettings.IsByCode = IsByCode;
            _applicationSettings.UseLazy = useLazyLoadingCheckBox.Checked;
            _applicationSettings.IncludeForeignKeys = includeForeignKeysCheckBox.Checked;
            _applicationSettings.NameFkAsForeignTable = nameAsForeignTableCheckBox.Checked;
            _applicationSettings.IncludeHasMany = includeHasManyCheckBox.Checked;
            _applicationSettings.IncludeLengthAndScale = includeLengthAndScaleCheckBox.Checked;
            _applicationSettings.LastUsedConnection = _currentConnection == null ? (Guid?)null : _currentConnection.Id;
        }

        void ApplicationClosing(object sender, CancelEventArgs e)
        {
            CaptureApplicationSettings();
            _applicationSettings.Save();
        }


        #region Database Connection and Owner/Table Selection

        private void ConnectButtonClicked(object sender, EventArgs e)
        {
            if (_currentConnection == null) return;

            toolStripStatusLabel.Text = string.Format("Connecting to {0}...", _currentConnection.Name);
            statusStrip1.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                tablesListBox.DataSource = null;
                tablesListBox.DisplayMember = "Name";
                sequencesComboBox.Items.Clear();

                _metadataReader = MetadataFactory.GetReader(_currentConnection.Type, _currentConnection.ConnectionString);

                toolStripStatusLabel.Text = "Retrieving owners...";
                statusStrip1.Refresh();
                PopulateOwners();

                toolStripStatusLabel.Text = string.Empty;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ConnectionButtonClicked(object sender, EventArgs e)
        {
            var connectionDialog = new ConnectionDialog();
            // Belt and braces
            if (_applicationSettings == null)
                LoadApplicationSettings();
            // Edit current connection
            if (_currentConnection != null)
                connectionDialog.ConnectionSetting = _currentConnection;

            Debug.Assert(_applicationSettings != null, "_applicationSettings != null");
            var result = connectionDialog.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:// Add or Update Connection
                    _currentConnection = connectionDialog.ConnectionSetting;                    
                    var connectionToUpdate = _applicationSettings.ConnectionSettings.FirstOrDefault(
                        connection => connection.Id == _currentConnection.Id);
                    if (connectionToUpdate == null) // Add new connection
                        _applicationSettings.ConnectionSettings.Add(_currentConnection);
                    break;
                case DialogResult.Abort:// Delete Connection                    
                    _applicationSettings.ConnectionSettings.Remove(_currentConnection);
                    _currentConnection = null;
                    break;
            }

            // Refresh data connections drop down
            connectionNameComboBox.DataSource = null;
            connectionNameComboBox.DataSource = _applicationSettings.ConnectionSettings;
            connectionNameComboBox.DisplayMember = "Name";
            connectionNameComboBox.SelectedItem = _currentConnection;
        }

        private void ConnectionNameSelectedIndexChanged(object sender, EventArgs e)
        {
            if (connectionNameComboBox.SelectedItem == null) return;

            _currentConnection = (ConnectionSetting)connectionNameComboBox.SelectedItem;

            pOracleOnlyOptions.Hide();

            //if (_currentConnection.Type == ServerType.Oracle)
            //    pOracleOnlyOptions.Show();
        }

        private void OwnersSelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                PopulateTablesAndSequences();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void TablesListSelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (tablesListBox.SelectedIndex == -1)
                {
                    dbTableDetailsGridView.DataSource = new List<Column>();
                    return;
                }

                var lastTableSelectedIndex = LastTableSelected();
                if (lastTableSelectedIndex == null) return;                
                var table = tablesListBox.Items[lastTableSelectedIndex.Value] as Table;
                if (table == null) return;

                CaptureApplicationSettings();
                PopulateTableDetails(table);
                ToggleColumnsBasedOnAppSettings();
                GenerateAndDisplayCode(table);

                // Display entity name based on formatted table name
                var appPreferences = GetApplicationPreferences(table, false, _applicationSettings);
                var formatter = TextFormatterFactory.GetTextFormatter(appPreferences);
                entityNameTextBox.Text = formatter.FormatText(table.Name);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void OnTableDetailsCellDirty(object sender, EventArgs e)
        {
            if (_currentTable == null) return;

            GenerateAndDisplayCode(_currentTable);
            ToggleColumnsBasedOnAppSettings();
        }

        private void OnTableFilterEnter(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;

            if (textbox == null) return;

            if (textbox.Text == textbox.Tag.ToString())
            {
                textbox.TextChanged -= OnTableFilterTextChanged;

                // Clear the hint text in the table filter textbox
                textbox.Text = string.Empty;

                textbox.TextChanged += OnTableFilterTextChanged;
            }
        }

        private void OnTableFilterTextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox == null) return;

            // Display the full table list
            if (string.IsNullOrEmpty(textbox.Text))
            {
                SuspendLayout();
                tablesListBox.ClearSelected();
                tablesListBox.DataSource = _tables;
                tablesListBox.SelectedItem = _tables.FirstOrDefault();
                ResumeLayout();
                return;
            }

            // Display filtered list of tables
            var query = (from t in _tables
                         where t.Name.ToLower().Contains(textbox.Text.ToLower())
                         select t).ToList();

            SuspendLayout();
            tablesListBox.ClearSelected();
            tablesListBox.DataSource = query;
            tablesListBox.SelectedItem = query.FirstOrDefault();
            ResumeLayout();
        }

        private void OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            toolStripStatusLabel.Text = string.Format("Error in column {0} of row {1} - {3}. Detail : {2}", e.ColumnIndex, e.RowIndex, e.Exception.Message, (_gridData != null ? _gridData[e.RowIndex].Name : ""));
        }

        void PopulateOwners()
        {
            var owners = _metadataReader.GetOwners();
            if (owners == null || owners.Count == 0)
            {
                owners = new List<string> { "dbo" };
            }

            tablesListBox.SelectedIndexChanged -= TablesListSelectedIndexChanged;

            ownersComboBox.Items.Clear();
            ownersComboBox.Items.AddRange(owners.ToArray());

            tablesListBox.SelectedIndexChanged += TablesListSelectedIndexChanged;
            ownersComboBox.SelectedIndex = 0;
        }

        void PopulateTablesAndSequences()
        {
            try
            {
                toolStripStatusLabel.Text = "Retrieving tables...";
                statusStrip1.Refresh();

                if (ownersComboBox.SelectedItem == null)
                {
                    tablesListBox.DataSource = new List<Table>();
                    return;
                }
                _tables = _metadataReader.GetTables(ownersComboBox.SelectedItem.ToString());
                tablesListBox.Enabled = false;
                TableFilterTextBox.Enabled = false;
                tablesListBox.DataSource = _tables;
                tablesListBox.DisplayMember = "Name";

                if (_tables != null && _tables.Any())
                {
                    tablesListBox.Enabled = true;
                    TableFilterTextBox.Enabled = true;
                    tablesListBox.SelectedItem = _tables.FirstOrDefault();
                }

                var sequences = _metadataReader.GetSequences(ownersComboBox.SelectedItem.ToString());
                sequencesComboBox.Enabled = false;
                sequencesComboBox.Items.Clear();
                if (sequences != null && sequences.Any())
                {
                    sequencesComboBox.Items.AddRange(sequences.ToArray());
                    sequencesComboBox.Enabled = true;
                    sequencesComboBox.SelectedIndex = 0;
                }

                toolStripStatusLabel.Text = string.Empty;
                statusStrip1.Refresh();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = ex.Message;
            }
        }

        void PopulateTableDetails(Table selectedTable)
        {
            toolStripStatusLabel.Text = string.Empty;
            try
            {
                //dbTableDetailsGridView.AutoGenerateColumns = true;
                _currentTable = selectedTable;
                _gridData = _metadataReader.GetTableDetails(selectedTable, ownersComboBox.SelectedItem.ToString()) ??
                           new List<Column>();

                // Show table details, and toggle columns based on app settings
                dbTableDetailsGridView.SuspendLayout();
                dbTableDetailsGridView.DataSource = _gridData;
                dbTableDetailsGridView.ResumeLayout();

            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = ex.Message;
            }
        }

        void ToggleColumnsBasedOnAppSettings()
        {
            var lengthColumn = dbTableDetailsGridView.Columns["DataLength"];
            
            if (lengthColumn != null)
            {
                lengthColumn.HeaderText = "Data Length";
                lengthColumn.Visible = _applicationSettings.IncludeLengthAndScale;
            }
            

            var precisionColumn = dbTableDetailsGridView.Columns["DataPrecision"];
            if (precisionColumn != null)
                precisionColumn.Visible = _applicationSettings.IncludeLengthAndScale;

            var scaleColumn = dbTableDetailsGridView.Columns["DataScale"];
            if (scaleColumn != null)
                scaleColumn.Visible = _applicationSettings.IncludeLengthAndScale;

            var cSharpTypeColumn = dbTableDetailsGridView.Columns["cSharpType"];
            if (cSharpTypeColumn != null)
                cSharpTypeColumn.Visible = !_applicationSettings.IsByCode;

            /*var fkTableNameColumn = dbTableDetailsGridView.Columns["ForeignKeyTableName"];
            var fkColNameColumn = dbTableDetailsGridView.Columns["ForeignKeyColumnName"];
            if (fkColNameColumn != null && fkTableNameColumn != null)
            {
                if (_currentTable.ForeignKeys.Count != 0)
                {
                    // Disable foreign key columns
                    fkTableNameColumn.ReadOnly = false;
                    fkColNameColumn.ReadOnly = false;
                }
                else
                {
                    // Enable foreign key columns
                    fkTableNameColumn.ReadOnly = true;
                    fkColNameColumn.ReadOnly = true;
                }
            }*/
        }

        int? LastTableSelected()
        {
            int? lastTableIndex = null;
            foreach (int i in tablesListBox.SelectedIndices)
            {
                if (_cachedTableListSelection.Contains(i))
                    continue;
                lastTableIndex = i;
                break;
            }
            _cachedTableListSelection.Clear();
            foreach (int i in tablesListBox.SelectedIndices)
                _cachedTableListSelection.Add(i);
            return lastTableIndex;
        }

        #endregion


        #region Mapping & Domain Code Generation

        private void MappingFolderSelectButtonClicked(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Select a location for your mapping files.";
            var diagResult = folderBrowserDialog.ShowDialog();

            if (diagResult == DialogResult.OK)
            {
                mappingFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void DomainFolderSelectButtonClicked(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Select a location for your domain files.";
            var diagResult = folderBrowserDialog.ShowDialog();

            if (diagResult == DialogResult.OK)
            {
                domainFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void GenerateClicked(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
            var selectedItems = tablesListBox.SelectedItems;
            if (selectedItems.Count == 0)
            {
                toolStripStatusLabel.Text = @"Please select table(s) above to generate the mapping files.";
                return;
            }
            try
            {
                foreach (var selectedItem in selectedItems)
                {
                    toolStripStatusLabel.Text = string.Format("Generating {0} mapping file ...", selectedItem);
                    var table = (Table)selectedItem;
                    _metadataReader.GetTableDetails(table, ownersComboBox.SelectedItem.ToString());
                    CaptureApplicationSettings();
                    Generate(table, selectedItems.Count > 1, _applicationSettings);
                }
                toolStripStatusLabel.Text = @"Generated all files successfully.";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = ex.Message;
            }
        }

        private void GenerateAllClicked(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = string.Empty;
            var items = tablesListBox.Items;
            if (items.Count == 0)
            {
                toolStripStatusLabel.Text = @"Please connect to a database to populate the tables first.";
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    toolStripProgressBar1.Maximum = 100;
                    toolStripProgressBar1.Value = 10;
                    _worker.DoWork += DoWork;
                    _worker.RunWorkerCompleted += WorkerCompleted;
                    CaptureApplicationSettings();
                    _worker.RunWorkerAsync(_applicationSettings);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = ex.Message;
            }
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            if (_worker != null) _worker.CancelAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            var appSettings = e.Argument as ApplicationSettings;
            var items = tablesListBox.Items;
            var pOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
            Parallel.ForEach(items.Cast<Table>(), pOptions, (table, loopState) =>
            {
                if (_worker != null && _worker.CancellationPending && !loopState.IsStopped)
                {
                    loopState.Stop();
                    loopState.Break();
                    Thread.Sleep(1000);
                }
                string name = "";
                if (ownersComboBox.InvokeRequired)
                {
                    ownersComboBox.Invoke(new MethodInvoker(delegate
                    {
                        name = ownersComboBox.SelectedItem.ToString();
                    }));
                }
                else
                {
                    name = ownersComboBox.SelectedItem.ToString();
                }
                _metadataReader.GetTableDetails(table, name);
                Generate(table, true, appSettings);
            });
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 100;
            toolStripStatusLabel.Text = @"Generated all files successfully.";
        }
        
        void Generate(Table table, bool generateAll, ApplicationSettings appSettings)
        {
            var applicationPreferences = GetApplicationPreferences(table, generateAll, appSettings);
            new ApplicationController(applicationPreferences, table).Generate();
        }

        void GenerateAndDisplayCode(Table table)
        {
            SetUxCodeControlFormatting();

            // Refresh the primary key relationships.
            table.PrimaryKey = _metadataReader.DeterminePrimaryKeys(table);
            table.ForeignKeys = _metadataReader.DetermineForeignKeyReferences(table);

            // Show map and domain code preview
            ApplicationPreferences applicationPreferences = GetApplicationPreferences(table, false, _applicationSettings);
            var applicationController = new ApplicationController(applicationPreferences, table);
            applicationController.Generate(false);
            mapCodeFastColoredTextBox.Text = applicationController.GeneratedMapCode;
            domainCodeFastColoredTextBox.Text = applicationController.GeneratedDomainCode;
        }

        #endregion

        
        #region Preferences

        ApplicationPreferences GetApplicationPreferences(Table tableName, bool all, ApplicationSettings appSettings)
        {
            string sequence = string.Empty;
            object sequenceName = null;
            if (sequencesComboBox.InvokeRequired)
            {
                sequencesComboBox.Invoke(new MethodInvoker(delegate
                {
                    sequenceName = sequencesComboBox.SelectedItem;
                }));
            }
            else
            {
                sequenceName = sequencesComboBox.SelectedItem;
            }
            if (sequenceName != null && !all)
            {
                sequence = sequenceName.ToString();
            }

            var folderPath = AddSlashToFolderPath(mappingFolderTextBox.Text);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var domainFolderPath = AddSlashToFolderPath(domainFolderTextBox.Text);
            if (appSettings.GenerateInFolders)
            {
                Directory.CreateDirectory(folderPath + "Contract");
                Directory.CreateDirectory(folderPath + "Domain");
                Directory.CreateDirectory(folderPath + "Mapping");
                domainFolderPath = folderPath;
            }
            else
            {
                // Domain folder is specified by user
                if (!Directory.Exists(domainFolderPath))
                {
                    Directory.CreateDirectory(domainFolderPath);
                }
            }

            var applicationPreferences = new ApplicationPreferences
            {
                ServerType = _currentConnection.Type,
                FolderPath = folderPath,
                DomainFolderPath = domainFolderPath,
                TableName = tableName.Name,
                NameSpaceMap = namespaceMapTextBox.Text,
                NameSpace = nameSpaceTextBox.Text,
                AssemblyName = assemblyNameTextBox.Text,
                Sequence = sequence,
                Language = LanguageSelected,
                FieldNamingConvention = FieldNamingConventionSelected,
                FieldGenerationConvention = FieldGenerationConventionSelected,
                Prefix = prefixTextBox.Text,
                IsFluent = IsFluent,
                IsEntityFramework = IsEntityFramework,
                IsCastle = IsCastle,
                GeneratePartialClasses = appSettings.GeneratePartialClasses,
                GenerateWcfDataContract = appSettings.GenerateWcfContracts,
                ConnectionString = _currentConnection.ConnectionString,
                ForeignEntityCollectionType = appSettings.ForeignEntityCollectionType,
                InheritenceAndInterfaces = appSettings.InheritenceAndInterfaces,
                GenerateInFolders = appSettings.GenerateInFolders,
                ClassNamePrefix = appSettings.ClassNamePrefix,
                EnableInflections = appSettings.EnableInflections,
                IsByCode = appSettings.IsByCode,
                UseLazy = appSettings.UseLazy,
                FieldPrefixRemovalList = appSettings.FieldPrefixRemovalList,
                IncludeForeignKeys = appSettings.IncludeForeignKeys,
                NameFkAsForeignTable = appSettings.NameFkAsForeignTable,
                IncludeHasMany = appSettings.IncludeHasMany,
                IncludeLengthAndScale = appSettings.IncludeLengthAndScale,
                ValidatorStyle = appSettings.ValidationStyle
            };

            return applicationPreferences;
        }
        
        public bool IsByCode
        {
            get { return byCodeMappingOption.Checked; }
        }
        public bool IsFluent
        {
            get { return fluentMappingOption.Checked; }
        }
        public bool IsCastle
        {
            get { return castleMappingOption.Checked; }
        }
        public bool IsEntityFramework
        {
            get { return entityFrameworkOption.Checked; }
        }

        Language LanguageSelected
        {
            get { return vbOption.Checked ? Language.VB : Language.CSharp; }
        }

        FieldNamingConvention FieldNamingConventionSelected
        {
            get
            {
                var convention = FieldNamingConvention.SameAsDatabase;
                if (prefixedOption.Checked)
                    convention = FieldNamingConvention.Prefixed;
                if (camelCasedOption.Checked)
                    convention = FieldNamingConvention.CamelCase;
                if (pascalCasedOption.Checked)
                    convention = FieldNamingConvention.PascalCase;
                return convention;
            }
        }

        FieldGenerationConvention FieldGenerationConventionSelected
        {
            get
            {
                var convention = FieldGenerationConvention.Field;
                if (autoPropertyOption.Checked)
                    convention = FieldGenerationConvention.AutoProperty;
                if (propertyOption.Checked)
                    convention = FieldGenerationConvention.Property;
                return convention;
            }
        }

        void AddFieldPrefixButtonClicked(object sender, EventArgs e)
        {
            // Check if the prefix has already been added.
            if (_applicationSettings.FieldPrefixRemovalList.Any(s => s == fieldPrefixTextBox.Text))
            {
                fieldPrefixTextBox.Text = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(fieldPrefixTextBox.Text)) return;

            // Add the new prefix
            _applicationSettings.FieldPrefixRemovalList.Add(fieldPrefixTextBox.Text);
            fieldPrefixListBox.Items.Clear();
            fieldPrefixListBox.Items.AddRange(_applicationSettings.FieldPrefixRemovalList.ToArray());
            fieldPrefixTextBox.Text = string.Empty;
        }

        void RemoveFieldPrefixButtonClicked(object sender, EventArgs e)
        {
            if (fieldPrefixListBox.SelectedIndex == -1) return;

            _applicationSettings.FieldPrefixRemovalList.Remove(fieldPrefixListBox.SelectedItem.ToString());
            fieldPrefixListBox.Items.Clear();
            fieldPrefixListBox.Items.AddRange(_applicationSettings.FieldPrefixRemovalList.ToArray());
            fieldPrefixListBox.SelectedIndex = -1;
            removeFieldPrefixButton.Enabled = fieldPrefixListBox.SelectedIndex != -1;
        }

        void OnFieldPrefixListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            removeFieldPrefixButton.Enabled = fieldPrefixListBox.SelectedIndex != -1;
        }
        
        void IncludeForeignKeysCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            nameAsForeignTableCheckBox.Enabled = includeForeignKeysCheckBox.Checked;
        }

        #endregion



        private IList<IUtility> _utilityTools = new List<IUtility>();

        // Note:
        // The List, Details, and SmallIcon views display images from the image list specified in the SmallImageList property. 
        // The LargeIcon view displays images from the image list specified in the LargeImageList property. 
        // A list view can also display an additional set of icons, set in the StateImageList property, 
        // next to the large or small icons. 
        private void RefreshAvailableToolsButtonClick(object sender, EventArgs e)
        {
            RefreshAvailableToolsList();
        }
        
        void RefreshAvailableToolsList()
        {
            var exeAssembly = Assembly.GetEntryAssembly();
            var toolsPath = exeAssembly.Location.Replace(exeAssembly.GetEntryAssemblyName() + ".exe", "Tools");
            var toolsDir = new DirectoryInfo(toolsPath);
            if (!toolsDir.Exists) toolsDir.Create();

            listView1.BeginUpdate();
            // For each file, create a ListViewItem and set the icon to the icon extracted from the file. 
            foreach (var file in toolsDir.GetFiles())
            {
                var item = new ListViewItem(file.Name, 1);
                var icon = Icon.ExtractAssociatedIcon(file.FullName) ?? SystemIcons.WinLogo;// default icon
                // Check to see if the image collection contains an image (key = extension)
                if (!largeToolImageList.Images.ContainsKey(file.Extension))
                    largeToolImageList.Images.Add(file.Extension, icon); // If not, add the image to the image list.
                item.ImageKey = file.Extension;
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }


        protected void OpenControlInNewTab(UserControl userControl, string tabCaption)
        {
            var tabPage = new TabPage(tabCaption);
            userControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(userControl);
            tabControl1.TabPages.Add(tabPage);
            
        }
    }
}