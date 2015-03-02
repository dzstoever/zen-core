using System.Windows.Forms;

namespace Zen.Utility
{
    partial class Application
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Log Configurator", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("WCF Configurator", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Application));
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
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.folderSelectButton = new System.Windows.Forms.Button();
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
            this.pOracleOnlyOptions = new System.Windows.Forms.Panel();
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
            this.connectionNameComboBox = new System.Windows.Forms.ComboBox();
            this.connectionButton = new System.Windows.Forms.Button();
            this.advanceSettingsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.removeFieldPrefixButton = new System.Windows.Forms.Button();
            this.addFieldPrefixButton = new System.Windows.Forms.Button();
            this.fieldPrefixListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fieldPrefixTextBox = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.generateInFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxForeignCollection = new System.Windows.Forms.ComboBox();
            this.wcfDataContractCheckBox = new System.Windows.Forms.CheckBox();
            this.labelForeignEntity = new System.Windows.Forms.Label();
            this.partialClassesCheckBox = new System.Windows.Forms.CheckBox();
            this.labelCLassNamePrefix = new System.Windows.Forms.Label();
            this.labelInheritence = new System.Windows.Forms.Label();
            this.textBoxClassNamePrefix = new System.Windows.Forms.TextBox();
            this.textBoxInheritence = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.nameAsForeignTableCheckBox = new System.Windows.Forms.CheckBox();
            this.includeHasManyCheckBox = new System.Windows.Forms.CheckBox();
            this.includeLengthAndScaleCheckBox = new System.Windows.Forms.CheckBox();
            this.autoPropertyRadioBtn = new System.Windows.Forms.RadioButton();
            this.propertyRadioBtn = new System.Windows.Forms.RadioButton();
            this.fieldRadioBtn = new System.Windows.Forms.RadioButton();
            this.useLazyLoadingCheckBox = new System.Windows.Forms.CheckBox();
            this.includeForeignKeysCheckBox = new System.Windows.Forms.CheckBox();
            this.validationStyleGroupBox = new System.Windows.Forms.GroupBox();
            this.dataAnnotationsRadioButton = new System.Windows.Forms.RadioButton();
            this.noValidationRadioButton = new System.Windows.Forms.RadioButton();
            this.nhibernateValidationRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.entityFrameworkRadionBtn = new System.Windows.Forms.RadioButton();
            this.castleMappingOption = new System.Windows.Forms.RadioButton();
            this.fluentMappingOption = new System.Windows.Forms.RadioButton();
            this.hbmMappingOption = new System.Windows.Forms.RadioButton();
            this.byCodeMappingOption = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vbRadioButton = new System.Windows.Forms.RadioButton();
            this.cSharpRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EnableInflectionsCheckBox = new System.Windows.Forms.CheckBox();
            this.pascalCasedRadioButton = new System.Windows.Forms.RadioButton();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.prefixRadioButton = new System.Windows.Forms.RadioButton();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.camelCasedRadioButton = new System.Windows.Forms.RadioButton();
            this.sameAsDBRadioButton = new System.Windows.Forms.RadioButton();
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
            this.pOracleOnlyOptions.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.advanceSettingsTabPage.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.validationStyleGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.connectButton.Click += new System.EventHandler(this.ConnectButtonClick);
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
            this.dbTableDetailsGridView.Size = new System.Drawing.Size(1089, 265);
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
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(146, 28);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(539, 22);
            this.folderTextBox.TabIndex = 7;
            this.folderTextBox.Text = "c:\\ZenUtility\\Maps";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(6, 234);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(124, 29);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "&Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateClicked);
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.folderSelectButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.folderSelectButton.Location = new System.Drawing.Point(685, 28);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(26, 22);
            this.folderSelectButton.TabIndex = 9;
            this.folderSelectButton.Text = ". . .";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.FolderSelectButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select the folder in which the mapping and domain files would be generated";
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
            this.nameSpaceTextBox.Size = new System.Drawing.Size(566, 22);
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
            this.assemblyNameTextBox.Size = new System.Drawing.Size(566, 22);
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
            this.generateAllBtn.Location = new System.Drawing.Point(146, 234);
            this.generateAllBtn.Name = "generateAllBtn";
            this.generateAllBtn.Size = new System.Drawing.Size(124, 29);
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
            this.mainTabControl.Size = new System.Drawing.Size(1350, 699);
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
            this.basicSettingsTabPage.Size = new System.Drawing.Size(1342, 670);
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
            this.splitContainer1.Size = new System.Drawing.Size(1336, 307);
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
            this.tabControl1.Size = new System.Drawing.Size(1103, 300);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dbTableDetailsGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1095, 271);
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
            this.tabPage2.Size = new System.Drawing.Size(1095, 274);
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
            this.mapCodeFastColoredTextBox.Size = new System.Drawing.Size(1089, 268);
            this.mapCodeFastColoredTextBox.TabIndex = 0;
            this.mapCodeFastColoredTextBox.Zoom = 100;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.domainCodeFastColoredTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1095, 274);
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
            this.domainCodeFastColoredTextBox.Size = new System.Drawing.Size(1089, 268);
            this.domainCodeFastColoredTextBox.TabIndex = 0;
            this.domainCodeFastColoredTextBox.Zoom = 100;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.splitContainer2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 373);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1336, 294);
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
            this.splitContainer2.Panel1.Controls.Add(this.pOracleOnlyOptions);
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
            this.splitContainer2.Panel1.Controls.Add(this.folderTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.assemblyNameTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.domainFolderSelectButton);
            this.splitContainer2.Panel1.Controls.Add(this.folderSelectButton);
            this.splitContainer2.Panel1.Controls.Add(this.generateAllBtn);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer2.Size = new System.Drawing.Size(1330, 273);
            this.splitContainer2.SplitterDistance = 732;
            this.splitContainer2.TabIndex = 23;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(286, 234);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(124, 29);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cance&l";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // pOracleOnlyOptions
            // 
            this.pOracleOnlyOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pOracleOnlyOptions.Controls.Add(this.label5);
            this.pOracleOnlyOptions.Controls.Add(this.sequencesComboBox);
            this.pOracleOnlyOptions.Location = new System.Drawing.Point(430, 220);
            this.pOracleOnlyOptions.Name = "pOracleOnlyOptions";
            this.pOracleOnlyOptions.Size = new System.Drawing.Size(284, 50);
            this.pOracleOnlyOptions.TabIndex = 20;
            this.pOracleOnlyOptions.Visible = false;
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
            this.namespaceMapTextBox.Size = new System.Drawing.Size(566, 22);
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
            this.entityNameTextBox.Size = new System.Drawing.Size(566, 22);
            this.entityNameTextBox.TabIndex = 20;
            // 
            // domainFolderTextBox
            // 
            this.domainFolderTextBox.Location = new System.Drawing.Point(146, 61);
            this.domainFolderTextBox.Name = "domainFolderTextBox";
            this.domainFolderTextBox.Size = new System.Drawing.Size(539, 22);
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
            this.domainFolderSelectButton.Location = new System.Drawing.Point(685, 61);
            this.domainFolderSelectButton.Name = "domainFolderSelectButton";
            this.domainFolderSelectButton.Size = new System.Drawing.Size(26, 22);
            this.domainFolderSelectButton.TabIndex = 9;
            this.domainFolderSelectButton.Text = ". . .";
            this.domainFolderSelectButton.UseVisualStyleBackColor = true;
            this.domainFolderSelectButton.Click += new System.EventHandler(this.DomainFolderSelectButtonClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listView1);
            this.groupBox6.Controls.Add(this.toolStrip1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(594, 273);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Available Tools";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.LargeImageList = this.largeToolImageList;
            this.listView1.Location = new System.Drawing.Point(3, 43);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(588, 227);
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
            this.toolStrip1.Size = new System.Drawing.Size(588, 25);
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
            this.groupBox4.Controls.Add(this.connectionNameComboBox);
            this.groupBox4.Controls.Add(this.connectionButton);
            this.groupBox4.Controls.Add(this.connectButton);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1336, 63);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "";
            this.groupBox4.Text = "Database Connection";
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
            this.advanceSettingsTabPage.Controls.Add(this.groupBox10);
            this.advanceSettingsTabPage.Controls.Add(this.groupBox9);
            this.advanceSettingsTabPage.Controls.Add(this.groupBox8);
            this.advanceSettingsTabPage.Controls.Add(this.groupBox7);
            this.advanceSettingsTabPage.Controls.Add(this.validationStyleGroupBox);
            this.advanceSettingsTabPage.Controls.Add(this.groupBox3);
            this.advanceSettingsTabPage.Controls.Add(this.groupBox2);
            this.advanceSettingsTabPage.Controls.Add(this.groupBox1);
            this.advanceSettingsTabPage.Location = new System.Drawing.Point(4, 25);
            this.advanceSettingsTabPage.Name = "advanceSettingsTabPage";
            this.advanceSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.advanceSettingsTabPage.Size = new System.Drawing.Size(1342, 670);
            this.advanceSettingsTabPage.TabIndex = 2;
            this.advanceSettingsTabPage.Text = "Preferences";
            this.advanceSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.removeFieldPrefixButton);
            this.groupBox10.Controls.Add(this.addFieldPrefixButton);
            this.groupBox10.Controls.Add(this.fieldPrefixListBox);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.fieldPrefixTextBox);
            this.groupBox10.Location = new System.Drawing.Point(8, 186);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(280, 288);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Table and Field Formatting";
            // 
            // removeFieldPrefixButton
            // 
            this.removeFieldPrefixButton.Location = new System.Drawing.Point(191, 75);
            this.removeFieldPrefixButton.Name = "removeFieldPrefixButton";
            this.removeFieldPrefixButton.Size = new System.Drawing.Size(63, 26);
            this.removeFieldPrefixButton.TabIndex = 7;
            this.removeFieldPrefixButton.Text = "Remove";
            this.removeFieldPrefixButton.UseVisualStyleBackColor = true;
            this.removeFieldPrefixButton.Click += new System.EventHandler(this.OnRemoveFieldPrefixButtonClick);
            // 
            // addFieldPrefixButton
            // 
            this.addFieldPrefixButton.Location = new System.Drawing.Point(191, 50);
            this.addFieldPrefixButton.Name = "addFieldPrefixButton";
            this.addFieldPrefixButton.Size = new System.Drawing.Size(63, 26);
            this.addFieldPrefixButton.TabIndex = 7;
            this.addFieldPrefixButton.Text = "Add";
            this.addFieldPrefixButton.UseVisualStyleBackColor = true;
            this.addFieldPrefixButton.Click += new System.EventHandler(this.OnAddFieldPrefixButtonClick);
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
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.generateInFoldersCheckBox);
            this.groupBox9.Location = new System.Drawing.Point(308, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(280, 46);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Files";
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
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.comboBoxForeignCollection);
            this.groupBox8.Controls.Add(this.wcfDataContractCheckBox);
            this.groupBox8.Controls.Add(this.labelForeignEntity);
            this.groupBox8.Controls.Add(this.partialClassesCheckBox);
            this.groupBox8.Controls.Add(this.labelCLassNamePrefix);
            this.groupBox8.Controls.Add(this.labelInheritence);
            this.groupBox8.Controls.Add(this.textBoxClassNamePrefix);
            this.groupBox8.Controls.Add(this.textBoxInheritence);
            this.groupBox8.Location = new System.Drawing.Point(308, 239);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(280, 237);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Mapping Options";
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
            // textBoxClassNamePrefix
            // 
            this.textBoxClassNamePrefix.Location = new System.Drawing.Point(128, 194);
            this.textBoxClassNamePrefix.Name = "textBoxClassNamePrefix";
            this.textBoxClassNamePrefix.Size = new System.Drawing.Size(114, 22);
            this.textBoxClassNamePrefix.TabIndex = 4;
            // 
            // textBoxInheritence
            // 
            this.textBoxInheritence.Location = new System.Drawing.Point(15, 56);
            this.textBoxInheritence.Name = "textBoxInheritence";
            this.textBoxInheritence.Size = new System.Drawing.Size(227, 22);
            this.textBoxInheritence.TabIndex = 4;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.nameAsForeignTableCheckBox);
            this.groupBox7.Controls.Add(this.includeHasManyCheckBox);
            this.groupBox7.Controls.Add(this.includeLengthAndScaleCheckBox);
            this.groupBox7.Controls.Add(this.autoPropertyRadioBtn);
            this.groupBox7.Controls.Add(this.propertyRadioBtn);
            this.groupBox7.Controls.Add(this.fieldRadioBtn);
            this.groupBox7.Controls.Add(this.useLazyLoadingCheckBox);
            this.groupBox7.Controls.Add(this.includeForeignKeysCheckBox);
            this.groupBox7.Location = new System.Drawing.Point(608, 193);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(270, 282);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Field Or Property";
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
            // autoPropertyRadioBtn
            // 
            this.autoPropertyRadioBtn.AutoSize = true;
            this.autoPropertyRadioBtn.Location = new System.Drawing.Point(7, 80);
            this.autoPropertyRadioBtn.Name = "autoPropertyRadioBtn";
            this.autoPropertyRadioBtn.Size = new System.Drawing.Size(95, 20);
            this.autoPropertyRadioBtn.TabIndex = 6;
            this.autoPropertyRadioBtn.Text = "Auto Property";
            this.autoPropertyRadioBtn.UseVisualStyleBackColor = true;
            // 
            // propertyRadioBtn
            // 
            this.propertyRadioBtn.AutoSize = true;
            this.propertyRadioBtn.Location = new System.Drawing.Point(7, 51);
            this.propertyRadioBtn.Name = "propertyRadioBtn";
            this.propertyRadioBtn.Size = new System.Drawing.Size(68, 20);
            this.propertyRadioBtn.TabIndex = 5;
            this.propertyRadioBtn.Text = "Property";
            this.propertyRadioBtn.UseVisualStyleBackColor = true;
            // 
            // fieldRadioBtn
            // 
            this.fieldRadioBtn.AutoSize = true;
            this.fieldRadioBtn.Checked = true;
            this.fieldRadioBtn.Location = new System.Drawing.Point(7, 23);
            this.fieldRadioBtn.Name = "fieldRadioBtn";
            this.fieldRadioBtn.Size = new System.Drawing.Size(51, 20);
            this.fieldRadioBtn.TabIndex = 4;
            this.fieldRadioBtn.TabStop = true;
            this.fieldRadioBtn.Text = "Field";
            this.fieldRadioBtn.UseVisualStyleBackColor = true;
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
            this.validationStyleGroupBox.Controls.Add(this.dataAnnotationsRadioButton);
            this.validationStyleGroupBox.Controls.Add(this.noValidationRadioButton);
            this.validationStyleGroupBox.Controls.Add(this.nhibernateValidationRadioButton);
            this.validationStyleGroupBox.Location = new System.Drawing.Point(8, 58);
            this.validationStyleGroupBox.Name = "validationStyleGroupBox";
            this.validationStyleGroupBox.Size = new System.Drawing.Size(280, 121);
            this.validationStyleGroupBox.TabIndex = 6;
            this.validationStyleGroupBox.TabStop = false;
            this.validationStyleGroupBox.Text = "Validation Style";
            // 
            // dataAnnotationsRadioButton
            // 
            this.dataAnnotationsRadioButton.AutoSize = true;
            this.dataAnnotationsRadioButton.Location = new System.Drawing.Point(7, 49);
            this.dataAnnotationsRadioButton.Name = "dataAnnotationsRadioButton";
            this.dataAnnotationsRadioButton.Size = new System.Drawing.Size(136, 20);
            this.dataAnnotationsRadioButton.TabIndex = 5;
            this.dataAnnotationsRadioButton.Text = ".Net Data Annotations";
            this.dataAnnotationsRadioButton.UseVisualStyleBackColor = true;
            // 
            // noValidationRadioButton
            // 
            this.noValidationRadioButton.AutoSize = true;
            this.noValidationRadioButton.Checked = true;
            this.noValidationRadioButton.Location = new System.Drawing.Point(7, 21);
            this.noValidationRadioButton.Name = "noValidationRadioButton";
            this.noValidationRadioButton.Size = new System.Drawing.Size(53, 20);
            this.noValidationRadioButton.TabIndex = 4;
            this.noValidationRadioButton.TabStop = true;
            this.noValidationRadioButton.Text = "None";
            this.noValidationRadioButton.UseVisualStyleBackColor = true;
            // 
            // nhibernateValidationRadioButton
            // 
            this.nhibernateValidationRadioButton.AutoSize = true;
            this.nhibernateValidationRadioButton.Location = new System.Drawing.Point(7, 78);
            this.nhibernateValidationRadioButton.Name = "nhibernateValidationRadioButton";
            this.nhibernateValidationRadioButton.Size = new System.Drawing.Size(139, 20);
            this.nhibernateValidationRadioButton.TabIndex = 4;
            this.nhibernateValidationRadioButton.Text = "NHibernate Validators";
            this.nhibernateValidationRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.entityFrameworkRadionBtn);
            this.groupBox3.Controls.Add(this.castleMappingOption);
            this.groupBox3.Controls.Add(this.fluentMappingOption);
            this.groupBox3.Controls.Add(this.hbmMappingOption);
            this.groupBox3.Controls.Add(this.byCodeMappingOption);
            this.groupBox3.Location = new System.Drawing.Point(308, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 173);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mapping Style";
            // 
            // entityFrameworkRadionBtn
            // 
            this.entityFrameworkRadionBtn.AutoSize = true;
            this.entityFrameworkRadionBtn.Location = new System.Drawing.Point(7, 108);
            this.entityFrameworkRadionBtn.Name = "entityFrameworkRadionBtn";
            this.entityFrameworkRadionBtn.Size = new System.Drawing.Size(113, 20);
            this.entityFrameworkRadionBtn.TabIndex = 11;
            this.entityFrameworkRadionBtn.TabStop = true;
            this.entityFrameworkRadionBtn.Text = "Entity Framework";
            this.entityFrameworkRadionBtn.UseVisualStyleBackColor = true;
            // 
            // castleMappingOption
            // 
            this.castleMappingOption.AutoSize = true;
            this.castleMappingOption.Location = new System.Drawing.Point(7, 80);
            this.castleMappingOption.Name = "castleMappingOption";
            this.castleMappingOption.Size = new System.Drawing.Size(130, 20);
            this.castleMappingOption.TabIndex = 8;
            this.castleMappingOption.TabStop = true;
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
            this.hbmMappingOption.Checked = true;
            this.hbmMappingOption.Location = new System.Drawing.Point(7, 134);
            this.hbmMappingOption.Name = "hbmMappingOption";
            this.hbmMappingOption.Size = new System.Drawing.Size(89, 20);
            this.hbmMappingOption.TabIndex = 4;
            this.hbmMappingOption.TabStop = true;
            this.hbmMappingOption.Text = ".hbm.xml file";
            this.hbmMappingOption.UseVisualStyleBackColor = true;
            // 
            // byCodeMappingOption
            // 
            this.byCodeMappingOption.AutoSize = true;
            this.byCodeMappingOption.Location = new System.Drawing.Point(7, 23);
            this.byCodeMappingOption.Name = "byCodeMappingOption";
            this.byCodeMappingOption.Size = new System.Drawing.Size(213, 20);
            this.byCodeMappingOption.TabIndex = 10;
            this.byCodeMappingOption.TabStop = true;
            this.byCodeMappingOption.Text = "By Code Mapping (NH3.2 Loquacious)";
            this.byCodeMappingOption.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vbRadioButton);
            this.groupBox2.Controls.Add(this.cSharpRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 45);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Language";
            // 
            // vbRadioButton
            // 
            this.vbRadioButton.AutoSize = true;
            this.vbRadioButton.Location = new System.Drawing.Point(98, 16);
            this.vbRadioButton.Name = "vbRadioButton";
            this.vbRadioButton.Size = new System.Drawing.Size(43, 20);
            this.vbRadioButton.TabIndex = 5;
            this.vbRadioButton.Text = "VB";
            this.vbRadioButton.UseVisualStyleBackColor = true;
            // 
            // cSharpRadioButton
            // 
            this.cSharpRadioButton.AutoSize = true;
            this.cSharpRadioButton.Checked = true;
            this.cSharpRadioButton.Location = new System.Drawing.Point(7, 16);
            this.cSharpRadioButton.Name = "cSharpRadioButton";
            this.cSharpRadioButton.Size = new System.Drawing.Size(46, 20);
            this.cSharpRadioButton.TabIndex = 4;
            this.cSharpRadioButton.TabStop = true;
            this.cSharpRadioButton.Text = "C#";
            this.cSharpRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EnableInflectionsCheckBox);
            this.groupBox1.Controls.Add(this.pascalCasedRadioButton);
            this.groupBox1.Controls.Add(this.prefixTextBox);
            this.groupBox1.Controls.Add(this.prefixRadioButton);
            this.groupBox1.Controls.Add(this.prefixLabel);
            this.groupBox1.Controls.Add(this.camelCasedRadioButton);
            this.groupBox1.Controls.Add(this.sameAsDBRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(608, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 181);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generated Property Name";
            // 
            // EnableInflectionsCheckBox
            // 
            this.EnableInflectionsCheckBox.AutoSize = true;
            this.EnableInflectionsCheckBox.Location = new System.Drawing.Point(7, 137);
            this.EnableInflectionsCheckBox.Name = "EnableInflectionsCheckBox";
            this.EnableInflectionsCheckBox.Size = new System.Drawing.Size(230, 20);
            this.EnableInflectionsCheckBox.TabIndex = 22;
            this.EnableInflectionsCheckBox.Text = "Load Inflections to Singularize or Pruralize";
            this.EnableInflectionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // pascalCasedRadioButton
            // 
            this.pascalCasedRadioButton.AutoSize = true;
            this.pascalCasedRadioButton.Location = new System.Drawing.Point(7, 80);
            this.pascalCasedRadioButton.Name = "pascalCasedRadioButton";
            this.pascalCasedRadioButton.Size = new System.Drawing.Size(222, 20);
            this.pascalCasedRadioButton.TabIndex = 4;
            this.pascalCasedRadioButton.Text = "Pascal Case (e.g. ThisIsMyColumnName)";
            this.pascalCasedRadioButton.UseVisualStyleBackColor = true;
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
            // prefixRadioButton
            // 
            this.prefixRadioButton.AutoSize = true;
            this.prefixRadioButton.Location = new System.Drawing.Point(7, 109);
            this.prefixRadioButton.Name = "prefixRadioButton";
            this.prefixRadioButton.Size = new System.Drawing.Size(251, 20);
            this.prefixRadioButton.TabIndex = 2;
            this.prefixRadioButton.Text = "Prefixed (e.g. m_               ThisIsMyColumnName)";
            this.prefixRadioButton.UseVisualStyleBackColor = true;
            this.prefixRadioButton.CheckedChanged += new System.EventHandler(this.PrefixCheckChanged);
            // 
            // prefixLabel
            // 
            this.prefixLabel.AutoSize = true;
            this.prefixLabel.Location = new System.Drawing.Point(265, 113);
            this.prefixLabel.Name = "prefixLabel";
            this.prefixLabel.Size = new System.Drawing.Size(0, 16);
            this.prefixLabel.TabIndex = 2;
            // 
            // camelCasedRadioButton
            // 
            this.camelCasedRadioButton.AutoSize = true;
            this.camelCasedRadioButton.Location = new System.Drawing.Point(7, 51);
            this.camelCasedRadioButton.Name = "camelCasedRadioButton";
            this.camelCasedRadioButton.Size = new System.Drawing.Size(223, 20);
            this.camelCasedRadioButton.TabIndex = 1;
            this.camelCasedRadioButton.Text = "Camel Case (e.g. thisIsMyColumnName)";
            this.camelCasedRadioButton.UseVisualStyleBackColor = true;
            // 
            // sameAsDBRadioButton
            // 
            this.sameAsDBRadioButton.AutoSize = true;
            this.sameAsDBRadioButton.Checked = true;
            this.sameAsDBRadioButton.Location = new System.Drawing.Point(7, 23);
            this.sameAsDBRadioButton.Name = "sameAsDBRadioButton";
            this.sameAsDBRadioButton.Size = new System.Drawing.Size(238, 20);
            this.sameAsDBRadioButton.TabIndex = 0;
            this.sameAsDBRadioButton.TabStop = true;
            this.sameAsDBRadioButton.Text = "Same as database column name (No change)";
            this.sameAsDBRadioButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 705);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1350, 25);
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
            this.toolStripStatusLabel.Size = new System.Drawing.Size(1031, 20);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainTabControl);
            this.Font = new System.Drawing.Font("Poor Richard", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Application";
            this.Text = "Zen Developer Utility";
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
            this.pOracleOnlyOptions.ResumeLayout(false);
            this.pOracleOnlyOptions.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.advanceSettingsTabPage.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.validationStyleGroupBox.ResumeLayout(false);
            this.validationStyleGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button folderSelectButton;
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
        private GroupBox groupBox1;
        private RadioButton sameAsDBRadioButton;
        private RadioButton prefixRadioButton;
        private RadioButton camelCasedRadioButton;
        private TextBox prefixTextBox;
        private Label prefixLabel;
        private GroupBox groupBox2;
        private RadioButton vbRadioButton;
        private RadioButton cSharpRadioButton;
        private GroupBox groupBox3;
        private RadioButton fluentMappingOption;
        private RadioButton hbmMappingOption;
        private RadioButton byCodeMappingOption;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox tableGroupBox;
        private GroupBox groupBox7;
        private RadioButton propertyRadioBtn;
        private RadioButton fieldRadioBtn;
        private RadioButton autoPropertyRadioBtn;
        private Label label6;
        private TextBox entityNameTextBox;
        private RadioButton castleMappingOption;
        private ComboBox ownersComboBox;
        private RadioButton pascalCasedRadioButton;
        private GroupBox groupBox8;
        private CheckBox partialClassesCheckBox;
        private Panel pOracleOnlyOptions;
        private Button cancelButton;
        private CheckBox wcfDataContractCheckBox;
        private ListBox tablesListBox;
        private Label labelInheritence;
        private TextBox textBoxInheritence;
        private ComboBox comboBoxForeignCollection;
        private Label labelForeignEntity;
        private Label labelCLassNamePrefix;
        private TextBox textBoxClassNamePrefix;
        private GroupBox groupBox9;
        private CheckBox generateInFoldersCheckBox;
        private CheckBox useLazyLoadingCheckBox;
        private CheckBox includeForeignKeysCheckBox;
        private CheckBox includeLengthAndScaleCheckBox;
        private TextBox TableFilterTextBox;
        private GroupBox groupBox10;
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
        private RadioButton dataAnnotationsRadioButton;
        private RadioButton noValidationRadioButton;
        private RadioButton nhibernateValidationRadioButton;
        private CheckBox includeHasManyCheckBox;
        private CheckBox EnableInflectionsCheckBox;
        private CheckBox nameAsForeignTableCheckBox;
        private RadioButton entityFrameworkRadionBtn;
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
    }
}

