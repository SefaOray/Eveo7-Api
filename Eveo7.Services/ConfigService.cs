using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eveo7.Models.ServiceInterfaces;

namespace Eveo7.Services
{
    public class ConfigService : IConfigService
    {
        public T GetValue<T>(string configName) where T : struct
        {
            var config = ConfigurationManager.AppSettings[configName];

            if (config == null)
                return default(T);

            return (T)Convert.ChangeType(config, typeof(T));
        }
    }
}
