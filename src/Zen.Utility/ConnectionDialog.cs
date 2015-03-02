using System;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using Zen.Util;
using Zen.Util.Domain;

namespace Zen.Utility
{
    public partial class ConnectionDialog : Form
    {
        private static string GetDefaultConnectionStringForServerType(ServerType serverType)
        {
            //switch (serverType)
            //{
            //    case ServerType.Oracle:
            //        return StringConstants.ORACLE_CONN_STR_TEMPLATE;
            //    case ServerType.SqlServer:
            //        return StringConstants.SQL_CONN_STR_TEMPLATE;
            //    case ServerType.MySQL:
            //        return StringConstants.MYSQL_CONN_STR_TEMPLATE;
            //    case ServerType.SQLite:
            //        return StringConstants.SQLITE_CONN_STR_TEMPLATE;
            //    case ServerType.Sybase:
            //        return StringConstants.SYBASE_CONN_STR_TEMPLATE;
            //    case ServerType.Ingres:
            //        return StringConstants.INGRES_CONN_STR_TEMPLATE;
            //    case ServerType.CUBRID:
            //        return StringConstants.CUBRID_CONN_STR_TEMPLATE;
            //    default:
            //        return StringConstants.POSTGRESQL_CONN_STR_TEMPLATE;
            //}
            return StringConstants.SQLConnStrTemplate;
        }


        public ConnectionDialog()
        {
            InitializeComponent();

            Load += OnConnectionDialogLoad;

            PopulateServerTypes();

            serverTypeComboBox.SelectedIndexChanged += OnServerTypeSelectedIndexChanged;
        }

        
        public ConnectionSetting ConnectionSetting
        {
            get { return _connectionSetting; }
            set { _connectionSetting = value; BindData(); }
        }
        private ConnectionSetting _connectionSetting;
        

        private void OnConnectionDialogLoad(object sender, EventArgs e)
        {
            // If no connection has been passed in create a new one
            if (ConnectionSetting == null)
            {
                ConnectionSetting = CreateNewConnection();
            }
        }

        private void OnConnectionStringButtonClick(object sender, EventArgs e)
        {
            // Using the microsoft connection dialog as used in visual studio
            // http://archive.msdn.microsoft.com/Connection/Release/ProjectReleases.aspx?ReleaseId=3863
            var dialogResult = DialogResult.Cancel;
            var connectionString = string.Empty;

            var dcd = new DataConnectionDialog();

            try
            {
                var dcs = new DataConnectionConfig(null);
                dcs.LoadConfiguration(dcd, ConnectionSetting.Type);

                CaptureConnection();
                if (ConnectionSetting.ConnectionString != GetDefaultConnectionStringForServerType(ConnectionSetting.Type))
                {
                    dcd.ConnectionString = ConnectionSetting.ConnectionString;
                }

                dialogResult = DataConnectionDialog.Show(dcd);
                connectionString = dcd.ConnectionString;

            }
            catch (ArgumentException)
            {
                dcd.ConnectionString = string.Empty;
                dialogResult = DataConnectionDialog.Show(dcd);
            }
            finally
            {
                if (dialogResult == DialogResult.OK)
                {
                    ConnectionSetting.ConnectionString = connectionString;
                    BindData();
                }
            }

        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {
            ConnectionSetting = CreateNewConnection();
        }

        private void OnServerTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (serverTypeComboBox.SelectedIndex == -1)
            {
                // Nothing selected
                return;
            }

            // Set a default connection string if user changes server type.
            var serverType = (ServerType)serverTypeComboBox.SelectedItem;
            ConnectionSetting.Name = nameTextBox.Text;
            ConnectionSetting.Type = serverType;
            ConnectionSetting.ConnectionString = GetDefaultConnectionStringForServerType(serverType);
            BindData();
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            CaptureConnection();
        }


        private ConnectionSetting CreateNewConnection(ServerType serverType = ServerType.SqlServer)
        {
            // Default connection settings.
            var connectionString = GetDefaultConnectionStringForServerType(serverType);

            return new ConnectionSetting
                       {
                           Id = Guid.NewGuid(),
                           Name = "New Connection",
                           ConnectionString = connectionString,
                           Type = serverType
                       };
        }

        private void BindData()
        {
            serverTypeComboBox.SelectedIndexChanged -= OnServerTypeSelectedIndexChanged;

            nameTextBox.Text = ConnectionSetting.Name;
            serverTypeComboBox.SelectedItem = ConnectionSetting.Type;
            connectionStringTextBox.Text = ConnectionSetting.ConnectionString;

            serverTypeComboBox.SelectedIndexChanged += OnServerTypeSelectedIndexChanged;
        }

        private void CaptureConnection()
        {
            ConnectionSetting.Name = nameTextBox.Text;
            ConnectionSetting.Type = (ServerType)serverTypeComboBox.SelectedItem;
            ConnectionSetting.ConnectionString = connectionStringTextBox.Text;
        }

        private void PopulateServerTypes()
        {
            serverTypeComboBox.DataSource = Enum.GetValues(typeof(ServerType));
            serverTypeComboBox.SelectedIndex = 0;
        }

        
    }
}
