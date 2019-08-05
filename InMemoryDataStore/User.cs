using System.Collections.Generic;
using System.Security.Claims;

namespace InMemoryDataStore
{
    public class User
    {
        private const string HASHING_ALGORITHM = "Cleartext";

        public string Id {get;set;}
        public string UserName {get;set;}
        public string NormalizedUserName {get;set;}
        public string Email {get;set;}
        public string NormalizedEmail {get;set;}

        public string Password {get;set;}

        public List<Claim> AssignedClaims {get;set;}

        public List<string> RolesByName {get;set;}
        
    }
}