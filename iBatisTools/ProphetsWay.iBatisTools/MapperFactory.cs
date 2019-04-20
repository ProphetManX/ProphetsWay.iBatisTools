using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProphetsWay.iBatisTools
{
    public static class MapperFactory
    {
        /*  This needs a lot of work, the configuration manager part needs to be better specified...  (especially across different frameworks)
        
        public static ISqlMapper GenerateMapper(this Assembly callingAssembly)
        {
            var assemblyName = callingAssembly.ManifestModule.Name;

            Logger.Debug($"Generating an ISqlMapper for {assemblyName}");

            var builderProps = new NameValueCollection();

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MyBatisDBServerName"]))
                builderProps.Add("servername", ConfigurationManager.AppSettings["MyBatisDBServerName"]);

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MyBatisDBUserName"]))
                builderProps.Add("username", ConfigurationManager.AppSettings["MyBatisDBUserName"]);

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MyBatisDBPassword"]))
                builderProps.Add("password", ConfigurationManager.AppSettings["MyBatisDBPassword"]);

            if (ConfigurationManager.ConnectionStrings["MyBatisDBConnection"] != null)
            {
                builderProps.Add("connectionString", ConfigurationManager.ConnectionStrings["MyBatisDBConnection"].ConnectionString);
                builderProps.Add("provider", ConfigurationManager.ConnectionStrings["MyBatisDBConnection"].ProviderName);
            }

            var builder = new DomSqlMapBuilder { ValidateSqlMapConfig = true, Properties = builderProps };
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
        //*/
    }
}
