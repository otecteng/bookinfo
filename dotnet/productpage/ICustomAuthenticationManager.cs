using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
namespace productpage
{
    public interface ICustomAuthenticationManager
    {
         public string Authenticate(string username, string password, IDatabase database );
         public IDictionary<string, string > Tokens {get;}
    }
}