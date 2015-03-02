//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Microsoft.Data.ConnectionUI;
using Zen.Util.Domain;

namespace Zen.Utility
{
	/// <summary>
	/// Provide a default implementation for the storage of DataConnection Dialog UI configuration.
	/// </summary>
	public class DataConnectionConfig : IDataConnectionConfig
	{
		private const string ConfigFileName = @"DataConnection.xml";

        public DataConnectionConfig(string configFilePath)
        {
            if (!String.IsNullOrEmpty(configFilePath))
            {
                _fullFilePath = Path.GetFullPath(Path.Combine(configFilePath, ConfigFileName));
            }
            else
            {
                _fullFilePath = Path.Combine(System.Environment.CurrentDirectory, ConfigFileName);
            }
            if (!String.IsNullOrEmpty(_fullFilePath) && File.Exists(_fullFilePath))
            {
                _xDoc = XDocument.Load(_fullFilePath);
            }
            else
            {
                _xDoc = new XDocument();
                _xDoc.Add(new XElement("ConnectionDialog", new XElement("DataSourceSelection")));
            }

            this.RootElement = _xDoc.Root;
        }

        public XElement RootElement { get; set; }

		private readonly string _fullFilePath = null;
		private readonly XDocument _xDoc = null;
        private IDictionary<string, DataSource> _dataSources;// Available data sources:
        private IDictionary<string, DataProvider> _dataProviders;// Available data providers: 


		public void LoadConfiguration(DataConnectionDialog dialog, ServerType serverType)
		{
            
            this._dataSources = new Dictionary<string, DataSource>();
            this._dataProviders = new Dictionary<string, DataProvider>();

		    switch (serverType)
		    {
                //case ServerType.Oracle:
                //    dialog.DataSources.Add(DataSource.OracleDataSource);
                //    dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OracleDataProvider);
                //    this.dataSources.Add(DataSource.OracleDataSource.Name, DataSource.OracleDataSource);
                //    this.dataProviders.Add(DataProvider.OracleDataProvider.Name, DataProvider.OracleDataProvider);
                //    break;
		        case ServerType.SqlServer:
                    dialog.DataSources.Add(DataSource.SqlDataSource);
                    this._dataSources.Add(DataSource.SqlDataSource.Name, DataSource.SqlDataSource);
                    this._dataProviders.Add(DataProvider.SqlDataProvider.Name, DataProvider.SqlDataProvider);
		            break;
		        default:
                    dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OleDBDataProvider);
                    this._dataProviders.Add(DataProvider.OleDBDataProvider.Name, DataProvider.OleDBDataProvider);
			        dialog.DataSources.Add(dialog.UnspecifiedDataSource);
                    this._dataSources.Add(dialog.UnspecifiedDataSource.DisplayName, dialog.UnspecifiedDataSource);
		            break;
		    }

			DataSource ds = null;
			string dsName = this.GetSelectedSource();
			if (!String.IsNullOrEmpty(dsName) && this._dataSources.TryGetValue(dsName, out ds))
			{
				dialog.SelectedDataSource = ds;
			}

			DataProvider dp = null;
			string dpName = this.GetSelectedProvider();
			if (!String.IsNullOrEmpty(dpName) && this._dataProviders.TryGetValue(dpName, out dp))
			{
				dialog.SelectedDataProvider = dp;
			}
		}

		public void SaveConfiguration(DataConnectionDialog dcd)
		{
			if (dcd.SaveSelection)
			{
				DataSource ds = dcd.SelectedDataSource;
				if (ds != null)
				{
					if (ds == dcd.UnspecifiedDataSource)
					{
						this.SaveSelectedSource(ds.DisplayName);
					}
					else
					{
						this.SaveSelectedSource(ds.Name);
					}
				}
				DataProvider dp = dcd.SelectedDataProvider;
				if (dp != null)
				{
					this.SaveSelectedProvider(dp.Name);
				}

				_xDoc.Save(_fullFilePath);
			}
		}

		public void SaveSelectedSource(string source)
		{
			if (!String.IsNullOrEmpty(source))
			{
				try
				{
					XElement xElem = this.RootElement.Element("DataSourceSelection");
					XElement sourceElem = xElem.Element("SelectedSource");
					if (sourceElem != null)
					{
						sourceElem.Value = source;
					}
					else
					{
						xElem.Add(new XElement("SelectedSource", source));
					}
				}
				catch
				{
				}
			}

		}

		public void SaveSelectedProvider(string provider)
		{
			if (!String.IsNullOrEmpty(provider))
			{
				try
				{
					XElement xElem = this.RootElement.Element("DataSourceSelection");
					XElement sourceElem = xElem.Element("SelectedProvider");
					if (sourceElem != null)
					{
						sourceElem.Value = provider;
					}
					else
					{
						xElem.Add(new XElement("SelectedProvider", provider));
					}
				}
				catch
				{
				}
			}
		}

        public string GetSelectedSource()
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement sourceElem = xElem.Element("SelectedSource");
                if (sourceElem != null)
                {
                    return sourceElem.Value as string;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public string GetSelectedProvider()
        {
            try
            {
                XElement xElem = this.RootElement.Element("DataSourceSelection");
                XElement providerElem = xElem.Element("SelectedProvider");
                if (providerElem != null)
                {
                    return providerElem.Value as string;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
	
    }
}
