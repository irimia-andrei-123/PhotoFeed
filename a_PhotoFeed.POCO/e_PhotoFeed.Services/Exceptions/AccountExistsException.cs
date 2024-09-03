using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_PhotoFeed.Services.Exceptions
{
    public class AccountExistsException : Exception
    {
        public AccountExistsException() { }

        public AccountExistsException(string message) : base(message) { }

        public AccountExistsException(string message, Exception ex) : base(message, ex) { }
    }
}
