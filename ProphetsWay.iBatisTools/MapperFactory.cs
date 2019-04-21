using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using ProphetsWay.Utilities;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;

namespace ProphetsWay.iBatisTools
{
    /// <summary>
    /// This is a Factory to build you a Mapper object needed for iBatis dao objects.  
    /// </summary>
    public static class MapperFactory
    {
        /// <summary>
        /// Generates a Mapper object for your DAL. 
        /// </summary>
        /// <param name="callingAssembly">The assembly that contains the actual Maps and SqlMap.config file.</param>
        /// <param name="connectionString">The connection string your DAL will use to connect to its specific database.  
        /// *Requires that you use variable $(connectionString) in your SqlMap.config file.</param>
        /// <returns></returns>
        public static ISqlMapper GenerateMapper(this Assembly callingAssembly, string connectionString)
        {
            var builderProps = new NameValueCollection();
            builderProps.Add("connectionString", connectionString);
            return callingAssembly.GenerateMapper(builderProps);
        }

        /// <summary>
        /// Generates a Mapper object for your DAL. 
        /// *Use this method if you have no variables specified within your SqlMap.config file.
        /// </summary>
        /// <param name="callingAssembly">The assembly that contains the actual Maps and SqlMap.config file.</param>
        /// <returns></returns>
        public static ISqlMapper GenerateMapper(this Assembly callingAssembly)
        {
            var builderProps = new NameValueCollection();
            return callingAssembly.GenerateMapper(builderProps);
        }

        /// <summary>
        /// Generates a Mapper object for your DAL.  
        /// </summary>
        /// <param name="callingAssembly">The assembly that contains the actual Maps and SqlMap.config file.</param>
        /// <param name="builderProperties">A NameValueCollection comprised of all the variables you have specified within your SqlMap.config file.</param>
        public static ISqlMapper GenerateMapper(this Assembly callingAssembly, NameValueCollection builderProperties)
        {
            var assemblyName = callingAssembly.ManifestModule.Name;

            Logger.Debug($"Generating an ISqlMapper for {assemblyName}");

            var builder = new DomSqlMapBuilder { ValidateSqlMapConfig = true, Properties = builderProperties };
            var resources = callingAssembly.GetManifestResourceNames();

            try
            {
                var cfgResourceName = resources.Single(x => x.StartsWith($"{callingAssembly.GetName().Name}.SqlMap.") && x.EndsWith(".config"));
                var mapper = builder.Configure(callingAssembly.GetManifestResourceStream(cfgResourceName));

                return mapper;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"There was a problem when generating the SqlMapper for {assemblyName}");

                throw;
            }
        }
    }
}
