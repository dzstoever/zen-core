using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Classic;
using NHibernate.Engine;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Metadata;
using Zen;
using Zen.Core;

namespace Zen.Data
{
    
    public static class MappedEntityConfigurator
    {
        internal static Configuration Cfg;
        internal static ISessionFactoryImplementor SessionFactoryImpl;

        /// <summary>
        /// LOAD ALL THE MAPPINGS FROM THE CONFIGURED ASSEMBLY  
        /// </summary>
        static MappedEntityConfigurator()
        {
            const string ErrorMsg = "Unable to load mapping assembly. Check your IDbCnnFactory implementation.";

            Assembly mappingAssembly = null;
            var di = Zen.Aspects.GetIocDI();
            var cnnFactory = di.Resolve<IDbCnnFactory>() ?? new NoDbCnnFactory();
            
            if (!string.IsNullOrWhiteSpace(cnnFactory.GetMappingAssemblyTypeName()))
            {
                try
                { mappingAssembly = Assembly.GetAssembly(Type.GetType(cnnFactory.GetMappingAssemblyTypeName())); }
                catch (ArgumentNullException) { }// that's ok try the FQN if available...
            }
            if (mappingAssembly == null && !string.IsNullOrWhiteSpace(cnnFactory.GetMappingAssemblyFQN()))
            {
                try
                { mappingAssembly = Assembly.Load(cnnFactory.GetMappingAssemblyFQN()); }
                catch (Exception ex) { throw new ConfigException(ErrorMsg, ex); }                
            }
            if (mappingAssembly == null)
                throw new ConfigException(ErrorMsg);
            //
            // we have an assembly
            //
            Cfg = new Configuration();
            Cfg.DataBaseIntegration(c =>
            {
                c.ConnectionString = cnnFactory.GetConnectionString();
                c.Dialect<NHibernate.Dialect.MsSql2008Dialect>(); // Todo: make this configurable
            });
            
            #region another possible way
            // - or -
            //Cfg.SetProperty("connection.connection_string", sqlCnnString);
            //Cfg.SetProperty("dialect", "NHibernate.Dialect.MsSql2008Dialect");
            //Cfg.SetProperty("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            //Cfg.SetProperty("connection.driver_class", "NHibernate.Driver.SqlClientDriver");                        
            #endregion

            // load all embedded resources from the assembly whose names end in .hbm.xml
            Cfg.AddAssembly(mappingAssembly);// this could probably be omitted unless we ever want to embed .hbm.xml?

            // load all mapping classes from the assembly which are tagged with the marker interface(IDbMapping)           
            var mapper = new ModelMapper();
            var mappings = from t in mappingAssembly.GetTypes()
                           where t.GetInterfaces().Contains(typeof(IDbMap))
                           select t;
            mapper.AddMappings(mappings);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            Cfg.AddMapping(domainMapping);

            var sessionFactory = Cfg.BuildSessionFactory();
            SessionFactoryImpl = (ISessionFactoryImplementor)sessionFactory;

            // TODO: Why is this a log4net logger? Is our ImplProvider broken or picking up something from NH
            //"{0} mappings in domain model. (not including embedded .hbm.xml files)".LogMe(Log.LogLevel.Debug, mappings.Count());
            Console.WriteLine("{0} mappings in domain model. (not including embedded .hbm.xml files)", mappings.Count());
        }

    }

    /// <summary>
    /// Let’s recall our needs. First of all, we want to validate entities before saving into the database 
    /// and then we want to set some properties (for example, LastModifiedBy, LastModifiedOn, and so on) 
    /// </summary>
    /// <see cref="http://www.targetprocess.com/agileproductblog/2006/08/entity-life-cycle-in-nhibernate.html"/>
    /// <seealso cref="http://stackoverflow.com/questions/12681102/mvvm-nhibernate-how-to-do-dynamic-model-validation"/>
    public abstract class MappedEntity<T> : DomainEntity<T> //, NHibernate.Classic.ILifecycle, NHibernate.IInterceptor
    {
        protected MappedEntity()
        {
            var entityType = GetTypeUnproxied();
            var classMetaData = MappedEntityConfigurator.SessionFactoryImpl.GetClassMetadata(entityType);
            if(classMetaData == null)
                throw new ConfigException(entityType.FullName + " has no class metadata.");
            var classMapping = MappedEntityConfigurator.Cfg.GetClassMapping(entityType);
            if (classMapping == null)
                throw new ConfigException(entityType.FullName + " has no class mapping.");

            var className = classMapping.ClassName;

            // TODO: read the validations that are set in our metadata mapping here somehow
            // i.e. map.NotNullable(true), map.Length(x), map.precision(x), etc.
            // then call AddRule(...) for each
            // this would allow us to add all the basic 'validation rules'(non 'business rules')
            // note: a 'business rule' is something we should apply on the bmo/viewmodel level...
            // note: we can do this backwards like the SqlEntityBulkCopy class (see: nhibernate-in-action pg.290) 
            // note: there is also a check attribute for the <class> element, for MULTICOLUMN CHECK CONSTRAINTS.('business rules')

        }

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
}
