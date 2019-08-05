using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace InMemoryDataStore
{
    public class Role
    {
        public string Id {get;set;} = Guid.NewGuid().ToString("N");
        public string Name {get;set;}
    }
}