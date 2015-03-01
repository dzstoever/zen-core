using System;
using System.Collections.Specialized;
using FluentAssertions;
using Moq;
using Xbehave;
using Xunit;
using Xunit.Extensions;
using Zen.Ioc;

namespace Zen.Test.Scenarios
{
    public class IocProviderScenarios 
    {
        private IocProvider _provider;
        private IocDI _class;

        private readonly Mock<ImplChecker> _moqChecker = new Mock<ImplChecker>();
        private const string DllName = "Castle.Windsor.dll";
        private const string KeyName = "ioc-di";
        private const string WhenMsg = "When using the IocProvider";


        [Scenario]
        [InlineData(true, typeof(WindsorDI))]
        [InlineData(false, typeof(SingletonDI))]
        public virtual void GetImplNoSettings(bool dllExists, Type expected)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dll available = {0} and NO Settings", dllExists).Given(() =>
                _provider = new IocProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = null//<- no settings
                });

            WhenMsg.When(() =>
                _class = _provider.GetImpl());

            string.Format("Then a {0} should be returned", expected.Name).Then(() =>
                _class.GetType().Should().Be(expected));

        }


        [Scenario]
        [InlineData(true, typeof(WindsorDI))]
        [InlineData(false, typeof(SingletonDI))]
        public virtual void GetImplNoSettingsKey(bool dllExists, Type expected)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);

            string.Format("Given dll available = {0} and NO '{1}' setting", dllExists, KeyName).Given(() =>
                _provider = new IocProvider
                {
                    DependencyChecker = _moqChecker.Object,
                    Settings = new NameValueCollection()// <- don't contain the key
                });

            WhenMsg.When(() =>
                _class = _provider.GetImpl());

            string.Format("Then a {0} should be returned", expected.Name).Then(() =>
                _class.GetType().Should().Be(expected));

        }


        [Scenario]        
        [InlineData(true, "Zen.Test.DummyIocDI, Zen.Test", typeof(DummyIocDI))]
        [InlineData(false, "Zen.Test.DummyIocDI, Zen.Test", typeof(DummyIocDI))]
        public virtual void GetImplWithValidSetting(bool dllExists, string setting, Type expected)
        {
            _moqChecker.Setup(s => s.CheckForDll(DllName)).Returns(dllExists);
            
            string.Format("Given dllAvailable = {0} and setting is [{1}]", dllExists, setting).Given(() =>
                _provider = new IocProvider
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
                _provider = new IocProvider 
                { 
                    DependencyChecker = _moqChecker.Object,
                    Settings = new NameValueCollection { { KeyName, setting } }
                });

            "Then an dependency exception should be thrown".Then(() =>
                Assert.Throws<DependencyException>(() => _provider.GetImpl() )
                );
        }

    }
}
