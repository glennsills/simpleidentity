using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace InMemoryDataStore
{
public class InMemoryClaimsPrincipalFactory : IUserClaimsPrincipalFactory<User>
{
        private IUserStore<User> _dataStore;

        public InMemoryClaimsPrincipalFactory(IUserStore<User> dataStore){
        _dataStore = dataStore;
    }

    public Task<ClaimsPrincipal> CreateAsync(User user)
    {
        
       var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            var principle = new ClaimsPrincipal(identity);

            return Task.FromResult( principle);
        
    }
}
}