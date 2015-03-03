using System;
using System.Collections.Generic;
using System.IO;
//using System.Runtime.Serialization;
using System.Xml.Serialization;
using Zen.Util;
using Zen.Util.Domain;

namespace Zen.Utility
{
    public class ApplicationSettings //: ISerializable
    {
        private const string ConfigFileName = "zenutil.config";

        public static ApplicationSettings Load()
        {
            var configFile = new FileInfo(Path.Combine(System.Windows.Forms.
                Application.LocalUserAppDataPath, ConfigFileName));

            return configFile.DeserializeSettings<ApplicationSettings>();

            //ApplicationSettings appSettings = null;
            //var xmlSerializer = new XmlSerializer(typeof(ApplicationSettings));
            //var configFilePath = Path.Combine(System.Windows.Forms.Application.LocalUserAppDataPath, ConfigFileName);
            //var fi = new FileInfo(configFilePath);
            //if (fi.Exists)
            //{
            //    using (var fileStream = fi.OpenRead())
            //        appSettings = (ApplicationSettings)xmlSerializer.Deserialize(fileStream);
            //}
            //return appSettings;
        }


        public ApplicationSettings()
        {
            UtilityControlFQNs = new List<string>();
            //UtilityControlSettings = new List<UtilityControlSetting>();
            ConnectionSettings = new List<ConnectionSetting>();
        }

        public List<string> UtilityControlFQNs { get; set; }        
        //public List<UtilityControlSetting> UtilityControlSettings { get; set; }        
        
        public List<ConnectionSetting> ConnectionSettings { get; set; }
        public Guid? LastUsedConnection { get; set; }

        public bool GenerateInFolders { get; set; }
        public bool GenerateWcfContracts { get; set; }
        public bool GeneratePartialClasses { get; set; }
        public bool IsByCode { get; set; }
        public bool IsFluent { get; set; }
        public bool IsNhFluent { get; set; }
        public bool IsCastle { get; set; }
        public bool IsEntityFramework { get; set; }
        public bool IsAutoProperty { get; set; }
        public bool UseLazy { get; set; }
        public bool EnableInflections { get; set; }
        public bool NameFkAsForeignTable { get; set; }
        public bool IncludeHasMany { get; set; }
        public bool IncludeForeignKeys { get; set; }
        public bool IncludeLengthAndScale { get; set; }

        public string MapFolderPath { get; set; }
        public string DomainFolderPath { get; set; }
        public string DomainNameSpace { get; set; }
        public string MapNameSpace { get; set; }
        public string AssemblyName { get; set; }
        public string Prefix { get; set; }
        public string ClassNamePrefix { get; set; }
        public string InheritenceAndInterfaces { get; set; }
        public string ForeignEntityCollectionType { get; set; }
        public List<string> FieldPrefixRemovalList { get; set; }

        public Language Language { get; set; }
        public ValidationStyle ValidationStyle { get; set; }
        public CodeGenerationOptions CodeGenerationOptions { get; set; }
        public FieldNamingConvention FieldNamingConvention { get; set; }
        public FieldGenerationConvention FieldGenerationConvention { get; set; }


        public void Save()
        {            
            var configFile = new FileInfo(Path.Combine(System.Windows.Forms.
               Application.LocalUserAppDataPath, ConfigFileName));

            configFile.SerializeSettings(this);
        }


        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }

}