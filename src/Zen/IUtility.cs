using System;
using System.Collections;
using System.Collections.Generic;

namespace Zen
{
    /// <summary>
    /// The Zen Developer Utility provides standard database access and mapping functionality, along with some basic code generation.
    /// Additionally, it allows you to load any other utility tool out of your own custom libraries/assemblies at run-time.
    /// It will scan all assemblies loaded in the current app domain for any classes that implement IUtilityTool...
    /// Note:
    ///     If the implementation derives from Windows.Forms.UserControl, it will allow you to add the tool to the main tab control 
    ///     or launch the tool in a new window.
    /// Note:
    ///     If the implementation also implements Zen.IRunnable it will call the classes Run() method...
    /// Note:
    ///     If the library containing your tool is in an unreferenced library you can add the library manually.
    ///     The application will attempt to remember the location of each manual library and load it the next time it runs. 
    /// Note:
    ///     The application will call LoadSettings() on each tool when the tool is first loaded 
    ///     The application will call SaveSettings() on each tool when the application exits... 
    /// Note:
    ///     The application will call OnDbConnectionChanged() on each tool when the tool is first loaded(if connected)
    ///     then subsequently each time the connection is changed in the main tool, passing the new connection string. 
    ///     The application will call OnDbOwnerChanged() on each tool when the tool is first loaded(if connected/selected)
    ///     then subsequently each time the owner is changed in the main tool, passing the new database owner and list of database tables. 
    /// </summary>
    public interface IUtility
    {
        void OnDbConnectionChange(string dbCnnString);
        void OnDbOwnerChanged(string dbOwner, IEnumerable<string> tableCollection);

        void OnLoadSettings();
        void OnSaveSettings();
    }

    public class UtilitySetting
    {
        public Guid Id { get; set; }
        public bool IsRunnable { get; set; }
        public bool IsUserControl { get; set; }        
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string AssemblyFQN { get; set; }
        public string AssemblyLocation { get; set; }
    }
}