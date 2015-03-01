using System;
using System.Collections.Specialized;
using FluentAssertions;
using Moq;
using Xbehave;
using Xunit;
using Xunit.Extensions;
using Zen.Data;

namespace Zen.Test.Scenarios
{
    public class GenericDaoProviderScenarios 
    {        
        private GenericDaoProvider _provider;
        private IGenericDao _class;          

        private readonly Mock<ImplChecker> _moqChecker = new Mock<ImplChecker>();
        private const string DllName = "Zen.Data.dll";
        private const string KeyName = "dao-generic";
        private const string WhenMsg = "When using the GenericDaoProvider";


        [Scenario]
        [InlineData(true, typeof(NHibernateDao))]
        [InlineData(false, typeof(NoDao))]
        public virtual void GetImplNoSettings(bool dllExists, Type expected)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dll available = {0} and no settings", dllExists).Given(() =>
                _provider = new GenericDaoProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = null// no settings
                });

            WhenMsg.When(() =>
                _class = _provider.GetImpl());

            string.Format("Then a {0} should be returned", expected.Name).Then(() =>
               _class.GetType().Should().Be(expected));

        }


        [Scenario]
        [InlineData(true, typeof(NHibernateDao))]
        [InlineData(false, typeof(NoDao))]
        public virtual void GetImplNoSettingsKey(bool dllExists, Type expected)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dll available = {0} and NO '{1}' setting", dllExists, KeyName).Given(() =>
                _provider = new GenericDaoProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = new NameValueCollection()// doesn't contain the key
                });

            WhenMsg.When(() =>
                _class = _provider.GetImpl());

            string.Format("Then a {0} should be returned", expected.Name).Then(() =>
                _class.GetType().Should().Be(expected));

        }


        [Scenario]
        [InlineData(true, "Zen.Test.DummyDao, Zen.Test", typeof(DummyDao))]
        [InlineData(false, "Zen.Test.DummyDao, Zen.Test", typeof(DummyDao))]
        public virtual void GetImplWithValidSetting(bool dllExists, string setting, Type expected)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dllAvailable = {0} and setting is [{1}]", dllExists, setting).Given(() =>
                _provider = new GenericDaoProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = new NameValueCollection { { KeyName, setting } }
                });

            WhenMsg.When(() =>
                _class = _provider.GetImpl());

            string.Format("Then a {0} should be returned", expected.Name).Then(() =>
                _class.GetType().Should().Be(expected));
        }


        [Scenario]
        [InlineData(true, "Some Invalid Type")]
        [InlineData(false, "Some Invalid Type")]
        public virtual void GetImplWithInvalidSetting(bool dllExists, string setting)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dllAvailable = {0} and setting is [{1}]", dllExists, setting).Given(() =>
                _provider = new GenericDaoProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = new NameValueCollection { { KeyName, setting } }
                });

            "Then an dependency exception should be thrown".Then(() =>
                Assert.Throws<DependencyException>(() => _provider.GetImpl()));
        }
        
    }


    public class SimpleDaoProviderScenarios
    {
        private SimpleDaoProvider _provider;// subject under test
        private ISimpleDao _class;          // result

        private readonly Mock<ImplChecker> _moqChecker = new Mock<ImplChecker>();
        private const string DllName = "Zen.Data.dll";
        private const string KeyName = "dao-simple";
        private const string WhenMsg = "When using the SimpleDaoProvider";


        [Scenario]
        [InlineData(true, typeof(NHibernateDao))]
        [InlineData(false, typeof(NoDao))]
        public virtual void GetImplNoSettings(bool dllExists, Type expected)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dll available = {0} and no settings", dllExists).Given(() =>
                _provider = new SimpleDaoProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = null// no settings
                });

            WhenMsg.When(() =>
                _class = _provider.GetImpl());

            string.Format("Then a {0} should be returned", expected.Name).Then(() =>
               _class.GetType().Should().Be(expected));

        }


        [Scenario]
        [InlineData(true, typeof(NHibernateDao))]
        [InlineData(false, typeof(NoDao))]
        public virtual void GetImplNoSettingsKey(bool dllExists, Type expected)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dll available = {0} and NO '{1}' setting", dllExists, KeyName).Given(() =>
                _provider = new SimpleDaoProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = new NameValueCollection()// doesn't contain the key
                });

            WhenMsg.When(() =>
                _class = _provider.GetImpl());

            string.Format("Then a {0} should be returned", expected.Name).Then(() =>
                _class.GetType().Should().Be(expected));

        }


        [Scenario]
        [InlineData(true, "Zen.Test.DummyDao, Zen.Test", typeof(DummyDao))]
        [InlineData(false, "Zen.Test.DummyDao, Zen.Test", typeof(DummyDao))]
        public virtual void GetImplWithValidSetting(bool dllExists, string setting, Type expected)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dllAvailable = {0} and setting is [{1}]", dllExists, setting).Given(() =>
                _provider = new SimpleDaoProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = new NameValueCollection { { KeyName, setting } }
                });

            WhenMsg.When(() =>
                _class = _provider.GetImpl());

            string.Format("Then a {0} should be returned", expected.Name).Then(() =>
                _class.GetType().Should().Be(expected));
        }


        [Scenario]
        [InlineData(true, "Some Invalid Type")]
        [InlineData(false, "Some Invalid Type")]
        public virtual void GetImplWithInvalidSetting(bool dllExists, string setting)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dllAvailable = {0} and setting is [{1}]", dllExists, setting).Given(() =>
                _provider = new SimpleDaoProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = new NameValueCollection { { KeyName, setting } }
                });

            "Then an dependency exception should be thrown".Then(() =>
                Assert.Throws<DependencyException>(() => _provider.GetImpl()));
        }

    }

}
