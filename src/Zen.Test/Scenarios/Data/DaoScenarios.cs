using System;
using System.Collections.Generic;
using FluentAssertions;
using NHibernate;
using Xbehave;
using Zen.Core;
using Zen.Data;

namespace Zen.Test.Scenarios.Data
{
    /// <summary>
    /// Base class for any repository entity tests, creates a generic dao object to access the data. 
    /// </summary>    
    public abstract class DaoScenarios<T, TId> : UseLogFixture 
        where T : class, IDomainEntity<TId>, new()
    {
        protected IGenericDao Dao;// <- sut (for entities of type T in the repository)
        protected IDisposable Session;        
        
        int _entityCnt = -1;
        IEnumerable<T> _entityList;

        #region some unused mocking code that may be useful for Save() or Update() calls
        //protected Mock<NH.ISessionFactory> _mockSessionFactory = new Mock<NH.ISessionFactory>();
        //protected Mock<NH.ISession> _mockSession = new Mock<NH.ISession>();        

        // tell the mock session factory to return a mock session
        //_mockSessionFactory.Setup(sf => sf.OpenSession()).Returns(_mockSession.Object);            
        //_dao = new NHibernate.GenericDao(_mockSessionFactory.Object);
        #endregion


        [Scenario]
        public virtual void FetchAll(ISessionFactory sessionFactory)
        {

            "Given a generic data access object with an open unit of work".Given(() =>
            {//arrange
                
                Dao = new NHibernateDao(sessionFactory);
                Session = Dao.StartUnitOfWork();

                Log.InfoFormat("Testing repository with {0}", Dao.GetType());
            });

            "When fetching entities from the repository".When(() =>
            {//act
                _entityCnt = Dao.GetCount<T>();
                _entityList = Dao.FetchAll<T>();

                Log.InfoFormat("{0} count = {1}", typeof(T), _entityCnt);
            });

            "Then all entities should be returned".Then(() =>
            {//assert
                Session.Should().BeAssignableTo<ISession>("an NHibernate.ISession should be available");

                _entityList.Should().NotBeNull("a valid list should be returned");

                var entityList = (IList<T>)_entityList;
                entityList.Count.Should().Be(_entityCnt, "the number of instances should equal the total count");

                foreach (var entity in _entityList)
                {
                    entity.Id.Should().NotBe(default(TId), "each instance should have an Id assigned");
                }

            });
        }
        
        
        ~DaoScenarios()
        {
            if (Dao == null) return;
            Dao.CloseUnitOfWork();
            Dao.Dispose();
        }
    }
}