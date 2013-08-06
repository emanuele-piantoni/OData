using System.Configuration;

namespace ExampleOData.NH.Configuration
{
    public class NHConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("connectionStringName", IsRequired = true)]
        public string ConnectionStringName
        {
            get { return (string)this["connectionStringName"]; }
            set { this["connectionStringName"] = value; }
        }

        [ConfigurationProperty("enableCache", DefaultValue = true, IsRequired = false)]
        public bool EnableCache
        {
            get { return (bool)this["enableCache"]; }
            set { this["enableCache"] = value; }
        }

        [ConfigurationProperty("cacheProvider", IsRequired = false, DefaultValue = null)]
        public string CacheProvider
        {
            get { return (string)this["cacheProvider"]; }
            set { this["cacheProvider"] = value; }
        }

        [ConfigurationProperty("databaseType", IsRequired = true)]
        public string DatabaseType
        {
            get { return (string)this["databaseType"]; }
            set { this["databaseType"] = value; }
        }

        [ConfigurationProperty("databaseSchema", IsRequired = false, DefaultValue = "dbo")]
        public string DatabaseSchema
        {
            get { return (string)this["databaseSchema"]; }
            set { this["databaseSchema"] = value; }
        }
    }
}
