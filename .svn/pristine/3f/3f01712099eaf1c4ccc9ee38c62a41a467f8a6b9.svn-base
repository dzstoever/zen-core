using System;
using FluentAssertions;
using Xbehave;
using Xunit;
using Xunit.Extensions;
using Moq;

namespace Zen.Test
{

    public class XunitScenarios : UseLogFixture
    {
        [Scenario]
        public virtual void DoSomething()
        {
            Console.WriteLine("I am not in the output");

            "Given some arranged preconditions".Given(() =>
            {
                Console.WriteLine("-arrange-");
                Log.InfoFormat("given something");

            }, () =>
                    {
                        Console.WriteLine("-dispose-");
                        Log.InfoFormat("clean up");
                    }
            );
            "When the code under test runs".When(() =>
            {
                Console.WriteLine("-act-");
                Log.InfoFormat("do something with it");

            });
            "Then the actual results meet expectations".Then(() =>
            {
                Console.WriteLine("-assert-");
                Log.InfoFormat("is everything as it should be");
            });
        }
    }
    
    /*    
    public class XSimpleScenario
    {
        [Scenario]
        public virtual void DoSomething()
        {
            int? x = null;
            "Given x=1 ".Given(() => x = 1);
            "When adding 1 ".When(() => x += 1);
            "Then the result is 2".Then(() => x.Should().Be(2));
        }
    }

    public class XDisposeScenario
    {
        [Scenario]
        public virtual void DoSomething_Dispose()
        {
            Console.WriteLine("I am not in the output");

            "Given some arranged preconditions".Given(() =>
            {Console.WriteLine("-arrange-");                
            }, Dispose //() => { Console.WriteLine("-dispose- (lambda)"); }
            );

            "When the code under test runs".When(() =>
            {Console.WriteLine("-act-");
            });

            "Then the actual results meet expectations".Then(() =>
            {Console.WriteLine("-assert-");
            });
        }

        private void Dispose()
        { Console.WriteLine("-dispose- (method)");
        }
    }
    */
}
