using System;
using System.Configuration;
using ExampleOData.NH.Configuration;
using FluentNHibernate.Cfg.Db;

namespace ExampleOData.NH.Helpers
{
    internal class FluentDatabaseHelper
    {
        public static IPersistenceConfigurer DbConfiguration(NHConfigurationSection nhConfiguration)
        {
            string dbType = nhConfiguration.DatabaseType;

            if (string.IsNullOrEmpty(dbType))
                throw new ConfigurationErrorsException("You must specify the Database type!");

            try
            {
                DbType db = (DbType)Enum.Parse(typeof(DbType), dbType);
                switch (db)
                {
                    case DbType.MsSql2000:
                        return MsSqlConfigureDatabase2000(nhConfiguration);
                    case DbType.MsSql2005:
                        return MsSqlConfigureDatabase2005(nhConfiguration);
                    case DbType.MsSql2008:
                        return MsSqlConfigureDatabase2008(nhConfiguration);
                    case DbType.MySql:
                        return MySqlConfigureDatabase(nhConfiguration);
                    case DbType.Oracle9:
                        return Oracle9ConfigureDatabase(nhConfiguration);
                    case DbType.Oracle10:
                        return Oracle10ConfigureDatabase(nhConfiguration);
                    case DbType.PostgreSqlStandard:
                        return PostgreSqlStandardConfigureDatabase(nhConfiguration);
                    case DbType.PostgreSql81:
                        return PostgreSql81ConfigureDatabase(nhConfiguration);
                    case DbType.PostgreSql82:
                        return PostgreSql82ConfigureDatabase(nhConfiguration);
                    case DbType.SqlLite:
                        return SqlLiteConfigureDatabase(nhConfiguration);
                    case DbType.SqlLiteInMemory:
                        return SqlLiteMemoryConfigureDatabase(nhConfiguration);
                    default:
                        throw new ConfigurationErrorsException("The specified database is not supported");
                }
            }
            catch
            {
                throw new ConfigurationErrorsException("The specified database is not supported");
            }
        }

        private static IPersistenceConfigurer MsSqlConfigureDatabase2000(NHConfigurationSection nhConfiguration)
        {
            MsSqlConfiguration cfg = MsSqlConfiguration.MsSql2000
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer MsSqlConfigureDatabase2005(NHConfigurationSection nhConfiguration)
        {
            MsSqlConfiguration cfg = MsSqlConfiguration.MsSql2005
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer MsSqlConfigureDatabase2008(NHConfigurationSection nhConfiguration)
        {
            MsSqlConfiguration cfg = MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer MySqlConfigureDatabase(NHConfigurationSection nhConfiguration)
        {
            MySQLConfiguration cfg = MySQLConfiguration.Standard
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer Oracle9ConfigureDatabase(NHConfigurationSection nhConfiguration)
        {
            OracleDataClientConfiguration cfg = OracleDataClientConfiguration.Oracle9
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer Oracle10ConfigureDatabase(NHConfigurationSection nhConfiguration)
        {
            OracleDataClientConfiguration cfg = OracleDataClientConfiguration.Oracle10
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer PostgreSqlStandardConfigureDatabase(NHConfigurationSection nhConfiguration)
        {
            PostgreSQLConfiguration cfg = PostgreSQLConfiguration.Standard
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer PostgreSql81ConfigureDatabase(NHConfigurationSection nhConfiguration)
        {
            PostgreSQLConfiguration cfg = PostgreSQLConfiguration.PostgreSQL81
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer PostgreSql82ConfigureDatabase(NHConfigurationSection nhConfiguration)
        {
            PostgreSQLConfiguration cfg = PostgreSQLConfiguration.PostgreSQL82
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer SqlLiteConfigureDatabase(NHConfigurationSection nhConfiguration)
        {
            SQLiteConfiguration cfg = SQLiteConfiguration.Standard
                //.UsingFile(filePath)
                .ConnectionString(c => c.FromConnectionStringWithKey(nhConfiguration.ConnectionStringName))
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

#if DEBUG
            cfg.ShowSql();
#endif

            return cfg;
        }

        private static IPersistenceConfigurer SqlLiteMemoryConfigureDatabase(NHConfigurationSection nhConfiguration)
        {
            SQLiteConfiguration cfg = SQLiteConfiguration.Standard
                .InMemory()
                .UseOuterJoin()
                .DefaultSchema(nhConfiguration.DatabaseSchema);

            return cfg;
        }


        #region Nested type: DbType

        private enum DbType
        {
            MsSql2000,
            MsSql2005,
            MsSql2008,
            MySql,
            Oracle9,
            Oracle10,
            PostgreSqlStandard,
            PostgreSql81,
            PostgreSql82,
            SqlLite,
            SqlLiteInMemory
        }

        #endregion
    }
}
