using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zen.Data.QueryModel
{
    /* Note: 
     * To pass a Query object as part of a [DataContract] we had to decorate 
     * Criterion, Parameter, and OrderClause classes with the [Serializable]
     * attribute to avoid a System.Runtime.Serialization.InvalidDataContractException 
     */
    [DataContract(Namespace = "http://zen.data/types/")]
    public sealed class Query
    {
        public Query()
        {
            QueryType = QueryTypes.Criteria; 
        }

        public Query(QueryTypes qType)
        {
            QueryType = qType;
        }

        public Query(QueryTypes qType, string text)
        {
            if (qType == QueryTypes.Criteria)
                throw new ArgumentException("QueryType can not be 'Criteria' for Named or Text Queries.");            

            QueryType = qType;
            IsNamed = false;
            NameOrText = text;
        }

        public Query(QueryTypes qType, bool isNamed, string nameOrText)
        {
            if (qType == QueryTypes.Criteria)
                throw new ArgumentException("QueryType can not be 'Criteria' for Named or Text Queries.");            
            
            QueryType = qType;
            IsNamed = isNamed;
            NameOrText = nameOrText;
        }

        
        [DataMember]
        public bool IsNamed { get; set; }
        [DataMember]
        public string NameOrText { get; set; }
        [DataMember]
        public QueryTypes QueryType { get; set; }
        
        
        [DataMember]
        public IList<Criterion> Criteria { get { return _criteria;} set { _criteria = value; } }        // for ICriteria queries only
        [DataMember]
        public IList<OrderClause> SortOrder { get { return _sortOrder; } set { _sortOrder = value; } }  // for ICriteria queries only
        [DataMember]
        public IList<Parameter> Parameters { get { return _parameters; } set { _parameters = value; } } // for IQuery(Hql) and ICriteria
        [DataMember]
        public IDictionary<string, Type> Aliases { get { return _aliases; } set { _aliases = value; } } // for ISqlQuery(Sql) queries only


        IList<Criterion>    _criteria = new List<Criterion>();
        IList<OrderClause>  _sortOrder = new List<OrderClause>();
        IList<Parameter>    _parameters = new List<Parameter>();
        IDictionary<string, Type> _aliases = new Dictionary<string, Type>();


        #region Not Implemented
        
        /*
        public void AddCriterion() 
        { }
        public void AddOrderClause() 
        { }
        public void AddParameter() 
        { }
        public void AddEntityAlias() 
        { }
        */

        #endregion

    }
}