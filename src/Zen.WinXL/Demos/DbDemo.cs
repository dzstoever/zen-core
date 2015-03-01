using System.Windows.Forms;

namespace Zen.WinXL.Demos
{
    public class DbDemo : IRunnable
    {        
        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new App());            
        }
    }
}