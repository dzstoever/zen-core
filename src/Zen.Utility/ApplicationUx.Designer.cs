using System.Windows.Forms;

namespace Zen.Utility
{
    partial class ApplicationUx
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Log Configurator", 0);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("WCF Configurator", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationUx));
            this.connectButton = new System.Windows.Forms.Button();
            this.sequencesComboBox = new System.Windows.Forms.ComboBox();
            this.dbTableDetailsGridView = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSharpType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isPrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isForeignKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isUniqueKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ConstraintName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForeignKeyTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForeignKeyColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mappingFolderTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.mappingFolderSelectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameSpaceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.assemblyNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.generateAllBtn = new System.Windows.Forms.Button();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.basicSettingsTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableGroupBox = new System.Windows.Forms.GroupBox();
            this.TableFilterTextBox = new System.Windows.Forms.TextBox();
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.ownersComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mapCodeFastColoredTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.domainCodeFastColoredTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.namespaceMapTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.entityNameTextBox = new System.Windows.Forms.TextBox();
            this.domainFolderTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.domainFolderSelectButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.largeToolImageList = new System.Windows.Forms.ImageList(this.components);
            this.smallToolImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addNewToolButton = new System.Windows.Forms.ToolStripButton();
            this.openToolInTabButton = new System.Windows.Forms.ToolStripButton();
            this.openToolInWindowButton = new System.Windows.Forms.ToolStripButton();
            this.refreshAvailableToolsButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pOracleOnlyOptions = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.connectionNameComboBox = new System.Windows.Forms.ComboBox();
            this.connectionButton = new System.Windows.Forms.Button();
            this.advanceSettingsTabPage = new System.Windows.Forms.TabPage();
            this.tablePrefixGroupBox = new System.Windows.Forms.GroupBox();
            this.removeFieldPrefixButton = new System.Windows.Forms.Button();
            this.addFieldPrefixButton = new System.Windows.Forms.Button();
            this.fieldPrefixListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fieldPrefixTextBox = new System.Windows.Forms.TextBox();
            this.filesGroupBox = new System.Windows.Forms.GroupBox();
            this.generateInFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.mappingOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxForeignCollection = new System.Windows.Forms.ComboBox();
            this.wcfDataContractCheckBox = new System.Windows.Forms.CheckBox();
            this.labelForeignEntity = new System.Windows.Forms.Label();
            this.partialClassesCheckBox = new System.Windows.Forms.CheckBox();
            this.labelCLassNamePrefix = new System.Windows.Forms.Label();
            this.labelInheritence = new System.Windows.Forms.Label();
            this.classNamePrefixTextBox = new System.Windows.Forms.TextBox();
            this.inheritenceTextBox = new System.Windows.Forms.TextBox();
            this.fieldOrPropertyOptionsGroup = new System.Windows.Forms.GroupBox();
            this.nameAsForeignTableCheckBox = new System.Windows.Forms.CheckBox();
            this.includeHasManyCheckBox = new System.Windows.Forms.CheckBox();
            this.includeLengthAndScaleCheckBox = new System.Windows.Forms.CheckBox();
            this.autoPropertyOption = new System.Windows.Forms.RadioButton();
            this.propertyOption = new System.Windows.Forms.RadioButton();
            this.fieldOption = new System.Windows.Forms.RadioButton();
            this.useLazyLoadingCheckBox = new System.Windows.Forms.CheckBox();
            this.includeForeignKeysCheckBox = new System.Windows.Forms.CheckBox();
            this.validationStyleGroupBox = new System.Windows.Forms.GroupBox();
            this.dataAnnotationsOption = new System.Windows.Forms.RadioButton();
            this.noValidationOption = new System.Windows.Forms.RadioButton();
            this.nhibernateValidationOption = new System.Windows.Forms.RadioButton();
            this.mappingStyleGroupBox = new System.Windows.Forms.GroupBox();
            this.entityFrameworkOption = new System.Windows.Forms.RadioButton();
            this.castleMappingOption = new System.Windows.Forms.RadioButton();
            this.fluentMappingOption = new System.Windows.Forms.RadioButton();
            this.hbmMappingOption = new System.Windows.Forms.RadioButton();
            this.byCodeMappingOption = new System.Windows.Forms.RadioButton();
            this.languageGroupBox = new System.Windows.Forms.GroupBox();
            this.vbOption = new System.Windows.Forms.RadioButton();
            this.cSharpOption = new System.Windows.Forms.RadioButton();
            this.generatedPropertyGroupBox = new System.Windows.Forms.GroupBox();
            this.enableInflectionsCheckBox = new System.Windows.Forms.CheckBox();
            this.pascalCasedOption = new System.Windows.Forms.RadioButton();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.prefixedOption = new System.Windows.Forms.RadioButton();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.camelCasedOption = new System.Windows.Forms.RadioButton();
            this.sameAsDatabaseOption = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dbTableDetailsGridView)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.basicSettingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapCodeFastColoredTextBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.domainCodeFastColoredTextBox)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pOracleOnlyOptions.SuspendLayout();
            this.advanceSettingsTabPage.SuspendLayout();
            this.tablePrefixGroupBox.SuspendLayout();
            this.filesGroupBox.SuspendLayout();
            this.mappingOptionsGroupBox.SuspendLayout();
            this.fieldOrPropertyOptionsGroup.SuspendLayout();
            this.validationStyleGroupBox.SuspendLayout();
            this.mappingStyleGroupBox.SuspendLayout();
            this.languageGroupBox.SuspendLayout();
            this.generatedPropertyGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(251, 23);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(80, 26);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "&Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButtonClicked);
            // 
            // sequencesComboBox
            // 
            this.sequencesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sequencesComboBox.DropDownWidth = 449;
            this.sequencesComboBox.FormattingEnabled = true;
            this.sequencesComboBox.Location = new System.Drawing.Point(7, 16);
            this.sequencesComboBox.Name = "sequencesComboBox";
            this.sequencesComboBox.Size = new System.Drawing.Size(274, 24);
            this.sequencesComboBox.TabIndex = 4;
            // 
            // dbTableDetailsGridView
            // 
            this.dbTableDetailsGridView.AllowUserToAddRows = false;
            this.dbTableDetailsGridView.AllowUserToDeleteRows = false;
            this.dbTableDetailsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbTableDetailsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dbTableDetailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbTableDetailsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnDataType,
            this.cSharpType,
            this.isPrimaryKey,
            this.isForeignKey,
            this.isNullable,
            this.IsIdentity,
            this.isUniqueKey,
            this.ConstraintName,
            this.ForeignKeyTableName,
            this.ForeignKeyColumnName});
            this.dbTableDetailsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbTableDetailsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dbTableDetailsGridView.Location = new System.Drawing.Point(3, 3);
            this.dbTableDetailsGridView.Name = "dbTableDetailsGridView";
            this.dbTableDetailsGridView.RowHeadersVisible = false;
            this.dbTableDetailsGridView.Size = new System.Drawing.Size(875, 265);
            this.dbTableDetailsGridView.TabIndex = 5;
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "Name";
            this.columnName.HeaderText = "Column Name";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnDataType
            // 
            this.columnDataType.HeaderText = "Data Type";
            this.columnDataType.Name = "columnDataType";
            this.columnDataType.ReadOnly = true;
            // 
            // cSharpType
            // 
            this.cSharpType.HeaderText = "C# Type";
            this.cSharpType.Name = "cSharpType";
            this.cSharpType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSharpType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isPrimaryKey
            // 
            this.isPrimaryKey.HeaderText = "Primary Key";
            this.isPrimaryKey.Name = "isPrimaryKey";
            // 
            // isForeignKey
            // 
            this.isForeignKey.HeaderText = "Foreign Key";
            this.isForeignKey.Name = "isForeignKey";
            // 
            // isNullable
            // 
            this.isNullable.HeaderText = "Nullable";
            this.isNullable.Name = "isNullable";
            // 
            // IsIdentity
            // 
            this.IsIdentity.DataPropertyName = "IsIdentity";
            this.IsIdentity.HeaderText = "Identity";
            this.IsIdentity.Name = "IsIdentity";
            // 
            // isUniqueKey
            // 
            this.isUniqueKey.HeaderText = "Unique Key";
            this.isUniqueKey.Name = "isUniqueKey";
            // 
            // ConstraintName
            // 
            this.ConstraintName.DataPropertyName = "ConstraintName";
            this.ConstraintName.HeaderText = "Constraint";
            this.ConstraintName.Name = "ConstraintName";
            // 
            // ForeignKeyTableName
            // 
            this.ForeignKeyTableName.DataPropertyName = "ForeignKeyTableName";
            this.ForeignKeyTableName.HeaderText = "FK Table";
            this.ForeignKeyTableName.Name = "ForeignKeyTableName";
            // 
            // ForeignKeyColumnName
            // 
            this.ForeignKeyColumnName.DataPropertyName = "ForeignKeyColumnName";
            this.ForeignKeyColumnName.HeaderText = "FK Column";
            this.ForeignKeyColumnName.Name = "ForeignKeyColumnName";
            // 
            // mappingFolderTextBox
            // 
            this.mappingFolderTextBox.Location = new System.Drawing.Point(146, 28);
            this.mappingFolderTextBox.Name = "mappingFolderTextBox";
            this.mappingFolderTextBox.Size = new System.Drawing.Size(450, 22);
            this.mappingFolderTextBox.TabIndex = 7;
            this.mappingFolderTextBox.Text = "c:\\ZenUtility\\Maps";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(6, 235);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(124, 26);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "&Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateClicked);
            // 
            // mappingFolderSelectButton
            // 
            this.mappingFolderSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mappingFolderSelectButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mappingFolderSelectButton.Location = new System.Drawing.Point(120, 28);
            this.mappingFolderSelectButton.Name = "mappingFolderSelectButton";
            this.mappingFolderSelectButton.Size = new System.Drawing.Size(26, 22);
            this.mappingFolderSelectButton.TabIndex = 9;
            this.mappingFolderSelectButton.Text = ". . .";
            this.mappingFolderSelectButton.UseVisualStyleBackColor = true;
            this.mappingFolderSelectButton.Click += new System.EventHandler(this.MappingFolderSelectButtonClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select the folder in which the mapping and domain files will be generated";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Namespace (Domain) :";
            // 
            // nameSpaceTextBox
            // 
            this.nameSpaceTextBox.Location = new System.Drawing.Point(146, 127);
            this.nameSpaceTextBox.Name = "nameSpaceTextBox";
            this.nameSpaceTextBox.Size = new System.Drawing.Size(450, 22);
            this.nameSpaceTextBox.TabIndex = 12;
            this.nameSpaceTextBox.Text = "Zen.Domain";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Assembly Name :";
            // 
            // assemblyNameTextBox
            // 
            this.assemblyNameTextBox.Location = new System.Drawing.Point(146, 160);
            this.assemblyNameTextBox.Name = "assemblyNameTextBox";
            this.assemblyNameTextBox.Size = new System.Drawing.Size(450, 22);
            this.assemblyNameTextBox.TabIndex = 14;
            this.assemblyNameTextBox.Text = "Zen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Select the sequence for the selected table";
            // 
            // generateAllBtn
            // 
            this.generateAllBtn.Location = new System.Drawing.Point(146, 235);
            this.generateAllBtn.Name = "generateAllBtn";
            this.generateAllBtn.Size = new System.Drawing.Size(124, 26);
            this.generateAllBtn.TabIndex = 18;
            this.generateAllBtn.Text = "Generate &All";
            this.generateAllBtn.UseVisualStyleBackColor = true;
            this.generateAllBtn.Click += new System.EventHandler(this.GenerateAllClicked);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.basicSettingsTabPage);
            this.mainTabControl.Controls.Add(this.advanceSettingsTabPage);
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1136, 699);
            this.mainTabControl.TabIndex = 19;
            // 
            // basicSettingsTabPage
            // 
            this.basicSettingsTabPage.Controls.Add(this.splitContainer1);
            this.basicSettingsTabPage.Controls.Add(this.groupBox5);
            this.basicSettingsTabPage.Controls.Add(this.groupBox4);
            this.basicSettingsTabPage.Location = new System.Drawing.Point(4, 25);
            this.basicSettingsTabPage.Name = "basicSettingsTabPage";
            this.basicSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.basicSettingsTabPage.Size = new System.Drawing.Size(1128, 670);
            this.basicSettingsTabPage.TabIndex = 1;
            this.basicSettingsTabPage.Text = "Basic";
            this.basicSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 66);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(1122, 307);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 23;
            // 
            // tableGroupBox
            // 
            this.tableGroupBox.Controls.Add(this.TableFilterTextBox);
            this.tableGroupBox.Controls.Add(this.tablesListBox);
            this.tableGroupBox.Controls.Add(this.ownersComboBox);
            this.tableGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableGroupBox.Location = new System.Drawing.Point(0, 0);
            this.tableGroupBox.Name = "tableGroupBox";
            this.tableGroupBox.Size = new System.Drawing.Size(228, 307);
            this.tableGroupBox.TabIndex = 21;
            this.tableGroupBox.TabStop = false;
            this.tableGroupBox.Text = "Select Owner and Table(s)";
            // 
            // TableFilterTextBox
            // 
            this.TableFilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableFilterTextBox.Location = new System.Drawing.Point(7, 58);
            this.TableFilterTextBox.Name = "TableFilterTextBox";
            this.TableFilterTextBox.Size = new System.Drawing.Size(214, 22);
            this.TableFilterTextBox.TabIndex = 7;
            this.TableFilterTextBox.Tag = "Enter table filter here...";
            this.TableFilterTextBox.Text = "Enter table filter here...";
            this.toolTip1.SetToolTip(this.TableFilterTextBox, "Enter table filter here...");
            this.TableFilterTextBox.TextChanged += new System.EventHandler(this.OnTableFilterTextChanged);
            this.TableFilterTextBox.Enter += new System.EventHandler(this.OnTableFilterEnter);
            // 
            // tablesListBox
            // 
            this.tablesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.ItemHeight = 16;
            this.tablesListBox.Location = new System.Drawing.Point(7, 90);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.tablesListBox.Size = new System.Drawing.Size(213, 212);
            this.tablesListBox.TabIndex = 6;
            // 
            // ownersComboBox
            // 
            this.ownersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ownersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ownersComboBox.FormattingEnabled = true;
            this.ownersComboBox.Location = new System.Drawing.Point(7, 25);
            this.ownersComboBox.Name = "ownersComboBox";
            this.ownersComboBox.Size = new System.Drawing.Size(214, 24);
            this.ownersComboBox.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 300);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dbTableDetailsGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(881, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Table Definition";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mapCodeFastColoredTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(881, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Map Code";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mapCodeFastColoredTextBox
            // 
            this.mapCodeFastColoredTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.mapCodeFastColoredTextBox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.mapCodeFastColoredTextBox.BackBrush = null;
            this.mapCodeFastColoredTextBox.CharHeight = 14;
            this.mapCodeFastColoredTextBox.CharWidth = 8;
            this.mapCodeFastColoredTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mapCodeFastColoredTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.mapCodeFastColoredTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapCodeFastColoredTextBox.IsReplaceMode = false;
            this.mapCodeFastColoredTextBox.Location = new System.Drawing.Point(3, 3);
            this.mapCodeFastColoredTextBox.Name = "mapCodeFastColoredTextBox";
            this.mapCodeFastColoredTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.mapCodeFastColoredTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.mapCodeFastColoredTextBox.Size = new System.Drawing.Size(875, 268);
            this.mapCodeFastColoredTextBox.TabIndex = 0;
            this.mapCodeFastColoredTextBox.Zoom = 100;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.domainCodeFastColoredTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(881, 274);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Domain Code";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // domainCodeFastColoredTextBox
            // 
            this.domainCodeFastColoredTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.domainCodeFastColoredTextBox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.domainCodeFastColoredTextBox.BackBrush = null;
            this.domainCodeFastColoredTextBox.CharHeight = 14;
            this.domainCodeFastColoredTextBox.CharWidth = 8;
            this.domainCodeFastColoredTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.domainCodeFastColoredTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.domainCodeFastColoredTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.domainCodeFastColoredTextBox.IsReplaceMode = false;
            this.domainCodeFastColoredTextBox.Location = new System.Drawing.Point(3, 3);
            this.domainCodeFastColoredTextBox.Name = "domainCodeFastColoredTextBox";
            this.domainCodeFastColoredTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.domainCodeFastColoredTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.domainCodeFastColoredTextBox.Size = new System.Drawing.Size(875, 268);
            this.domainCodeFastColoredTextBox.TabIndex = 0;
            this.domainCodeFastColoredTextBox.Zoom = 100;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.splitContainer2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 373);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1122, 294);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 18);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.cancelButton);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.nameSpaceTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.namespaceMapTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.entityNameTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.generateButton);
            this.splitContainer2.Panel1.Controls.Add(this.domainFolderTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.mappingFolderTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.assemblyNameTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.domainFolderSelectButton);
            this.splitContainer2.Panel1.Controls.Add(this.mappingFolderSelectButton);
            this.splitContainer2.Panel1.Controls.Add(this.generateAllBtn);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer2.Size = new System.Drawing.Size(1116, 273);
            this.splitContainer2.SplitterDistance = 613;
            this.splitContainer2.TabIndex = 23;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(286, 235);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(124, 26);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cance&l";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Domain Files :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Mapping Files :";
            // 
            // namespaceMapTextBox
            // 
            this.namespaceMapTextBox.Location = new System.Drawing.Point(146, 94);
            this.namespaceMapTextBox.Name = "namespaceMapTextBox";
            this.namespaceMapTextBox.Size = new System.Drawing.Size(450, 22);
            this.namespaceMapTextBox.TabIndex = 12;
            this.namespaceMapTextBox.Text = "Zen.Maps";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Entity Name :";
            // 
            // entityNameTextBox
            // 
            this.entityNameTextBox.Location = new System.Drawing.Point(146, 193);
            this.entityNameTextBox.Name = "entityNameTextBox";
            this.entityNameTextBox.Size = new System.Drawing.Size(450, 22);
            this.entityNameTextBox.TabIndex = 20;
            // 
            // domainFolderTextBox
            // 
            this.domainFolderTextBox.Location = new System.Drawing.Point(146, 61);
            this.domainFolderTextBox.Name = "domainFolderTextBox";
            this.domainFolderTextBox.Size = new System.Drawing.Size(450, 22);
            this.domainFolderTextBox.TabIndex = 7;
            this.domainFolderTextBox.Text = "c:\\ZenUtility\\Domain";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Namespace (Mapping) :";
            // 
            // domainFolderSelectButton
            // 
            this.domainFolderSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.domainFolderSelectButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.domainFolderSelectButton.Location = new System.Drawing.Point(120, 61);
            this.domainFolderSelectButton.Name = "domainFolderSelectButton";
            this.domainFolderSelectButton.Size = new System.Drawing.Size(26, 22);
            this.domainFolderSelectButton.TabIndex = 9;
            this.domainFolderSelectButton.Text = ". . .";
            this.domainFolderSelectButton.UseVisualStyleBackColor = true;
            this.domainFolderSelectButton.Click += new System.EventHandler(this.DomainFolderSelectButtonClicked);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listView1);
            this.groupBox6.Controls.Add(this.toolStrip1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(499, 273);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Available Tools";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.listView1.LargeImageList = this.largeToolImageList;
            this.listView1.Location = new System.Drawing.Point(3, 43);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(493, 227);
            this.listView1.SmallImageList = this.smallToolImageList;
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // largeToolImageList
            // 
            this.largeToolImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeToolImageList.ImageStream")));
            this.largeToolImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeToolImageList.Images.SetKeyName(0, "utility.ico");
            // 
            // smallToolImageList
            // 
            this.smallToolImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallToolImageList.ImageStream")));
            this.smallToolImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallToolImageList.Images.SetKeyName(0, "utility.ico");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolButton,
            this.openToolInTabButton,
            this.openToolInWindowButton,
            this.refreshAvailableToolsButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(493, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addNewToolButton
            // 
            this.addNewToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNewToolButton.Image = global::Zen.Utility.Properties.Resources.Add;
            this.addNewToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNewToolButton.Name = "addNewToolButton";
            this.addNewToolButton.Size = new System.Drawing.Size(23, 22);
            this.addNewToolButton.Text = "New...";
            this.addNewToolButton.ToolTipText = "Add a New Tool";
            // 
            // openToolInTabButton
            // 
            this.openToolInTabButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolInTabButton.Image = global::Zen.Utility.Properties.Resources.View;
            this.openToolInTabButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolInTabButton.Name = "openToolInTabButton";
            this.openToolInTabButton.Size = new System.Drawing.Size(23, 22);
            this.openToolInTabButton.Text = "Open";
            this.openToolInTabButton.ToolTipText = "Open Selected Tool in a New Tab";
            // 
            // openToolInWindowButton
            // 
            this.openToolInWindowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolInWindowButton.Image = global::Zen.Utility.Properties.Resources.WindowsHS;
            this.openToolInWindowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolInWindowButton.Name = "openToolInWindowButton";
            this.openToolInWindowButton.Size = new System.Drawing.Size(23, 22);
            this.openToolInWindowButton.Text = "Open";
            this.openToolInWindowButton.ToolTipText = "Open Selected Tool in a New Window";
            // 
            // refreshAvailableToolsButton
            // 
            this.refreshAvailableToolsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshAvailableToolsButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshAvailableToolsButton.Image")));
            this.refreshAvailableToolsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshAvailableToolsButton.Name = "refreshAvailableToolsButton";
            this.refreshAvailableToolsButton.Size = new System.Drawing.Size(50, 22);
            this.refreshAvailableToolsButton.Text = "Refresh";
            this.refreshAvailableToolsButton.ToolTipText = "Loads all user controls from the .\\Tools folder";
            this.refreshAvailableToolsButton.Click += new System.EventHandler(this.RefreshAvailableToolsButtonClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.pOracleOnlyOptions);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.connectionNameComboBox);
            this.groupBox4.Controls.Add(this.connectionButton);
            this.groupBox4.Controls.Add(this.connectButton);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1122, 63);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "";
            this.groupBox4.Text = "Database Connection";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(606, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 26);
            this.button2.TabIndex = 24;
            this.button2.Text = "Create Schema";
            this.toolTip1.SetToolTip(this.button2, "Create Schema from Mapping Assembly");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pOracleOnlyOptions
            // 
            this.pOracleOnlyOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pOracleOnlyOptions.Controls.Add(this.label5);
            this.pOracleOnlyOptions.Controls.Add(this.sequencesComboBox);
            this.pOracleOnlyOptions.Location = new System.Drawing.Point(833, 11);
            this.pOracleOnlyOptions.Name = "pOracleOnlyOptions";
            this.pOracleOnlyOptions.Size = new System.Drawing.Size(284, 50);
            this.pOracleOnlyOptions.TabIndex = 20;
            this.pOracleOnlyOptions.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(336, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 22);
            this.textBox1.TabIndex = 23;
            this.textBox1.Tag = "Enter a database name...";
            this.textBox1.Text = "Enter a database name...";
            this.toolTip1.SetToolTip(this.textBox1, "Enter a database name...");
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(476, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 26);
            this.button1.TabIndex = 22;
            this.button1.Text = "Create Database";
            this.toolTip1.SetToolTip(this.button1, "Create Database using the current connection");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // connectionNameComboBox
            // 
            this.connectionNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectionNameComboBox.FormattingEnabled = true;
            this.connectionNameComboBox.Location = new System.Drawing.Point(7, 24);
            this.connectionNameComboBox.Name = "connectionNameComboBox";
            this.connectionNameComboBox.Size = new System.Drawing.Size(217, 24);
            this.connectionNameComboBox.Sorted = true;
            this.connectionNameComboBox.TabIndex = 21;
            // 
            // connectionButton
            // 
            this.connectionButton.Location = new System.Drawing.Point(225, 23);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(26, 26);
            this.connectionButton.TabIndex = 2;
            this.connectionButton.Text = ". . .";
            this.connectionButton.UseVisualStyleBackColor = true;
            // 
            // advanceSettingsTabPage
            // 
            this.advanceSettingsTabPage.Controls.Add(this.tablePrefixGroupBox);
            this.advanceSettingsTabPage.Controls.Add(this.filesGroupBox);
            this.advanceSettingsTabPage.Controls.Add(this.mappingOptionsGroupBox);
            this.advanceSettingsTabPage.Controls.Add(this.fieldOrPropertyOptionsGroup);
            this.advanceSettingsTabPage.Controls.Add(this.validationStyleGroupBox);
            this.advanceSettingsTabPage.Controls.Add(this.mappingStyleGroupBox);
            this.advanceSettingsTabPage.Controls.Add(this.languageGroupBox);
            this.advanceSettingsTabPage.Controls.Add(this.generatedPropertyGroupBox);
            this.advanceSettingsTabPage.Location = new System.Drawing.Point(4, 25);
            this.advanceSettingsTabPage.Name = "advanceSettingsTabPage";
            this.advanceSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.advanceSettingsTabPage.Size = new System.Drawing.Size(1128, 670);
            this.advanceSettingsTabPage.TabIndex = 2;
            this.advanceSettingsTabPage.Text = "Preferences";
            this.advanceSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // tablePrefixGroupBox
            // 
            this.tablePrefixGroupBox.Controls.Add(this.removeFieldPrefixButton);
            this.tablePrefixGroupBox.Controls.Add(this.addFieldPrefixButton);
            this.tablePrefixGroupBox.Controls.Add(this.fieldPrefixListBox);
            this.tablePrefixGroupBox.Controls.Add(this.label7);
            this.tablePrefixGroupBox.Controls.Add(this.fieldPrefixTextBox);
            this.tablePrefixGroupBox.Location = new System.Drawing.Point(8, 186);
            this.tablePrefixGroupBox.Name = "tablePrefixGroupBox";
            this.tablePrefixGroupBox.Size = new System.Drawing.Size(280, 288);
            this.tablePrefixGroupBox.TabIndex = 8;
            this.tablePrefixGroupBox.TabStop = false;
            this.tablePrefixGroupBox.Text = "Table and Field Formatting";
            // 
            // removeFieldPrefixButton
            // 
            this.removeFieldPrefixButton.Location = new System.Drawing.Point(191, 75);
            this.removeFieldPrefixButton.Name = "removeFieldPrefixButton";
            this.removeFieldPrefixButton.Size = new System.Drawing.Size(63, 28);
            this.removeFieldPrefixButton.TabIndex = 7;
            this.removeFieldPrefixButton.Text = "Remove";
            this.removeFieldPrefixButton.UseVisualStyleBackColor = true;
            this.removeFieldPrefixButton.Click += new System.EventHandler(this.RemoveFieldPrefixButtonClicked);
            // 
            // addFieldPrefixButton
            // 
            this.addFieldPrefixButton.Location = new System.Drawing.Point(191, 50);
            this.addFieldPrefixButton.Name = "addFieldPrefixButton";
            this.addFieldPrefixButton.Size = new System.Drawing.Size(63, 26);
            this.addFieldPrefixButton.TabIndex = 7;
            this.addFieldPrefixButton.Text = "Add";
            this.addFieldPrefixButton.UseVisualStyleBackColor = true;
            this.addFieldPrefixButton.Click += new System.EventHandler(this.AddFieldPrefixButtonClicked);
            // 
            // fieldPrefixListBox
            // 
            this.fieldPrefixListBox.FormattingEnabled = true;
            this.fieldPrefixListBox.ItemHeight = 16;
            this.fieldPrefixListBox.Location = new System.Drawing.Point(22, 76);
            this.fieldPrefixListBox.Name = "fieldPrefixListBox";
            this.fieldPrefixListBox.Size = new System.Drawing.Size(166, 196);
            this.fieldPrefixListBox.TabIndex = 6;
            this.fieldPrefixListBox.SelectedIndexChanged += new System.EventHandler(this.OnFieldPrefixListBoxSelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Remove these prefixes from field and table names.";
            // 
            // fieldPrefixTextBox
            // 
            this.fieldPrefixTextBox.Location = new System.Drawing.Point(22, 53);
            this.fieldPrefixTextBox.Name = "fieldPrefixTextBox";
            this.fieldPrefixTextBox.Size = new System.Drawing.Size(166, 22);
            this.fieldPrefixTextBox.TabIndex = 4;
            // 
            // filesGroupBox
            // 
            this.filesGroupBox.Controls.Add(this.generateInFoldersCheckBox);
            this.filesGroupBox.Location = new System.Drawing.Point(308, 6);
            this.filesGroupBox.Name = "filesGroupBox";
            this.filesGroupBox.Size = new System.Drawing.Size(280, 46);
            this.filesGroupBox.TabIndex = 8;
            this.filesGroupBox.TabStop = false;
            this.filesGroupBox.Text = "Files";
            // 
            // generateInFoldersCheckBox
            // 
            this.generateInFoldersCheckBox.AutoSize = true;
            this.generateInFoldersCheckBox.Location = new System.Drawing.Point(14, 17);
            this.generateInFoldersCheckBox.Name = "generateInFoldersCheckBox";
            this.generateInFoldersCheckBox.Size = new System.Drawing.Size(180, 20);
            this.generateInFoldersCheckBox.TabIndex = 0;
            this.generateInFoldersCheckBox.Text = "Group generated files in folders";
            this.generateInFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // mappingOptionsGroupBox
            // 
            this.mappingOptionsGroupBox.Controls.Add(this.label10);
            this.mappingOptionsGroupBox.Controls.Add(this.comboBoxForeignCollection);
            this.mappingOptionsGroupBox.Controls.Add(this.wcfDataContractCheckBox);
            this.mappingOptionsGroupBox.Controls.Add(this.labelForeignEntity);
            this.mappingOptionsGroupBox.Controls.Add(this.partialClassesCheckBox);
            this.mappingOptionsGroupBox.Controls.Add(this.labelCLassNamePrefix);
            this.mappingOptionsGroupBox.Controls.Add(this.labelInheritence);
            this.mappingOptionsGroupBox.Controls.Add(this.classNamePrefixTextBox);
            this.mappingOptionsGroupBox.Controls.Add(this.inheritenceTextBox);
            this.mappingOptionsGroupBox.Location = new System.Drawing.Point(308, 239);
            this.mappingOptionsGroupBox.Name = "mappingOptionsGroupBox";
            this.mappingOptionsGroupBox.Size = new System.Drawing.Size(280, 237);
            this.mappingOptionsGroupBox.TabIndex = 6;
            this.mappingOptionsGroupBox.TabStop = false;
            this.mappingOptionsGroupBox.Text = "Mapping Options";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "(e.g. Entity<T>, ISomeInterface<T>):  ";
            // 
            // comboBoxForeignCollection
            // 
            this.comboBoxForeignCollection.AllowDrop = true;
            this.comboBoxForeignCollection.FormattingEnabled = true;
            this.comboBoxForeignCollection.Items.AddRange(new object[] {
            "ISet",
            "IList",
            "ICollection",
            "Iesi.Collections.Generic.ISet"});
            this.comboBoxForeignCollection.Location = new System.Drawing.Point(17, 159);
            this.comboBoxForeignCollection.Name = "comboBoxForeignCollection";
            this.comboBoxForeignCollection.Size = new System.Drawing.Size(224, 24);
            this.comboBoxForeignCollection.TabIndex = 20;
            // 
            // wcfDataContractCheckBox
            // 
            this.wcfDataContractCheckBox.AutoSize = true;
            this.wcfDataContractCheckBox.Location = new System.Drawing.Point(15, 111);
            this.wcfDataContractCheckBox.Name = "wcfDataContractCheckBox";
            this.wcfDataContractCheckBox.Size = new System.Drawing.Size(181, 20);
            this.wcfDataContractCheckBox.TabIndex = 1;
            this.wcfDataContractCheckBox.Text = "Generate WCF Data Contracts";
            this.wcfDataContractCheckBox.UseVisualStyleBackColor = true;
            // 
            // labelForeignEntity
            // 
            this.labelForeignEntity.AutoSize = true;
            this.labelForeignEntity.Location = new System.Drawing.Point(14, 139);
            this.labelForeignEntity.Name = "labelForeignEntity";
            this.labelForeignEntity.Size = new System.Drawing.Size(208, 16);
            this.labelForeignEntity.TabIndex = 6;
            this.labelForeignEntity.Text = "Preferred Foreign Entity Collection Type:";
            // 
            // partialClassesCheckBox
            // 
            this.partialClassesCheckBox.AutoSize = true;
            this.partialClassesCheckBox.Location = new System.Drawing.Point(15, 83);
            this.partialClassesCheckBox.Name = "partialClassesCheckBox";
            this.partialClassesCheckBox.Size = new System.Drawing.Size(148, 20);
            this.partialClassesCheckBox.TabIndex = 0;
            this.partialClassesCheckBox.Text = "Generate Partial Classes";
            this.partialClassesCheckBox.UseVisualStyleBackColor = true;
            // 
            // labelCLassNamePrefix
            // 
            this.labelCLassNamePrefix.AutoSize = true;
            this.labelCLassNamePrefix.Location = new System.Drawing.Point(14, 197);
            this.labelCLassNamePrefix.Name = "labelCLassNamePrefix";
            this.labelCLassNamePrefix.Size = new System.Drawing.Size(100, 16);
            this.labelCLassNamePrefix.TabIndex = 5;
            this.labelCLassNamePrefix.Text = "Class Name Prefix:";
            // 
            // labelInheritence
            // 
            this.labelInheritence.AutoSize = true;
            this.labelInheritence.Location = new System.Drawing.Point(12, 23);
            this.labelInheritence.Name = "labelInheritence";
            this.labelInheritence.Size = new System.Drawing.Size(127, 16);
            this.labelInheritence.TabIndex = 5;
            this.labelInheritence.Text = "Inheritence && Interfaces";
            // 
            // classNamePrefixTextBox
            // 
            this.classNamePrefixTextBox.Location = new System.Drawing.Point(128, 194);
            this.classNamePrefixTextBox.Name = "classNamePrefixTextBox";
            this.classNamePrefixTextBox.Size = new System.Drawing.Size(114, 22);
            this.classNamePrefixTextBox.TabIndex = 4;
            // 
            // inheritenceTextBox
            // 
            this.inheritenceTextBox.Location = new System.Drawing.Point(15, 56);
            this.inheritenceTextBox.Name = "inheritenceTextBox";
            this.inheritenceTextBox.Size = new System.Drawing.Size(227, 22);
            this.inheritenceTextBox.TabIndex = 4;
            // 
            // fieldOrPropertyOptionsGroup
            // 
            this.fieldOrPropertyOptionsGroup.Controls.Add(this.nameAsForeignTableCheckBox);
            this.fieldOrPropertyOptionsGroup.Controls.Add(this.includeHasManyCheckBox);
            this.fieldOrPropertyOptionsGroup.Controls.Add(this.includeLengthAndScaleCheckBox);
            this.fieldOrPropertyOptionsGroup.Controls.Add(this.autoPropertyOption);
            this.fieldOrPropertyOptionsGroup.Controls.Add(this.propertyOption);
            this.fieldOrPropertyOptionsGroup.Controls.Add(this.fieldOption);
            this.fieldOrPropertyOptionsGroup.Controls.Add(this.useLazyLoadingCheckBox);
            this.fieldOrPropertyOptionsGroup.Controls.Add(this.includeForeignKeysCheckBox);
            this.fieldOrPropertyOptionsGroup.Location = new System.Drawing.Point(608, 193);
            this.fieldOrPropertyOptionsGroup.Name = "fieldOrPropertyOptionsGroup";
            this.fieldOrPropertyOptionsGroup.Size = new System.Drawing.Size(270, 282);
            this.fieldOrPropertyOptionsGroup.TabIndex = 7;
            this.fieldOrPropertyOptionsGroup.TabStop = false;
            this.fieldOrPropertyOptionsGroup.Text = "Field Or Property Options";
            // 
            // nameAsForeignTableCheckBox
            // 
            this.nameAsForeignTableCheckBox.AutoSize = true;
            this.nameAsForeignTableCheckBox.Location = new System.Drawing.Point(34, 165);
            this.nameAsForeignTableCheckBox.Name = "nameAsForeignTableCheckBox";
            this.nameAsForeignTableCheckBox.Size = new System.Drawing.Size(138, 20);
            this.nameAsForeignTableCheckBox.TabIndex = 11;
            this.nameAsForeignTableCheckBox.Text = "Name as Foreign Table";
            this.nameAsForeignTableCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeHasManyCheckBox
            // 
            this.includeHasManyCheckBox.AutoSize = true;
            this.includeHasManyCheckBox.Location = new System.Drawing.Point(7, 193);
            this.includeHasManyCheckBox.Name = "includeHasManyCheckBox";
            this.includeHasManyCheckBox.Size = new System.Drawing.Size(171, 20);
            this.includeHasManyCheckBox.TabIndex = 10;
            this.includeHasManyCheckBox.Text = "Include \"Has Many\" (Inverse\'s)";
            this.includeHasManyCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeLengthAndScaleCheckBox
            // 
            this.includeLengthAndScaleCheckBox.AutoSize = true;
            this.includeLengthAndScaleCheckBox.Location = new System.Drawing.Point(7, 222);
            this.includeLengthAndScaleCheckBox.Name = "includeLengthAndScaleCheckBox";
            this.includeLengthAndScaleCheckBox.Size = new System.Drawing.Size(149, 20);
            this.includeLengthAndScaleCheckBox.TabIndex = 9;
            this.includeLengthAndScaleCheckBox.Text = "Include Length and Scale";
            this.includeLengthAndScaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoPropertyOption
            // 
            this.autoPropertyOption.AutoSize = true;
            this.autoPropertyOption.Checked = true;
            this.autoPropertyOption.Location = new System.Drawing.Point(7, 80);
            this.autoPropertyOption.Name = "autoPropertyOption";
            this.autoPropertyOption.Size = new System.Drawing.Size(95, 20);
            this.autoPropertyOption.TabIndex = 6;
            this.autoPropertyOption.TabStop = true;
            this.autoPropertyOption.Text = "Auto Property";
            this.autoPropertyOption.UseVisualStyleBackColor = true;
            // 
            // propertyOption
            // 
            this.propertyOption.AutoSize = true;
            this.propertyOption.Location = new System.Drawing.Point(7, 51);
            this.propertyOption.Name = "propertyOption";
            this.propertyOption.Size = new System.Drawing.Size(68, 20);
            this.propertyOption.TabIndex = 5;
            this.propertyOption.Text = "Property";
            this.propertyOption.UseVisualStyleBackColor = true;
            // 
            // fieldOption
            // 
            this.fieldOption.AutoSize = true;
            this.fieldOption.Location = new System.Drawing.Point(7, 23);
            this.fieldOption.Name = "fieldOption";
            this.fieldOption.Size = new System.Drawing.Size(51, 20);
            this.fieldOption.TabIndex = 4;
            this.fieldOption.Text = "Field";
            this.fieldOption.UseVisualStyleBackColor = true;
            // 
            // useLazyLoadingCheckBox
            // 
            this.useLazyLoadingCheckBox.AutoSize = true;
            this.useLazyLoadingCheckBox.Location = new System.Drawing.Point(7, 109);
            this.useLazyLoadingCheckBox.Name = "useLazyLoadingCheckBox";
            this.useLazyLoadingCheckBox.Size = new System.Drawing.Size(113, 20);
            this.useLazyLoadingCheckBox.TabIndex = 7;
            this.useLazyLoadingCheckBox.Text = "Use Lazy Loading";
            this.useLazyLoadingCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeForeignKeysCheckBox
            // 
            this.includeForeignKeysCheckBox.AutoSize = true;
            this.includeForeignKeysCheckBox.Location = new System.Drawing.Point(7, 137);
            this.includeForeignKeysCheckBox.Name = "includeForeignKeysCheckBox";
            this.includeForeignKeysCheckBox.Size = new System.Drawing.Size(128, 20);
            this.includeForeignKeysCheckBox.TabIndex = 8;
            this.includeForeignKeysCheckBox.Text = "Include Foreign Keys";
            this.includeForeignKeysCheckBox.UseVisualStyleBackColor = true;
            this.includeForeignKeysCheckBox.CheckedChanged += new System.EventHandler(this.IncludeForeignKeysCheckBoxCheckedChanged);
            // 
            // validationStyleGroupBox
            // 
            this.validationStyleGroupBox.Controls.Add(this.dataAnnotationsOption);
            this.validationStyleGroupBox.Controls.Add(this.noValidationOption);
            this.validationStyleGroupBox.Controls.Add(this.nhibernateValidationOption);
            this.validationStyleGroupBox.Location = new System.Drawing.Point(8, 58);
            this.validationStyleGroupBox.Name = "validationStyleGroupBox";
            this.validationStyleGroupBox.Size = new System.Drawing.Size(280, 121);
            this.validationStyleGroupBox.TabIndex = 6;
            this.validationStyleGroupBox.TabStop = false;
            this.validationStyleGroupBox.Text = "Validation Style";
            // 
            // dataAnnotationsOption
            // 
            this.dataAnnotationsOption.AutoSize = true;
            this.dataAnnotationsOption.Location = new System.Drawing.Point(7, 49);
            this.dataAnnotationsOption.Name = "dataAnnotationsOption";
            this.dataAnnotationsOption.Size = new System.Drawing.Size(136, 20);
            this.dataAnnotationsOption.TabIndex = 5;
            this.dataAnnotationsOption.Text = ".Net Data Annotations";
            this.dataAnnotationsOption.UseVisualStyleBackColor = true;
            // 
            // noValidationOption
            // 
            this.noValidationOption.AutoSize = true;
            this.noValidationOption.Checked = true;
            this.noValidationOption.Location = new System.Drawing.Point(7, 21);
            this.noValidationOption.Name = "noValidationOption";
            this.noValidationOption.Size = new System.Drawing.Size(53, 20);
            this.noValidationOption.TabIndex = 4;
            this.noValidationOption.TabStop = true;
            this.noValidationOption.Text = "None";
            this.noValidationOption.UseVisualStyleBackColor = true;
            // 
            // nhibernateValidationOption
            // 
            this.nhibernateValidationOption.AutoSize = true;
            this.nhibernateValidationOption.Location = new System.Drawing.Point(7, 78);
            this.nhibernateValidationOption.Name = "nhibernateValidationOption";
            this.nhibernateValidationOption.Size = new System.Drawing.Size(139, 20);
            this.nhibernateValidationOption.TabIndex = 4;
            this.nhibernateValidationOption.Text = "NHibernate Validators";
            this.nhibernateValidationOption.UseVisualStyleBackColor = true;
            // 
            // mappingStyleGroupBox
            // 
            this.mappingStyleGroupBox.Controls.Add(this.entityFrameworkOption);
            this.mappingStyleGroupBox.Controls.Add(this.castleMappingOption);
            this.mappingStyleGroupBox.Controls.Add(this.fluentMappingOption);
            this.mappingStyleGroupBox.Controls.Add(this.hbmMappingOption);
            this.mappingStyleGroupBox.Controls.Add(this.byCodeMappingOption);
            this.mappingStyleGroupBox.Location = new System.Drawing.Point(308, 59);
            this.mappingStyleGroupBox.Name = "mappingStyleGroupBox";
            this.mappingStyleGroupBox.Size = new System.Drawing.Size(280, 173);
            this.mappingStyleGroupBox.TabIndex = 6;
            this.mappingStyleGroupBox.TabStop = false;
            this.mappingStyleGroupBox.Text = "Mapping Style";
            // 
            // entityFrameworkOption
            // 
            this.entityFrameworkOption.AutoSize = true;
            this.entityFrameworkOption.Location = new System.Drawing.Point(7, 108);
            this.entityFrameworkOption.Name = "entityFrameworkOption";
            this.entityFrameworkOption.Size = new System.Drawing.Size(113, 20);
            this.entityFrameworkOption.TabIndex = 11;
            this.entityFrameworkOption.Text = "Entity Framework";
            this.entityFrameworkOption.UseVisualStyleBackColor = true;
            // 
            // castleMappingOption
            // 
            this.castleMappingOption.AutoSize = true;
            this.castleMappingOption.Location = new System.Drawing.Point(7, 80);
            this.castleMappingOption.Name = "castleMappingOption";
            this.castleMappingOption.Size = new System.Drawing.Size(130, 20);
            this.castleMappingOption.TabIndex = 8;
            this.castleMappingOption.Text = "Castle Active Record";
            this.castleMappingOption.UseVisualStyleBackColor = true;
            // 
            // fluentMappingOption
            // 
            this.fluentMappingOption.AutoSize = true;
            this.fluentMappingOption.Location = new System.Drawing.Point(7, 51);
            this.fluentMappingOption.Name = "fluentMappingOption";
            this.fluentMappingOption.Size = new System.Drawing.Size(103, 20);
            this.fluentMappingOption.TabIndex = 5;
            this.fluentMappingOption.Text = "Fluent Mapping";
            this.fluentMappingOption.UseVisualStyleBackColor = true;
            // 
            // hbmMappingOption
            // 
            this.hbmMappingOption.AutoSize = true;
            this.hbmMappingOption.Location = new System.Drawing.Point(7, 134);
            this.hbmMappingOption.Name = "hbmMappingOption";
            this.hbmMappingOption.Size = new System.Drawing.Size(89, 20);
            this.hbmMappingOption.TabIndex = 4;
            this.hbmMappingOption.Text = ".hbm.xml file";
            this.hbmMappingOption.UseVisualStyleBackColor = true;
            // 
            // byCodeMappingOption
            // 
            this.byCodeMappingOption.AutoSize = true;
            this.byCodeMappingOption.Checked = true;
            this.byCodeMappingOption.Location = new System.Drawing.Point(7, 23);
            this.byCodeMappingOption.Name = "byCodeMappingOption";
            this.byCodeMappingOption.Size = new System.Drawing.Size(213, 20);
            this.byCodeMappingOption.TabIndex = 10;
            this.byCodeMappingOption.TabStop = true;
            this.byCodeMappingOption.Text = "By Code Mapping (NH3.2 Loquacious)";
            this.byCodeMappingOption.UseVisualStyleBackColor = true;
            // 
            // languageGroupBox
            // 
            this.languageGroupBox.Controls.Add(this.vbOption);
            this.languageGroupBox.Controls.Add(this.cSharpOption);
            this.languageGroupBox.Location = new System.Drawing.Point(8, 6);
            this.languageGroupBox.Name = "languageGroupBox";
            this.languageGroupBox.Size = new System.Drawing.Size(280, 45);
            this.languageGroupBox.TabIndex = 2;
            this.languageGroupBox.TabStop = false;
            this.languageGroupBox.Text = "Language";
            // 
            // vbOption
            // 
            this.vbOption.AutoSize = true;
            this.vbOption.Location = new System.Drawing.Point(98, 16);
            this.vbOption.Name = "vbOption";
            this.vbOption.Size = new System.Drawing.Size(43, 20);
            this.vbOption.TabIndex = 5;
            this.vbOption.Text = "VB";
            this.vbOption.UseVisualStyleBackColor = true;
            // 
            // cSharpOption
            // 
            this.cSharpOption.AutoSize = true;
            this.cSharpOption.Checked = true;
            this.cSharpOption.Location = new System.Drawing.Point(7, 16);
            this.cSharpOption.Name = "cSharpOption";
            this.cSharpOption.Size = new System.Drawing.Size(46, 20);
            this.cSharpOption.TabIndex = 4;
            this.cSharpOption.TabStop = true;
            this.cSharpOption.Text = "C#";
            this.cSharpOption.UseVisualStyleBackColor = true;
            // 
            // generatedPropertyGroupBox
            // 
            this.generatedPropertyGroupBox.Controls.Add(this.enableInflectionsCheckBox);
            this.generatedPropertyGroupBox.Controls.Add(this.pascalCasedOption);
            this.generatedPropertyGroupBox.Controls.Add(this.prefixTextBox);
            this.generatedPropertyGroupBox.Controls.Add(this.prefixedOption);
            this.generatedPropertyGroupBox.Controls.Add(this.prefixLabel);
            this.generatedPropertyGroupBox.Controls.Add(this.camelCasedOption);
            this.generatedPropertyGroupBox.Controls.Add(this.sameAsDatabaseOption);
            this.generatedPropertyGroupBox.Location = new System.Drawing.Point(608, 6);
            this.generatedPropertyGroupBox.Name = "generatedPropertyGroupBox";
            this.generatedPropertyGroupBox.Size = new System.Drawing.Size(270, 181);
            this.generatedPropertyGroupBox.TabIndex = 1;
            this.generatedPropertyGroupBox.TabStop = false;
            this.generatedPropertyGroupBox.Text = "Generated Property Name";
            // 
            // enableInflectionsCheckBox
            // 
            this.enableInflectionsCheckBox.AutoSize = true;
            this.enableInflectionsCheckBox.Location = new System.Drawing.Point(7, 137);
            this.enableInflectionsCheckBox.Name = "enableInflectionsCheckBox";
            this.enableInflectionsCheckBox.Size = new System.Drawing.Size(230, 20);
            this.enableInflectionsCheckBox.TabIndex = 22;
            this.enableInflectionsCheckBox.Text = "Load Inflections to Singularize or Pruralize";
            this.enableInflectionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // pascalCasedOption
            // 
            this.pascalCasedOption.AutoSize = true;
            this.pascalCasedOption.Checked = true;
            this.pascalCasedOption.Location = new System.Drawing.Point(7, 80);
            this.pascalCasedOption.Name = "pascalCasedOption";
            this.pascalCasedOption.Size = new System.Drawing.Size(222, 20);
            this.pascalCasedOption.TabIndex = 4;
            this.pascalCasedOption.TabStop = true;
            this.pascalCasedOption.Text = "Pascal Case (e.g. ThisIsMyColumnName)";
            this.pascalCasedOption.UseVisualStyleBackColor = true;
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(89, 108);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(46, 22);
            this.prefixTextBox.TabIndex = 3;
            this.prefixTextBox.Text = "m_";
            this.prefixTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // prefixedOption
            // 
            this.prefixedOption.AutoSize = true;
            this.prefixedOption.Location = new System.Drawing.Point(7, 109);
            this.prefixedOption.Name = "prefixedOption";
            this.prefixedOption.Size = new System.Drawing.Size(251, 20);
            this.prefixedOption.TabIndex = 2;
            this.prefixedOption.Text = "Prefixed (e.g. m_               ThisIsMyColumnName)";
            this.prefixedOption.UseVisualStyleBackColor = true;
            // 
            // prefixLabel
            // 
            this.prefixLabel.AutoSize = true;
            this.prefixLabel.Location = new System.Drawing.Point(265, 113);
            this.prefixLabel.Name = "prefixLabel";
            this.prefixLabel.Size = new System.Drawing.Size(0, 16);
            this.prefixLabel.TabIndex = 2;
            // 
            // camelCasedOption
            // 
            this.camelCasedOption.AutoSize = true;
            this.camelCasedOption.Location = new System.Drawing.Point(7, 51);
            this.camelCasedOption.Name = "camelCasedOption";
            this.camelCasedOption.Size = new System.Drawing.Size(223, 20);
            this.camelCasedOption.TabIndex = 1;
            this.camelCasedOption.Text = "Camel Case (e.g. thisIsMyColumnName)";
            this.camelCasedOption.UseVisualStyleBackColor = true;
            // 
            // sameAsDatabaseOption
            // 
            this.sameAsDatabaseOption.AutoSize = true;
            this.sameAsDatabaseOption.Location = new System.Drawing.Point(7, 23);
            this.sameAsDatabaseOption.Name = "sameAsDatabaseOption";
            this.sameAsDatabaseOption.Size = new System.Drawing.Size(238, 20);
            this.sameAsDatabaseOption.TabIndex = 0;
            this.sameAsDatabaseOption.Text = "Same as database column name (No change)";
            this.sameAsDatabaseOption.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 705);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1136, 25);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 19);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoToolTip = true;
            this.toolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(817, 20);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ApplicationUx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1136, 730);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainTabControl);
            this.Font = new System.Drawing.Font("Poor Richard", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ApplicationUx";
            this.Opacity = 0.95D;
            this.Text = "Zen Developer Utility";
            this.TransparencyKey = System.Drawing.Color.MidnightBlue;
            ((System.ComponentModel.ISupportInitialize)(this.dbTableDetailsGridView)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.basicSettingsTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableGroupBox.ResumeLayout(false);
            this.tableGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapCodeFastColoredTextBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.domainCodeFastColoredTextBox)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.pOracleOnlyOptions.ResumeLayout(false);
            this.pOracleOnlyOptions.PerformLayout();
            this.advanceSettingsTabPage.ResumeLayout(false);
            this.tablePrefixGroupBox.ResumeLayout(false);
            this.tablePrefixGroupBox.PerformLayout();
            this.filesGroupBox.ResumeLayout(false);
            this.filesGroupBox.PerformLayout();
            this.mappingOptionsGroupBox.ResumeLayout(false);
            this.mappingOptionsGroupBox.PerformLayout();
            this.fieldOrPropertyOptionsGroup.ResumeLayout(false);
            this.fieldOrPropertyOptionsGroup.PerformLayout();
            this.validationStyleGroupBox.ResumeLayout(false);
            this.validationStyleGroupBox.PerformLayout();
            this.mappingStyleGroupBox.ResumeLayout(false);
            this.mappingStyleGroupBox.PerformLayout();
            this.languageGroupBox.ResumeLayout(false);
            this.languageGroupBox.PerformLayout();
            this.generatedPropertyGroupBox.ResumeLayout(false);
            this.generatedPropertyGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox sequencesComboBox;
        private System.Windows.Forms.DataGridView dbTableDetailsGridView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox mappingFolderTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button mappingFolderSelectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameSpaceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox assemblyNameTextBox;
        private Label label5;
        private Button generateAllBtn;
        private TabControl mainTabControl;
        private TabPage basicSettingsTabPage;
        private TabPage advanceSettingsTabPage;
        private GroupBox generatedPropertyGroupBox;
        private RadioButton sameAsDatabaseOption;
        private RadioButton prefixedOption;
        private RadioButton camelCasedOption;
        private TextBox prefixTextBox;
        private Label prefixLabel;
        private GroupBox languageGroupBox;
        private RadioButton vbOption;
        private RadioButton cSharpOption;
        private GroupBox mappingStyleGroupBox;
        private RadioButton fluentMappingOption;
        private RadioButton hbmMappingOption;
        private RadioButton byCodeMappingOption;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox tableGroupBox;
        private GroupBox fieldOrPropertyOptionsGroup;
        private RadioButton propertyOption;
        private RadioButton fieldOption;
        private RadioButton autoPropertyOption;
        private Label label6;
        private TextBox entityNameTextBox;
        private RadioButton castleMappingOption;
        private ComboBox ownersComboBox;
        private RadioButton pascalCasedOption;
        private GroupBox mappingOptionsGroupBox;
        private CheckBox partialClassesCheckBox;
        private Panel pOracleOnlyOptions;
        private Button cancelButton;
        private CheckBox wcfDataContractCheckBox;
        private ListBox tablesListBox;
        private Label labelInheritence;
        private TextBox inheritenceTextBox;
        private ComboBox comboBoxForeignCollection;
        private Label labelForeignEntity;
        private Label labelCLassNamePrefix;
        private TextBox classNamePrefixTextBox;
        private GroupBox filesGroupBox;
        private CheckBox generateInFoldersCheckBox;
        private CheckBox useLazyLoadingCheckBox;
        private CheckBox includeForeignKeysCheckBox;
        private CheckBox includeLengthAndScaleCheckBox;
        private TextBox TableFilterTextBox;
        private GroupBox tablePrefixGroupBox;
        private Button removeFieldPrefixButton;
        private Button addFieldPrefixButton;
        private ListBox fieldPrefixListBox;
        private Label label7;
        private TextBox fieldPrefixTextBox;
        private ComboBox connectionNameComboBox;
        private Button connectionButton;
        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private FastColoredTextBoxNS.FastColoredTextBox mapCodeFastColoredTextBox;
        private FastColoredTextBoxNS.FastColoredTextBox domainCodeFastColoredTextBox;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripProgressBar toolStripProgressBar1;
        private Label label4;
        private TextBox namespaceMapTextBox;
        private DataGridViewTextBoxColumn columnName;
        private DataGridViewTextBoxColumn columnDataType;
        private DataGridViewComboBoxColumn cSharpType;
        private DataGridViewCheckBoxColumn isPrimaryKey;
        private DataGridViewCheckBoxColumn isForeignKey;
        private DataGridViewCheckBoxColumn isNullable;
        private DataGridViewCheckBoxColumn IsIdentity;
        private DataGridViewCheckBoxColumn isUniqueKey;
        private DataGridViewTextBoxColumn ConstraintName;
        private DataGridViewTextBoxColumn ForeignKeyTableName;
        private DataGridViewTextBoxColumn ForeignKeyColumnName;
        private Label label9;
        private Label label8;
        private TextBox domainFolderTextBox;
        private Button domainFolderSelectButton;
        private GroupBox validationStyleGroupBox;
        private RadioButton dataAnnotationsOption;
        private RadioButton noValidationOption;
        private RadioButton nhibernateValidationOption;
        private CheckBox includeHasManyCheckBox;
        private CheckBox enableInflectionsCheckBox;
        private CheckBox nameAsForeignTableCheckBox;
        private RadioButton entityFrameworkOption;
        private Label label10;
        private SplitContainer splitContainer2;
        private GroupBox groupBox6;
        private ListView listView1;
        private ToolStrip toolStrip1;
        private ToolStripButton openToolInTabButton;
        private ToolTip toolTip1;
        private ImageList smallToolImageList;
        private ToolStripButton addNewToolButton;
        private ToolStripButton openToolInWindowButton;
        private ToolStripButton refreshAvailableToolsButton;
        private ImageList largeToolImageList;
        private Button button2;
        private TextBox textBox1;
        private Button button1;
    }
}

