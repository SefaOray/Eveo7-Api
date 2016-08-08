using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eveo7.Models.ServiceInterfaces
{
    public interface IConfigService
    {
        T GetValue<T>(string configName) where T : struct;
    }
}
