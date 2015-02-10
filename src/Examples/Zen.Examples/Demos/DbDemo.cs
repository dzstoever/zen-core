using System.Windows.Forms;
using NHibernateMappingGenerator;
using Zen.Examples.Upstate;

namespace Zen.Examples.Demos
{
    public class DbDemo : IRunnable
    {        
        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new App());            
        }
    }
}