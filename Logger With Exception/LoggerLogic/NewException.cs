using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLogic
{
    public sealed class NewException : Exception
    {
        public NewException(string? message)
            : base(message)
        {
        }

        public NewException(string? message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
