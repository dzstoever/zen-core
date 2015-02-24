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
    public abstract class MappedEntity<TId> : DomainEntity<TId> //, NHibernate.Classic.ILifecycle, NHibernate.IInterceptor
    {        
        protected IClassMetadata ClassMetadata;
        protected PersistentClass ClassMapping;
        protected string ClassName;
        protected Type EntityType;

        protected MappedEntity()
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
