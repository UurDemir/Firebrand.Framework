using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebrand.Exception
{
    public class FirebrandConfigurationException : FirebrandException
    {
        public FirebrandConfigurationException(Type configurationType, string property) : base("ConfigurationError", "Configuration error in " + configurationType.Name + " for property " + property  )
        {

        }
    }
}
