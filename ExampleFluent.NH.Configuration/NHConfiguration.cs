using System.Configuration;

namespace ExampleOData.NH.Configuration
{
    public class NHConfiguration
    {
        public static readonly string ConnectionString;
        private static readonly NHConfigurationSection section;

        /// <summary>
        /// 	Initializes the <see cref = "NHConfiguration" /> class.
        /// </summary>
        static NHConfiguration()
        {
            section = ConfigurationManager.GetSection("nhibernatefluent.configuration") as NHConfigurationSection;

            if (section == null)
                throw new ConfigurationErrorsException("Could not found the NHibernate Configuration.");

            ConnectionString = ConfigurationManager.ConnectionStrings[section.ConnectionStringName].ConnectionString;
        }

        /// <summary>
        /// 	Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static NHConfigurationSection Instance
        {
            get { return section; }
        }
    }
}
