using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zen
{
    public interface IRunnable
    {
        void Run();
    }

    public interface IStartup
    {
        void Startup();
    }
}
