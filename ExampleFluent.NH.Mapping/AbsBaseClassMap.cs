using ExampleOData.NH.Configuration;
using FluentNHibernate.Mapping;

namespace ExampleOData.NH.Mapping
{
    public abstract class AbsBaseClassMap<T> : ClassMap<T>
    {
        /// <summary>
        /// 	Initializes a new instance of the <see cref = "BaseClassMap&lt;T&gt;" /> class.
        /// </summary>
        /// <param name = "tableName">Name of the table.</param>
        protected AbsBaseClassMap(string tableName)
        {
            Table(tableName);
            DynamicUpdate();
            LazyLoad();
            Schema(NHConfiguration.Instance.DatabaseSchema);

            if (NHConfiguration.Instance.EnableCache)
                Cache.ReadWrite();
        }
    }
}
