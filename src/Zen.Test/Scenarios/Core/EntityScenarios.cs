using System;
using FluentAssertions;
using Xbehave;
using Zen.Core;

namespace Zen.Test.Scenarios.Core
{    
    /// <summary>
    /// a base class for any entity test scenarios 
    /// </summary>
    public abstract class EntityScenarios<T, TId> : UseLogFixture 
        where T : class, IDomainEntity<TId>, new()
    {
        protected T Entity; 
        protected TId Id;

        //[Scenario] //- add this attribute to the method override
        public virtual void CreateDefault()
        {
            "Given a domain entity".Given(() =>
            {//arrange
                Entity = default(T);
                Id = default(TId);
                Log.InfoFormat( "{0}\t Entity Type:\t{1} [default= {2}]" + 
                                "{0}\t Id Type:\t\t{3} [default= {4}] {0}", "\r\n",
                                typeof(T), Entity.ShowNullorEmptyString(),
                                typeof(TId), Id.ShowNullorEmptyString());
            });

            "When instantiating with the default constructor".When(() =>
            {//act
                Entity = Activator.CreateInstance<T>();
            });

            "Then the object should be in the appropriate state".Then(() =>
            {//assert
                Entity.Should().BeAssignableTo<IDomainEntity<TId>>("the type should implement IDomainEntity<T>");

                Entity.Id.Should().Be(default(TId), "the databaase id should not been assigned");

                Entity.Uid.Should().NotBeEmpty("the EntityId(Guid) should be assigned");
            });
        }

    }
}