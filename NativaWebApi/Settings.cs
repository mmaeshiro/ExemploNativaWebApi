using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace NativaWebApi
{
    public static class Settings
    {
        public static string Secret = "da39a3ee5e6b4b0d3255bfef95601890afd80709";

        public static bool IsPropertyExist(object retorno, string name)
        {
            if (retorno is ExpandoObject)
                return ((IDictionary<string, object>)retorno).ContainsKey(name);

            return retorno.GetType().GetProperty(name) != null;
        }

    }  

}
