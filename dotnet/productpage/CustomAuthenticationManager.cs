using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
namespace productpage
{
    public class CustomAuthenticationManager: ICustomAuthenticationManager
    {
        private readonly IDictionary<string, string > users = new Dictionary<string, string >
        { {"sicong","12345"},{"admin","admin"} };
        private readonly IDictionary<string, string > tokens = new Dictionary<string, string >();
        public IDictionary<string, string > Tokens => tokens;
        public string Authenticate(string username, string password, IDatabase database)
        {
             if (!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }
            var token = Guid.NewGuid().ToString();
            tokens.Add(token,username);
            database.StringSet(token,username);
            return token;
        }
    }
}