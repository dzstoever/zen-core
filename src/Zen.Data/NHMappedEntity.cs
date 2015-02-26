using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Classic;
using NHibernate.Mapping;
using NHibernate.Metadata;
using Zen;
using Zen.Core;

namespace Zen.Data
{
    /// <summary>
    /// Let’s recall our needs. First of all, we want to validate entities before saving into the database 
    /// and then we want to set some properties (for example, LastModifiedBy, LastModifiedOn, and so on) 
    /// </summary>
    /// <see cref="http://www.targetprocess.com/agileproductblog/2006/08/entity-life-cycle-in-nhibernate.html"/>
    /// <seealso cref="http://stackoverflow.com/questions/12681102/mvvm-nhibernate-how-to-do-dynamic-model-validation"/>
    public abstract class NHMappedEntity<TId> : DomainEntity<TId> //, NHibernate.Classic.ILifecycle, NHibernate.IInterceptor
    {        
        protected NHMappedEntity()
        {
            EntityType = base.GetTypeUnproxied();
            ClassMetadata = NHConfigurator.SessionFactoryImpl.GetClassMetadata(EntityType);
            if(ClassMetadata == null)
                throw new ConfigException(EntityType.FullName + " has no class metadata.");
            ClassMapping = NHConfigurator.Cfg.GetClassMapping(EntityType);
            if (ClassMapping == null)
                throw new ConfigException(EntityType.FullName + " has no class mapping.");
            ClassName = ClassMapping.ClassName;

            // TODO: read the validations that are set in our metadata mapping here somehow
            // i.e. map.NotNullable(true), map.Length(x), map.precision(x), etc.
            // then call AddRule(...) for each
            // this would allow us to add all the basic 'validation rules'(non 'business rules')
            // note: a 'business rule' is something we should apply on the bmo/viewmodel level...
            // note: we can do this backwards like the SqlEntityBulkCopy class (see: nhibernate-in-action pg.290) 
            // note: there is also a check attribute for the <class> element, for MULTICOLUMN CHECK CONSTRAINTS.('business rules')

        }

        protected Type EntityType;
        protected string ClassName;
        protected IClassMetadata ClassMetadata;
        protected PersistentClass ClassMapping;

        //override bool Zen.Core.DomainObject.Validate()
        //{            
        //    return base.Validate();
        //}


        #region ILifecycle

        public void OnLoad(NHibernate.ISession s, object id)
        {
            throw new NotImplementedException();
        }

        public LifecycleVeto OnSave(NHibernate.ISession s)
        {
            throw new NotImplementedException();
        }

        public LifecycleVeto OnUpdate(NHibernate.ISession s)
        {
            throw new NotImplementedException();
        }

        public LifecycleVeto OnDelete(NHibernate.ISession s)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region IInterceptor

        public void AfterTransactionBegin(NHibernate.ITransaction tx)
        {
            throw new NotImplementedException();
        }

        public void AfterTransactionCompletion(NHibernate.ITransaction tx)
        {
            throw new NotImplementedException();
        }

        public void BeforeTransactionCompletion(NHibernate.ITransaction tx)
        {
            throw new NotImplementedException();
        }

        public int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            throw new NotImplementedException();
        }

        public object GetEntity(string entityName, object id)
        {
            throw new NotImplementedException();
        }

        public string GetEntityName(object entity)
        {
            throw new NotImplementedException();
        }

        public object Instantiate(string entityName, NHibernate.EntityMode entityMode, object id)
        {
            throw new NotImplementedException();
        }

        public bool? IsTransient(object entity)
        {
            throw new NotImplementedException();
        }

        public void OnCollectionRecreate(object collection, object key)
        {
            throw new NotImplementedException();
        }

        public void OnCollectionRemove(object collection, object key)
        {
            throw new NotImplementedException();
        }

        public void OnCollectionUpdate(object collection, object key)
        {
            throw new NotImplementedException();
        }

        public void OnDelete(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            throw new NotImplementedException();
        }

        public bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            throw new NotImplementedException();
        }

        public bool OnLoad(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            throw new NotImplementedException();
        }

        public NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            throw new NotImplementedException();
        }

        public bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            throw new NotImplementedException();
        }

        public void PostFlush(System.Collections.ICollection entities)
        {
            throw new NotImplementedException();
        }

        public void PreFlush(System.Collections.ICollection entities)
        {
            throw new NotImplementedException();
        }

        public void SetSession(NHibernate.ISession session)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /* Todo: combine into NHMappedEntity
    public class SqlEntityHelper
    {
        internal static Configuration Cfg;
        internal static ISessionFactoryImplementor SessionFactoryImpl;


        /// <summary>
        /// Wrapper class to produce an Ado.Net Datatable from any entity, 
        /// and perform SqlBulkCopy operations
        /// </summary>
        public SqlEntityHelper(string sqlCnnString, Type entityType)
        {

            if (Cfg == null)
            {
                //Note: The NHibernate.Cfg.Configuration is meant only as an initialization-time object. 
                //Note: NHibernate.ISessionFactory is immutable and does not retain any association back to the Session

                Cfg = new Configuration();
                //Cfg.SetProperty("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");
                Cfg.SetProperty("dialect", "NHibernate.Dialect.MsSql2008Dialect");
                Cfg.SetProperty("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                Cfg.SetProperty("connection.driver_class", "NHibernate.Driver.SqlClientDriver");
                Cfg.SetProperty("connection.connection_string", sqlCnnString);

                //add all the mappings embedded in this assembly
                Cfg.AddAssembly(typeof(SqlEntityHelper).Assembly);

                var sessionFactory = Cfg.BuildSessionFactory();
                SessionFactoryImpl = (ISessionFactoryImplementor)sessionFactory;
            }
            EntityType = entityType;
            //_session = SessionFactoryImpl.OpenSession();
            _metaData = SessionFactoryImpl.GetClassMetadata(EntityType);
            _persistentClass = Cfg.GetClassMapping(EntityType);
            _sqlCnn = new SqlConnection(sqlCnnString);
            _sqlBulkCopy = new SqlBulkCopy(_sqlCnn);

            //Debug.WriteLine("EntityName = " + _metaData.EntityName);
            //Debug.WriteLine("IdentifierPropertyName = " + _metaData.IdentifierPropertyName);
            //Debug.WriteLine("IdentifierType = " + _metaData.IdentifierType);

            BuildDataTable();
            BuildAndMapSqlBulkCopy();
        }


        public SqlBulkCopy SqlBulkCopy
        {
            get
            {
                if (_sqlBulkCopy == null) BuildAndMapSqlBulkCopy();
                return _sqlBulkCopy;
            }
        }

        public DataTable BulkTable { get; private set; }

        public DataTable DataTable { get; private set; }

        public Type EntityType { get; private set; }


        private readonly SqlBulkCopy _sqlBulkCopy;
        private readonly SqlConnection _sqlCnn;
        private readonly PersistentClass _persistentClass;
        private readonly IClassMetadata _metaData;


        public string GetSqlTableName()
        {
            return _persistentClass.Table.Name;
        }

        public string GetSqlColumnName(string propertyName)
        {
            foreach (Column dbCol in from prop in _persistentClass.PropertyIterator
                                     where prop.Name == propertyName
                                     from Column dbCol in prop.ColumnIterator
                                     select dbCol)
            {
                return dbCol.Name;
            }
            throw new Exception("Property not found! (" + propertyName + ")");
        }

        public void AddDataRow(object entity)
        {
            if (entity.GetType() != EntityType)
            { throw new Exception("Invalid Entity Type!"); }

            AddRow(DataTable, entity);
        }

        public void AddBulkCopyRow(object entity)
        {
            if (entity.GetType() != EntityType)
            { throw new Exception("Invalid Entity Type!"); }

            AddRow(BulkTable, entity);

        }

        public void ExecuteBulkCopy()
        {
            _sqlCnn.Open();
            try
            {
                _sqlBulkCopy.WriteToServer(BulkTable);
            }
            finally
            {
                BulkTable.Clear();
                _sqlCnn.Close();
            }
            //_sqlConnection.Close();
        }


        private void BuildDataTable()
        {
            DataTable = new DataTable(EntityType.Name);
            foreach (var propName in _metaData.PropertyNames)
            {
                var nhType = _metaData.GetPropertyType(propName);
                if (!nhType.IsAssociationType && !nhType.IsCollectionType)
                    DataTable.Columns.Add(new DataColumn(propName, nhType.ReturnedClass));
            }
        }

        private void BuildAndMapSqlBulkCopy()
        {

            BulkTable = new DataTable("BULK_" + EntityType.Name);
            SqlBulkCopy.DestinationTableName = _persistentClass.Table.Name;//Database table name                        

            foreach (var prop in _persistentClass.PropertyIterator)
            {
                if (!prop.IsBasicPropertyAccessor || !prop.IsInsertable || prop.Type.IsCollectionType) continue;
                var colName = prop.Name;
                foreach (Column dbCol in prop.ColumnIterator)
                {
                    var colType = dbCol.Value.Type.ReturnedClass;
                    if (prop.Type.IsAssociationType)
                    {
                        //use the pk from associated class for the columnType
                        var assClass = Cfg.GetClassMapping(colType);
                        foreach (Column assCol in assClass.Identifier.ColumnIterator)
                            colType = assCol.Value.Type.ReturnedClass;
                    }

                    if (prop.Type.IsComponentType)
                        colName = string.Format("{0}~{1}", prop.Name, dbCol.Name);

                    //Logger.DebugFormat("ColumnName: {0}, Type: {1}", colName, colType);
                    BulkTable.Columns.Add(new DataColumn(colName, colType));
                    SqlBulkCopy.ColumnMappings.Add(colName, dbCol.Name);
                }
            }

        }

        private void AddRow(DataTable table, object entity)
        {
            var row = table.NewRow();
            var props = EntityType.GetProperties();
            foreach (var prop in props)
            {
                if (!table.Columns.Contains(prop.Name)) continue;
                var val = prop.GetValue(entity, null);
                row[prop.Name] = val ?? DBNull.Value;
                //else { Debug.WriteLine("Excluded value = " + colName); }
            }
            table.Rows.Add(row);
        }
    }
    */
}
