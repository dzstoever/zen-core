using System;
using Zen.Util.Domain;

namespace Zen.Util
{
    public class ConnectionSetting
    {
        public Guid Id { get; set; }
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public ServerType Type { get; set; }
    }

    public class UtilityControlSetting
    {
        public Guid Id { get; set; }
        public string AssemblyFQN { get; set; }
        public string ControlType { get; set; }        
    }
}