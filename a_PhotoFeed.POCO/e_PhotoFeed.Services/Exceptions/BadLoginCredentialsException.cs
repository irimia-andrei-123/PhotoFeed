using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_PhotoFeed.Services.Exceptions
{
    public class BadLoginCredentialsException : Exception
    {
        public BadLoginCredentialsException() { }

        public BadLoginCredentialsException(string message) : base(message) { }

        public BadLoginCredentialsException(string message, Exception ex) : base(message, ex) { }
    }
}
