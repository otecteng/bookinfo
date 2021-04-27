using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace productpage
{
    public interface ICustomAuthenticationManager
    {
         public string Authenticate(string username, string password);
         public IDictionary<string, string > Tokens {get;}
    }
}