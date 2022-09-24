using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LoggerLogic
{
    public static class Actions
    {
        private static Logger _logger = Logger.GetLogger;
        public static bool Method1()
        {
            _logger.Log($"Starting method: {MethodBase.GetCurrentMethod().Name.ToString()}");
            return true;
        }

        public static NewException Method2()
        {
            return new NewException($"Skipped logic in method: {MethodBase.GetCurrentMethod().Name.ToString()}");
        }

        public static void Method3()
        {
            throw new Exception("I broke a logic");
        }
    }
}
